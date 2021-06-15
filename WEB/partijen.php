<?php
include_once "./classes/VerkiezingenDB.php";
$db = new VerkiezingenDB();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Partijen</title>
    <link rel="stylesheet" href="./css/style.css">
</head>
<body>
<ul>
        <li><a href="./home.php">Home</a></li>
        <li><a class="active" href="./partijen.php">Partijen</a></li>
        <li><a href="./themas.php">Thema's</a></li>
        <li><a href="./kieswijzer.php">Kieswijzer</a></li>
    </ul> 
</body>
</html>