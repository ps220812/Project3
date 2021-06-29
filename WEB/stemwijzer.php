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
    <main>
        <div class="container">
            <?php
            $rows = $db->stemWijzer();
            foreach ($rows as $row) {
            ?>
                <div class="Srow">
                    <div class="Scol-1">
                        <div class="Scol-1">
                            <table>
                                <?php
                                $rows = $db->stemWijzer();
                                echo "   <tr>
                                    <td>$rows[Standpunt]</td>
                                </tr>
                            ";
                                ?>
                            </table>
                        </div>
                        <div class="Scol-2">
                            <form method='POST' action="stemwijzer.php"><input type='submit' class="btnStem" value='Eens' /></form>
                            <form method='POST' action="stemwijzer.php"><input type='submit' class="btnStem" value='Oneens' /></form>
                        </div>
                    </div>
                </div>
            <?php
            }
            ?>
        </div>
    </main>
</body>

</html>