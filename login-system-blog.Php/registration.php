<?php
require('db.php');
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>Registratie</title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <?php

$registration_success = false;

if(isset($_POST["submit"])) {
    $fotoNaam = basename($_FILES["foto"]["name"]);
    global $uploadsMap;

    function upload() {
        global $uploadsMap;
        $uploadsMap = "uploads/";
        $uploadsMap = $uploadsMap . basename($_FILES["foto"]["name"]);
        $fototype = pathinfo($uploadsMap,PATHINFO_EXTENSION);
        // controleer of de foto al bestaat
        if(file_exists($uploadsMap)) {
            return false;
        }
        //valideer fotosize
        if($_FILES["foto"]["size"] > 500000) {
            echo "Deze foto is te groot.";
            return false;
        }
        //valideer formaat
        if($fototype != "jpg" &&
        $fototype != "png" &&
        $fototype != "jpeg" &&
        $fototype != "gif") {
            echo"Foto moet een jpg, jpeg, png of een gif zijn.";
            return false;
        }
        return true;
    }



    //verplaats de foto van een temp-map naar uploadsMap
    if(upload()) {
        if(move_uploaded_file($_FILES["foto"]["tmp_name"], $uploadsMap)) {
            //gebruiker opslaan in database
            
            $username = htmlspecialchars($_POST['username']);
            $email = htmlspecialchars($_POST['email']);
            $password = htmlspecialchars($_POST['password']);
            $profielFoto = $fotoNaam;
            $create_datetime = date("Y-m-d H:i:s");
            $query    = "INSERT into `users` (username, password, email, create_datetime, profielFoto)
                         VALUES ('$username', '" . md5($password) . "', '$email', '$create_datetime', '$profielFoto')";
            $result   = mysqli_query($conn, $query);
            if ($result) {
                $registration_success = true;
                echo "<div class='form'>
                      <h3>Registratie succesvol.</h3><br/>
                      <p class='link'>Klik hier om in te <a href='login.php'>Loggen</a></p>
                      </div>";
            } else {
                echo "<div class='form'>
                      <h3>Required fields are missing.</h3><br/>
                      <p class='link'>Click here to <a href='registration.php'>registration</a> again.</p>
                      </div>";
            }
        } else {
            echo "Probleem bij het uploaden. foto is niet geüpload.";
        }
    }
}
?>


    <?php if ($registration_success == false) : ?>
    <form class="form" action="" method="post" enctype="multipart/form-data">
        <h1 class="login-title">Registratie</h1>
        <input type="text" class="login-input" name="username" placeholder="Gebruikersnaam" required />
        <input type="text" class="login-input" name="email" placeholder="Email">
        <input type="password" class="login-input" name="password" placeholder="Wachtwoord">
        <input type="file" name="foto">
        <br><br>
        <input type="submit" name="submit" value="Registration" class="login-button">
        <p class="link">Heb je al een account? <a href="login.php">Login</a></p>
    </form>
    <?php endif; ?>
</body>
</html>