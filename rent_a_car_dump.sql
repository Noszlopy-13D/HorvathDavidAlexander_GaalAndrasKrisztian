/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.19-11.6.2-MariaDB, for osx10.19 (arm64)
--
-- Host: localhost    Database: rent_a_car
-- ------------------------------------------------------
-- Server version	11.6.2-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*M!100616 SET @OLD_NOTE_VERBOSITY=@@NOTE_VERBOSITY, NOTE_VERBOSITY=0 */;

--
-- Table structure for table `Cars`
--

DROP TABLE IF EXISTS `Cars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Cars` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ModelId` int(11) NOT NULL,
  `FuelTypeId` int(11) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Km` int(11) NOT NULL,
  `PricePerKm` int(11) NOT NULL,
  `Year` int(11) NOT NULL,
  `HorsePower` int(11) NOT NULL,
  `Description` varchar(400) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Cars_CategoryId` (`CategoryId`),
  KEY `IX_Cars_FuelTypeId` (`FuelTypeId`),
  KEY `IX_Cars_ModelId` (`ModelId`),
  CONSTRAINT `FK_Cars_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Cars_FuelTypes_FuelTypeId` FOREIGN KEY (`FuelTypeId`) REFERENCES `FuelTypes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Cars_Models_ModelId` FOREIGN KEY (`ModelId`) REFERENCES `Models` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cars`
--

LOCK TABLES `Cars` WRITE;
/*!40000 ALTER TABLE `Cars` DISABLE KEYS */;
INSERT INTO `Cars` VALUES
(1,3,1,1,121322,50,2016,150,'A Volkswagen Passat egy tágas és kényelmes szedán, ideális hosszabb utakra és városi közlekedésre egyaránt. Gazdaságos fogyasztás, modern technológia és megbízható teljesítmény jellemzi. Automata váltóval, klímával és tágas csomagtérrel rendelkezik, tökéletes választás üzleti és családi utakhoz.'),
(2,4,2,1,98500,45,2018,120,'A Ford Focus egy dinamikus és megbízható kompakt autó, amely ideális választás városi közlekedéshez és hosszabb utakhoz egyaránt. Alacsony fogyasztás, kényelmes utastér és modern biztonsági felszereltség jellemzi.'),
(3,5,1,1,75000,48,2020,132,'A Toyota Corolla egy legendásan tartós és gazdaságos modell, amely kiváló vezetési élményt nyújt. Kényelmes beltér, megbízható motor és alacsony fenntartási költségek teszik népszerűvé.'),
(4,2,2,2,105000,80,2017,190,'A Mercedes E-Osztály egy elegáns és tágas prémium szedán, amely kimagasló komfortot és technológiai innovációt kínál. Automata váltó, bőr belső és fejlett vezetéstámogató rendszerek biztosítják a luxus élményt.'),
(5,1,1,3,60200,100,2019,204,'A Mercedes C-Osztály sportos megjelenése és erőteljes motorja garantálja a dinamikus vezetési élményt. Kiváló gyorsulás, prémium belső tér és modern technológia jellemzi.'),
(6,5,3,3,50000,90,2021,180,'A Toyota Corolla hibrid változata környezetbarát és takarékos megoldást kínál azok számára, akik modern és hatékony autót keresnek. Csendes üzemmód, alacsony fogyasztás és megbízható teljesítmény jellemzi.');
/*!40000 ALTER TABLE `Cars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Categories`
--

DROP TABLE IF EXISTS `Categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categories`
--

LOCK TABLES `Categories` WRITE;
/*!40000 ALTER TABLE `Categories` DISABLE KEYS */;
INSERT INTO `Categories` VALUES
(1,'Hétköznapi'),
(2,'Luxus'),
(3,'Sport');
/*!40000 ALTER TABLE `Categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `FuelTypes`
--

DROP TABLE IF EXISTS `FuelTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `FuelTypes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FuelTypes`
--

LOCK TABLES `FuelTypes` WRITE;
/*!40000 ALTER TABLE `FuelTypes` DISABLE KEYS */;
INSERT INTO `FuelTypes` VALUES
(1,'Benzin'),
(2,'Dízel'),
(3,'Benzin-Hibrid'),
(4,'Dízel-Hibrid'),
(5,'Elektromos');
/*!40000 ALTER TABLE `FuelTypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Images`
--

DROP TABLE IF EXISTS `Images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Images` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CarId` int(11) NOT NULL,
  `Path` varchar(100) NOT NULL,
  `UploadDate` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Images_CarId` (`CarId`),
  CONSTRAINT `FK_Images_Cars_CarId` FOREIGN KEY (`CarId`) REFERENCES `Cars` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Images`
--

LOCK TABLES `Images` WRITE;
/*!40000 ALTER TABLE `Images` DISABLE KEYS */;
INSERT INTO `Images` VALUES
(1,2,'AF109A5C-041F-47E1-A103-ADD976BCD83B.jpg','0001-01-01 00:00:00.000000'),
(2,2,'631C96AF-2FD2-4198-86C5-5A9A011EDBBE.jpg','0001-01-01 00:00:00.000000'),
(3,2,'0BD9FD45-B1E9-4E47-BAA5-4A25C240907D.jpg','0001-01-01 00:00:00.000000'),
(4,1,'64BAACEA-7F1F-4F81-8498-4759FCCFEEAE.jpeg','0001-01-01 00:00:00.000000'),
(5,1,'34DE130B-8E3C-4007-95A5-DEB9E77F8CE6.jpg','0001-01-01 00:00:00.000000'),
(7,3,'84acef58-f25f-4291-a2d7-66bd2fae1805.JPG','2025-04-24 09:17:15.035404'),
(8,3,'9d53f286-8e24-43e3-887c-a5f764411332.jpg','2025-04-24 09:18:41.834619'),
(9,4,'97369fc6-ba3f-41b1-806d-a1c0ed1264eb.jpg','2025-04-24 09:21:43.076895'),
(10,4,'d6810420-8056-4d47-80a7-f22390d93f6f.png','2025-04-24 09:22:58.745821'),
(11,6,'f68b88df-3557-4b45-8992-c585a4b8cd4c.jpg','2025-04-24 09:25:21.604375'),
(12,6,'1d98bb38-da4b-40df-b2db-d96ea47cff1f.webp','2025-04-24 09:25:34.299646'),
(13,6,'441f713d-ef27-4bd5-9020-77df7c4f7cfc.jpg','2025-04-24 09:25:41.130853'),
(14,5,'2d5ddc7e-3078-4119-9eb2-bb989cdf1438.jpg','2025-04-24 09:26:55.725923'),
(15,5,'c31eddb9-fac9-4c8d-ba2a-aa66ac4259b0.jpg','2025-04-24 09:26:58.958746');
/*!40000 ALTER TABLE `Images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Manufacturers`
--

DROP TABLE IF EXISTS `Manufacturers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Manufacturers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Manufacturers`
--

LOCK TABLES `Manufacturers` WRITE;
/*!40000 ALTER TABLE `Manufacturers` DISABLE KEYS */;
INSERT INTO `Manufacturers` VALUES
(1,'Mercedes'),
(2,'BMW'),
(3,'Volkswagen'),
(4,'Audi'),
(5,'Ford'),
(6,'Toyota');
/*!40000 ALTER TABLE `Manufacturers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Models`
--

DROP TABLE IF EXISTS `Models`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Models` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ManufacturerId` int(11) NOT NULL,
  `Name` varchar(80) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Models_ManufacturerId` (`ManufacturerId`),
  CONSTRAINT `FK_Models_Manufacturers_ManufacturerId` FOREIGN KEY (`ManufacturerId`) REFERENCES `Manufacturers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Models`
--

LOCK TABLES `Models` WRITE;
/*!40000 ALTER TABLE `Models` DISABLE KEYS */;
INSERT INTO `Models` VALUES
(1,1,'C-Osztály'),
(2,1,'E-Osztály'),
(3,3,'Passat'),
(4,5,'Focus'),
(5,6,'Corolla');
/*!40000 ALTER TABLE `Models` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SupportMessages`
--

DROP TABLE IF EXISTS `SupportMessages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `SupportMessages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime(6) NOT NULL,
  `EmailAddress` varchar(80) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Message` varchar(2500) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SupportMessages`
--

LOCK TABLES `SupportMessages` WRITE;
/*!40000 ALTER TABLE `SupportMessages` DISABLE KEYS */;
/*!40000 ALTER TABLE `SupportMessages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES
('20250212094513_InitialCreate','9.0.1'),
('20250221105909_DataSeeding','9.0.1'),
('20250305102528_SupportMessage','9.0.1'),
('20250305102946_SupportMessagesFixed','9.0.1'),
('20250311093322_Images','9.0.1'),
('20250312082851_ImageSeeding','9.0.1'),
('20250312083546_ImageFileExtensionFix','9.0.1'),
('20250424065922_FixedFocus','9.0.1'),
('20250424070112_FixedFocusAgain','9.0.1');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*M!100616 SET NOTE_VERBOSITY=@OLD_NOTE_VERBOSITY */;

-- Dump completed on 2025-04-24 13:08:27
