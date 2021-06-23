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
    <title>Contact</title>
    <link rel="stylesheet" href="./css/style.css">
    <link rel="stylesheet" href="./css/menu.css">
</head>

<body>
    <header>
        <div class="container-header">
            <div class="topnav">
                <nav>
                    <ul>
                        <li><a href="index.php">Home</a></li>
                        <li><a href="thema.php">Themas</a></li>
                        <li><a href="kieswijzer.php">Stem</a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </header>

    <main class="container">
        <div class="row">
            <div class="Contact">Contact</div>
            <div class="info_Partij">
                <?php
                $row = $db->selectPartij($_POST['ParijtId']);
                echo "<h2>$row[PartijName]</h2>
                <p>Adres: $row[Adres]</p>
                <p>Postcode: $row[Postcode]</p>
                <p>Gemeente: $row[Gemeente]</p>
                <p>Email: $row[EmailAdres]</p>
                <p>Telefoonnummer: $row[Telefoonnummer]</p>
                ";
                ?>
            </div>


        </div>
    </main>
</body>

</html>