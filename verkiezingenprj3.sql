-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 23, 2021 at 11:56 AM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `verkiezingenprj3`
--
CREATE DATABASE IF NOT EXISTS `verkiezingenprj3` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `verkiezingenprj3`;

-- --------------------------------------------------------

--
-- Table structure for table `partij`
--

CREATE TABLE IF NOT EXISTS `partij` (
  `PartijId` int(11) NOT NULL AUTO_INCREMENT,
  `PartijName` varchar(200) NOT NULL,
  `Adres` varchar(200) DEFAULT NULL,
  `Postcode` varchar(10) DEFAULT NULL,
  `Gemeente` varchar(200) DEFAULT NULL,
  `EmailAdres` varchar(50) DEFAULT NULL,
  `Telefoonnummer` varchar(50) DEFAULT NULL,
  `Website` varchar(99) NOT NULL,
  PRIMARY KEY (`PartijId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `partij`
--

INSERT INTO `partij` (`PartijId`, `PartijName`, `Adres`, `Postcode`, `Gemeente`, `EmailAdres`, `Telefoonnummer`, `Website`) VALUES
(2, 'PVV', 'N.v.T', '2500 EA', 'Den Haag', 'pvv.publiek@tweedekamer.nl', '31703182867', 'https://www.pvv.nl/'),
(3, 'VVD', 'Binnenhof 1A', '2500 EA', 'Den Haag', 'vvdvoorlichting@tweedekamer.nl', '31703183036', 'https://www.vvd.nl/'),
(5, 'Forum voor Democratie', 'Herengracht 74', '1015 BR', 'Amsterdam', 'partij@fvd.nl', '020-2612874', 'https://www.fvd.nl/'),
(6, 'PvdA', 'Leeghwaterplein 45', '2521 DB', 'Den Haag', 'voorzitter@pvda.nl', '070-5500555', 'https://www.pvda.nl/'),
(7, 'CDA', 'Buitenom 18', '2512 XA', 'Den Haag', 'cda.publieksvoorlichting@tweedekamer.nl', '0703183026', 'https://www.cda.nl/'),
(8, 'Volt', 'N.v.T', 'N.v.T', 'N.v.T', 'info@voltnederland.org', 'N.v.T', 'https://voltnederland.org/'),
(9, 'Piratenpartij', 'Wolvenplein 2', '3512 CJ', 'Utrecht', 'info@piratenpartij.nl', '3185 4013619', 'https://piratenpartij.nl/'),
(10, 'D66', 'Lange Houtstraat 11', '2511 CV', 'Den Haag', 'd.bonenkamp@tweedekamer.nl', '070-3566066', 'https://d66.nl/'),
(11, 'GroenLinks', 'Plein 2', '2511 CR', 'Den Haag', 'groenlinks@tweedekamer.nl', '070-3183030', 'https://groenlinks.nl/home'),
(12, 'SP', 'Snouckaertlaan 70', '3811 MB', 'Amersfoort', 'sp@sp.nl', '088 2435555', 'https://www.sp.nl/');

-- --------------------------------------------------------

--
-- Table structure for table `standpunten`
--

CREATE TABLE IF NOT EXISTS `standpunten` (
  `StandpuntId` int(11) NOT NULL AUTO_INCREMENT,
  `PartijId` int(11) NOT NULL,
  `PartijName` varchar(200) NOT NULL,
  `ThemaId` int(11) NOT NULL,
  `Thema` varchar(200) NOT NULL,
  `Standpunt` varchar(2000) NOT NULL,
  PRIMARY KEY (`StandpuntId`),
  KEY `PartijId` (`PartijId`),
  KEY `ThemaId` (`ThemaId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `standpunten`
--

INSERT INTO `standpunten` (`StandpuntId`, `PartijId`, `PartijName`, `ThemaId`, `Thema`, `Standpunt`) VALUES
(1, 2, 'PVV', 2, 'Asielzoekers', 'Ons land is veel te soepel voor asielzoekers. '),
(2, 3, 'VVD', 1, 'VVD', 'Toptalenten uit het buitenland zijn van harte welkom'),
(3, 11, 'GroenLinks', 5, 'Klimaat', 'Als we niet snel in actie komen, laten we niet alleen een onleefbare wereld achter, maar wordt de aarde straks ook onbewoonbaar'),
(4, 7, 'CDA', 3, 'Cultuur', 'Corona heeft de cultuur sector hard te pakken gehad en wij moeten inzetten op een fors economisch herstel van de sector'),
(5, 5, 'Forum voor Democratie', 7, 'Nederland in de EU', 'Nederland moet net zoals Engeland de EU uit'),
(6, 9, 'Piratenpartij', 8, 'Veiligheid', 'Gebruiker gegevens moeten sterker worden beveiligd'),
(7, 6, 'PvdA', 9, 'Werkgelegenheid', 'Voor iedereen die door de corona crisis geen werk meer heeft moet er werkgarantie komen'),
(8, 10, 'D66', 6, 'Onderwijs', 'We moeten meer investeren in het ontwikkelen van onze jeugd'),
(9, 12, 'SP', 10, 'Zorg', 'De zorg zou geen markt moeten zijn met concurrerende zorgverzekeraars, we moeten in plaats daarvan een nationale zorgfonds maken waarvan de premie op inkomst gebaseerd is'),
(10, 8, 'Volt', 4, 'Handel en economie', 'De Europese landen moeten samenwerken om een gezamelijke Europees belastingssysteem te maken');

-- --------------------------------------------------------

--
-- Table structure for table `stem`
--

CREATE TABLE IF NOT EXISTS `stem` (
  `standpunt_id` int(11) NOT NULL,
  `naam gebruiker` varchar(255) NOT NULL,
  `eens` tinyint(1) NOT NULL,
  `weging` int(11) DEFAULT NULL,
  PRIMARY KEY (`standpunt_id`,`naam gebruiker`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `thema`
--

CREATE TABLE IF NOT EXISTS `thema` (
  `ThemaId` int(11) NOT NULL AUTO_INCREMENT,
  `Thema` varchar(200) NOT NULL,
  PRIMARY KEY (`ThemaId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `thema`
--

INSERT INTO `thema` (`ThemaId`, `Thema`) VALUES
(1, 'Arbeidsmigratie'),
(2, 'Asielzoekers'),
(3, 'Cultuur'),
(4, 'Handel en economie'),
(5, 'Klimaat'),
(6, 'Onderwijs'),
(7, 'Nederland in de EU'),
(8, 'Veiligheid'),
(9, 'Werkgelegenheid'),
(10, 'Zorg');

-- --------------------------------------------------------

--
-- Table structure for table `verkiezing`
--

CREATE TABLE IF NOT EXISTS `verkiezing` (
  `VerkiezingId` int(11) NOT NULL AUTO_INCREMENT,
  `SoortId` int(11) NOT NULL,
  `Verkiezingsoort` varchar(100) NOT NULL,
  `Datum` date DEFAULT NULL,
  PRIMARY KEY (`VerkiezingId`),
  KEY `SoortId` (`SoortId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `verkiezingsoort`
--

CREATE TABLE IF NOT EXISTS `verkiezingsoort` (
  `SoortId` int(11) NOT NULL AUTO_INCREMENT,
  `Verkiezingsoort` varchar(100) NOT NULL,
  PRIMARY KEY (`SoortId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `verkiezingsoort`
--

INSERT INTO `verkiezingsoort` (`SoortId`, `Verkiezingsoort`) VALUES
(1, 'Eerste Kamerverkiezing'),
(2, 'Tweede Kamerverkiezing'),
(3, 'Provinciale Statenverkiezing'),
(4, 'Waterschapsverkiezing'),
(5, 'Gemeenteraadsverkiezing'),
(6, 'Europese verkiezing');

-- --------------------------------------------------------

--
-- Table structure for table `verkiezingspartijen`
--

CREATE TABLE IF NOT EXISTS `verkiezingspartijen` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartijId` int(11) NOT NULL,
  `VerkiezingId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `VerkiezingId` (`VerkiezingId`),
  KEY `PartijId` (`PartijId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `standpunten`
--
ALTER TABLE `standpunten`
  ADD CONSTRAINT `standpunten_ibfk_1` FOREIGN KEY (`PartijId`) REFERENCES `partij` (`PartijId`),
  ADD CONSTRAINT `standpunten_ibfk_2` FOREIGN KEY (`ThemaId`) REFERENCES `thema` (`ThemaId`);

--
-- Constraints for table `stem`
--
ALTER TABLE `stem`
  ADD CONSTRAINT `stem_ibfk_1` FOREIGN KEY (`standpunt_id`) REFERENCES `standpunten` (`StandpuntId`);

--
-- Constraints for table `verkiezing`
--
ALTER TABLE `verkiezing`
  ADD CONSTRAINT `verkiezing_ibfk_1` FOREIGN KEY (`SoortId`) REFERENCES `verkiezingsoort` (`SoortId`);

--
-- Constraints for table `verkiezingspartijen`
--
ALTER TABLE `verkiezingspartijen`
  ADD CONSTRAINT `verkiezingspartijen_ibfk_1` FOREIGN KEY (`VerkiezingId`) REFERENCES `verkiezing` (`VerkiezingId`),
  ADD CONSTRAINT `verkiezingspartijen_ibfk_2` FOREIGN KEY (`PartijId`) REFERENCES `partij` (`PartijId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
