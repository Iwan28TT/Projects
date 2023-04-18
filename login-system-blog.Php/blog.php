<?php
//include auth_session.php file on all user panel pages
include("auth_session.php");

// Databaseverbinding
include('db.php');


// Als er een blogpost is geüpload
if (isset($_POST['submit'])) {
  $blogtekst = $_POST['blogtekst'];
  $gebruikersnaam = $_SESSION['userid'];
  $profielfoto = $_SESSION['profielFoto'];
  $afbeelding = $_FILES['afbeelding']['name'];
  $target = "uploads/".basename($afbeelding);

  // Voeg de blogpost toe aan de database
  $sql = "INSERT INTO blogposts (user, blog, blogimg) VALUES ('$gebruikersnaam', '$blogtekst', '$afbeelding')";
  mysqli_query($conn, $sql);

  // Upload de afbeelding naar de server
  move_uploaded_file($_FILES['afbeelding']['tmp_name'], $target);
}

// Als er een blogpost moet worden verwijderd
if (isset($_POST['delete'])) {
  $id = $_POST['delete'];
  $afbeelding = $_POST['afbeelding'];

  // Haal de ID van de gebruiker op die de blogpost heeft geüpload
  $sql = "SELECT user FROM blogposts WHERE id=$id";
  $result = mysqli_query($conn, $sql);
  $row = mysqli_fetch_assoc($result);
  $gebruikersnaam = $row['user'];

  // Controleer of de gebruiker die probeert de blogpost te verwijderen de eigenaar is van die blogpost
  if ($gebruikersnaam == $_SESSION['userid']) {

    // Verwijder de blogpost uit de database
    $sql = "DELETE FROM blogposts WHERE id=$id";
    mysqli_query($conn, $sql);

    // Verwijder de afbeelding van de server
    if (!empty($afbeelding)) {
      $afbeelding_path = "uploads/" . $afbeelding;
      if (file_exists($afbeelding_path)) {
        unlink($afbeelding_path);
      }
    }
  }
}

?>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>Blog pagina</title>
  <link rel="stylesheet" href="style.css" />
  <script>
    if ( window.history.replaceState ) {
        window.history.replaceState( null, null, window.location.href );
    }
</script>
</head>
<body>
  <div class="form">
    <p>Hey, <?php echo $_SESSION['username']; ?>!</p>
    <div class="profiel-foto">
    <?php echo '<img src="uploads/'. $_SESSION['profielFoto'].'" class="profiel-img" />'; ?>
</div>
    <p>Je bent in de blog pagina.</p>
    <form method="post" action="blog.php" enctype="multipart/form-data">
      <textarea name="blogtekst" placeholder="Schrijf hier je blogpost"></textarea><br>
      <input type="file" name="afbeelding"><br>
      <input type="submit" name="submit" value="Plaats je blogpost">
      <p><a href="logout.php">Uitloggen</a></p>
    </form>
    <hr>
    <?php
      // Haal alle blogposts op uit de database en sorteer ze op datum
      $sql = "SELECT B.*,U.profielFoto,U.username FROM blogposts B  left join users U on B.user = U.id    ORDER BY datum DESC";
      $result = mysqli_query($conn, $sql);
      
      while($row = mysqli_fetch_assoc($result)) {
        $id = $row['id'];
        $gebruikersnaam = isset($row['username']) ? $row['username'] : 'leeg';
        $profielfoto = isset($row['profielFoto']) ? $row['profielFoto'] : 'leeg';
        $blogtekst = isset($row['blog']) ? $row['blog'] : 'leeg';
        $afbeelding = isset($row['blogimg']) ? $row['blogimg'] : '';
        $datum = $row['datum'];

        $blogimg = '';
        if (!empty($afbeelding)) {
          $blogimg = '<img class="profiel-img" src="uploads/'.$afbeelding.'" max-width="385px" max-height="100px" />';
        }

        $text = <<<txt

         <div class="blogpost">
            <div class="blogcontent">
              <p>{$blogtekst}</p>
              
              {$blogimg}
            </div>
            <div class="blogprofiel">
              <div class="blogprofiel-img">
                <img src="uploads/{$profielfoto}" class="profiel-img" /> 
              </div>
              <div class="blogprofiel-info">
              <h4>{$gebruikersnaam}</h4>
              <p>{$datum}</p>
              </div>
            </div>
         </div>
        txt;

        echo $text;


        echo '<form method="post" action="blog.php">';
        echo '<input type="hidden" name="delete" value="'.$id.'">';
        echo '<input type="hidden" name="afbeelding" value="'.$afbeelding.'">';
        // controleer of de gebruiker is ingelogd
if(isset($_SESSION['userid'])) {
  // haal de gebruiker-ID van de ingelogde gebruiker op
  $loggedInUserId = $_SESSION['userid'];

  // haal de gebruiker-ID van de auteur van de blogpost op
  $authorId = $row['user'];

  // als de ingelogde gebruiker de auteur is, toon dan de verwijderknop
  if($loggedInUserId == $authorId) {
    echo '<form method="post" action="delete.php">';
    echo '<input type="hidden" name="id" value="'.$row['id'].'">';
    echo '<button type="submit" name="delete-blog">Verwijder</button>';
    echo '</form>';
       }
      }
    }
    ?>
  </div>
</body>
</html>

