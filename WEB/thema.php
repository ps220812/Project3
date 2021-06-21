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
    <title>Themas</title>
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
            <div class="mini-row">
                <?php
                $rows = $db->selectThemas();
                foreach ($rows as $row) {
                    echo "<div class='mini-container'>
                    <h2 class='themaTitel'>$row[Thema]</h2>
                    </div>
                    ";
                }

                ?>
            </div>

        </div>
    </main>
</body>

</html>