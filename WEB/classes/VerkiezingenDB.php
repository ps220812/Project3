<?php
class VerkiezingenDB
{
    const DSN = "mysql:host=localhost;dbname=verkiezingenprj3";
    const USER = "root";
    const PASSWD = "";

    function selectPartijen()
    {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);
            $statement = $pdo->prepare("SELECT*FROM partij;");
            $statement->execute();
            $rows = $statement->fetchall(PDO::FETCH_ASSOC);
            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    function selectThemas()
    {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);
            $statement = $pdo->prepare("SELECT*FROM thema;");
            $statement->execute();
            $rows = $statement->fetchall(PDO::FETCH_ASSOC);
            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    function selectStandpunt($id)
    {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);
            $statement = $pdo->prepare("SELECT * FROM `standpunten` WHERE `ThemaId` = :id;");
            $statement->bindvalue(":id", $id, PDO::PARAM_INT);
            $statement->execute();
            $rows = $statement->fetchall(PDO::FETCH_ASSOC);
            return $rows[0];
        } catch (PDOException $e) {
            return false;
        }
    }

    function selectPartij($id)
    {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);
            $statement = $pdo->prepare("SELECT * FROM `partij` WHERE `PartijId` = :id;");
            $statement->bindvalue(":id", $id, PDO::PARAM_INT);
            $statement->execute();
            $rows = $statement->fetchall(PDO::FETCH_ASSOC);
            return $rows[0];
        } catch (PDOException $e) {
            return false;
        }
    }

    function stemWijzer()
    {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);
            $statement = $pdo->prepare("SELECT * FROM `standpunten` ");
            $statement->execute();
            $rows = $statement->fetchall(PDO::FETCH_ASSOC);
            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }
}
