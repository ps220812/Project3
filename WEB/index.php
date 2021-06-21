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
    <title>Home</title>
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
            <div class="row">
                <div class="col-1">
                    <h1 class="titel">Stemwijzer</h1>
                    <p class="pText">Welkom op de stemwijzer. Deze pagina is bedoelt om u te helpen met het maken van uw keuze tijdens de verkiezingen.</p>
                </div>
                <div class="col-2">
                    <button class="btnStart">Start</button>
                </div>
            </div>
            <div class="row-2">
                <div class="col-3">
                    <h1>Deze partijen doen mee</h1>
                    <div class="Partijen">
                        
                            <?php
                            $rows = $db->selectPartijen();
                            foreach ($rows as $row){
                                echo "<form method='POST' action='contact.php'>
                                <input name='ParijtId' type='hidden' value='$row[PartijId]'/>
                                <input type='submit' id='$row[PartijId]' class='Parijten-btn' value='$row[PartijName]'/></form>
                                ";
                            }
                            ?>

                    </div>
                </div>
            </div>
        </div>
    </main>






</body>

</html>