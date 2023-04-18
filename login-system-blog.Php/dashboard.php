<?php
//include auth_session.php file on all user panel pages
include("auth_session.php");
?>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Dashboard - Client area</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div class="form">
        <p>Hey, <?php echo $_SESSION['username']; ?>!</p>
        <?php echo '<img src="uploads/'. $_SESSION['profielFoto'].'" style="position: absolute; left: 465px; top:10px; width: 75px" />'; ?>
        <p>Je bent nu in de dashboard pagina, maak een keuze!</p>
        <p><a href="logout.php">Uitloggen</a></p>
        <a href="blog.php">Ga naar de blogpagina</a>
    </div>
</body>
</html>
