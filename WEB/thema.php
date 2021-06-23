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
                    echo "<form method='post' action='standpunt.php' >
                    <div class='mini-container'>
                    <input type='submit' class='themaTitel' value='$row[Thema]'/>
                    <input type='hidden' value='$row[ThemaId]' name='thema_id' />
                    </div></form>
                    ";
                }

                ?>
            </div>

        </div>
    </main>
</body>

</html>