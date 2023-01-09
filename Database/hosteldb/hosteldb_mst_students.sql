-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: hosteldb
-- ------------------------------------------------------
-- Server version	5.7.9-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `mst_students`
--

DROP TABLE IF EXISTS `mst_students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mst_students` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mobile` bigint(20) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `fname` varchar(45) DEFAULT NULL,
  `mname` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `paddress` varchar(45) DEFAULT NULL,
  `collage` varchar(45) DEFAULT NULL,
  `idproof` varchar(45) DEFAULT NULL,
  `room_no` int(11) DEFAULT NULL,
  `living` varchar(45) DEFAULT 'Yes',
  PRIMARY KEY (`id`),
  KEY `room_no_idx` (`room_no`),
  CONSTRAINT `room_no` FOREIGN KEY (`room_no`) REFERENCES `mst_addroom` (`room_no`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mst_students`
--

LOCK TABLES `mst_students` WRITE;
/*!40000 ALTER TABLE `mst_students` DISABLE KEYS */;
INSERT INTO `mst_students` VALUES (2,123,'Ritik Verma','Vivek Verma','Seema Verma','ritik123@gmail.com','Agra','MPS Collage','123-001',101,'No'),(3,1234,'Varun Goyal','Ramesh Goyal','Shilpi Goyal','varun123@gmail.com','Noida','Hindustan Collage','1234-002',102,'Yes');
/*!40000 ALTER TABLE `mst_students` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-09 13:31:54
