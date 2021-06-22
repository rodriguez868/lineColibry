-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: line_colibry
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `estados`
--

DROP TABLE IF EXISTS `estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estados` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados`
--

LOCK TABLES `estados` WRITE;
/*!40000 ALTER TABLE `estados` DISABLE KEYS */;
INSERT INTO `estados` VALUES (1,'Creado'),(2,'Asignado'),(3,'Gestionado'),(4,'Finalizado'),(5,'Rechazado');
/*!40000 ALTER TABLE `estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evidencias`
--

DROP TABLE IF EXISTS `evidencias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evidencias` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_orden` int DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `ruta` varchar(255) DEFAULT NULL,
  `tamano` int DEFAULT NULL,
  `tipo` int DEFAULT NULL,
  `content` varchar(45) DEFAULT NULL,
  `creacion` datetime DEFAULT CURRENT_TIMESTAMP,
  `modificacion` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `estado` tinyint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evidencias`
--

LOCK TABLES `evidencias` WRITE;
/*!40000 ALTER TABLE `evidencias` DISABLE KEYS */;
INSERT INTO `evidencias` VALUES (1,3,'orden_3_Evidencia_firma.png','~/Content/Upload/orden_3_Evidencia_firma.png',77691,1,'image/png','2021-06-18 19:43:44',NULL,1),(2,3,'orden_3_Evidencia_firma.png','~/Content/Upload/orden_3_Evidencia_firma.png',77691,1,'image/png','2021-06-18 19:46:04',NULL,1),(3,3,'orden_3_Evidencia_Captura.PNG','~/Content/Upload/orden_3_Evidencia_Captura.PNG',270811,1,'image/png','2021-06-18 20:00:58',NULL,1),(4,3,'orden_3_Evidencia_Captura.PNG','~/Content/Upload/orden_3_Evidencia_Captura.PNG',270811,1,'image/png','2021-06-18 20:02:25',NULL,1);
/*!40000 ALTER TABLE `evidencias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lineabase`
--

DROP TABLE IF EXISTS `lineabase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lineabase` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_orden` int DEFAULT NULL,
  `id_tipo_datos` int DEFAULT NULL,
  `id_sector` int DEFAULT NULL,
  `nm_sector` varchar(45) DEFAULT NULL,
  `id_item` int DEFAULT NULL,
  `nm_item` varchar(45) DEFAULT NULL,
  `antes` varchar(100) DEFAULT NULL,
  `despues` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_sector_id_tipo_datos` (`id_sector`,`id_tipo_datos`,`id_item`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lineabase`
--

LOCK TABLES `lineabase` WRITE;
/*!40000 ALTER TABLE `lineabase` DISABLE KEYS */;
INSERT INTO `lineabase` VALUES (1,3,1,1,'Sector X',3,'Azimuth','123','132'),(2,3,1,2,'Sector Y',4,'Altura','23','15'),(3,3,0,1,'Sector X',5,'Tilt Electrico','malo','bueno');
/*!40000 ALTER TABLE `lineabase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ordenes`
--

DROP TABLE IF EXISTS `ordenes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ordenes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `sitio` varchar(200) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `direccion` varchar(300) DEFAULT NULL,
  `tipo` int DEFAULT NULL,
  `latitud` float DEFAULT '0',
  `longitud` float DEFAULT '0',
  `altura` int DEFAULT NULL,
  `nivel_mar` int DEFAULT NULL,
  `tipo_ingreso` varchar(45) DEFAULT NULL,
  `actividad` varchar(800) DEFAULT NULL,
  `id_usuario` int DEFAULT NULL,
  `id_tecnico` int DEFAULT NULL,
  `id_coordinador` int DEFAULT NULL,
  `creado` datetime DEFAULT CURRENT_TIMESTAMP,
  `modificado` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `estado` tinyint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordenes`
--

LOCK TABLES `ordenes` WRITE;
/*!40000 ALTER TABLE `ordenes` DISABLE KEYS */;
INSERT INTO `ordenes` VALUES (2,'prueba2','2021-06-04 00:00:00','prueba 1',1,NULL,NULL,23,23,NULL,'wregetyjtuilyip\'po\'opo',9,18,12,'2021-06-04 15:10:09','2021-06-21 19:54:49',2),(3,'Ibague ','2021-06-14 00:00:00','Call10 # 15-24',2,NULL,NULL,30,1545,NULL,'Ajustes físicos  ',9,18,12,'2021-06-11 20:50:46','2021-06-18 19:17:43',3),(4,'cali','2021-06-22 00:00:00','cll 87 g 33 77',1,23123100,3123120,212,222,NULL,'quitar la antena ',9,18,12,'2021-06-21 18:29:17','2021-06-21 18:40:29',2),(5,'colombia 2','2021-06-22 00:00:00','calle 1 # 2-33',2,123456,789456,2233,1122,NULL,'mover la antena  a 40m hacia el sur ',9,NULL,NULL,'2021-06-21 18:43:07','2021-06-21 19:05:51',1),(6,'colombia 00','2021-06-23 00:00:00','prueba 10',2,1111110,3333330000,444444444,222222222,NULL,'solo la antena',9,NULL,NULL,'2021-06-21 19:10:42','2021-06-21 19:14:45',1),(7,'popayan','2021-06-23 00:00:00','111111',2,1111,111111,11111111,11111,NULL,'esta antena se callo ',9,18,12,'2021-06-21 19:20:21','2021-06-21 19:55:18',2);
/*!40000 ALTER TABLE `ordenes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador General'),(2,'Administrador'),(3,'Coordinador'),(4,'Auditor'),(5,'Técnico');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_ingreso`
--

DROP TABLE IF EXISTS `tipo_ingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_ingreso` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_ingreso`
--

LOCK TABLES `tipo_ingreso` WRITE;
/*!40000 ALTER TABLE `tipo_ingreso` DISABLE KEYS */;
INSERT INTO `tipo_ingreso` VALUES (1,'Llave'),(2,'Carta');
/*!40000 ALTER TABLE `tipo_ingreso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_torre`
--

DROP TABLE IF EXISTS `tipo_torre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_torre` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_torre`
--

LOCK TABLES `tipo_torre` WRITE;
/*!40000 ALTER TABLE `tipo_torre` DISABLE KEYS */;
INSERT INTO `tipo_torre` VALUES (1,'Monopolo'),(2,'Movil'),(3,'Auto Soportada'),(4,'Valla');
/*!40000 ALTER TABLE `tipo_torre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `apellido` varchar(45) DEFAULT NULL,
  `email` varchar(45) NOT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `id_rol` varchar(1) DEFAULT NULL,
  `creado` datetime DEFAULT CURRENT_TIMESTAMP,
  `modificado` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `estado` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1 COMMENT='			';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (8,'System','Admin','admin@linecolibry.co','admin','123456','1','2021-06-02 19:53:30',NULL,1),(9,'Ingeniero','Uno','coordinados@linecolibry.co','ingeniero','1234567','2','2021-06-02 20:00:18','2021-06-04 08:45:04',1),(12,'Coordinador','Uno','coordinador1@linecolibry.co','coordinador','123456','3','2021-06-02 20:03:30','2021-06-04 08:45:18',1),(13,'Auditor','Jefe','auditor@linecolibry.co','auditor','123456','4','2021-06-02 20:04:13',NULL,1),(17,'Coordinador','Dos','cordinadordos@linecolibry.com','coordinador2','123456','3','2021-06-04 08:44:42',NULL,1),(18,'Raul','Castro','raul123@gmail.com','técnico','123456','5','2021-06-18 19:11:17',NULL,1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-21 21:33:00
