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
            <table class="table">
                <tr>
                    <th>Standpunt</th>
                    <th>Eens</th>
                    <th>Oneens</th>
                </tr>
                <?php
                $rows = $db->stemwijzer();
                $rbid = 1;
                foreach ($rows as $row) {
                    echo "<tr>
                    <td>$row[Standpunt]</td>

                    <td><input type='Radio' name='radio$rbid' value='Eens'/></td>
                    <td><input type='Radio' name='radio$rbid' value='Oneens'/></td>
                    
                </tr>";
                $rbid++;
                }
                ?>
            </table>
        </div>

    </main>
</body>

</html>