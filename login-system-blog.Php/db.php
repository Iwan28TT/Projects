<?php
    // Enter your host name, database username, password, and database name.
    // If you have not set database password on localhost then set empty.
    $conn = new mysqli('localhost','fp240995','IwanSilas28@','fp240995');
    // Check connectionx    
    if ($conn->connect_error){
        echo ("Failed to connect to MySQL: " . $conn->connect_error);
    }
?>
