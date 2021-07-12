﻿CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    CREATE TABLE `Message` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `UserId` bigint NOT NULL,
        `MessageTypeId` int NOT NULL,
        `Title` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
        `Data` longtext CHARACTER SET utf8mb4 NULL,
        `ReadState` tinyint(1) NOT NULL,
        `DeliveryState` tinyint(1) NOT NULL,
        `IsDeleted` tinyint(1) NOT NULL,
        `CreateTime` datetime(6) NOT NULL,
        `ReadTime` datetime(6) NOT NULL,
        `DeleteTime` datetime(6) NOT NULL,
        `ExpirationTime` datetime(6) NOT NULL,
        CONSTRAINT `PK_Message` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    CREATE TABLE `Message_Push_Platform` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
        `ProviderName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Config` longtext CHARACTER SET utf8mb4 NULL,
        `Priority` int NOT NULL,
        `IsEnabled` tinyint(1) NOT NULL,
        CONSTRAINT `PK_Message_Push_Platform` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    CREATE TABLE `Message_Push_Record` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `MessageId` bigint NOT NULL,
        `PlatformId` int NOT NULL,
        `Content` longtext CHARACTER SET utf8mb4 NULL,
        `Url` longtext CHARACTER SET utf8mb4 NULL,
        `PushState` tinyint(1) NOT NULL,
        `RetriesNum` int NOT NULL,
        `Remark` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Message_Push_Record` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    CREATE TABLE `Message_Session` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `MessageTypeId` int NOT NULL,
        `Title` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
        `Data` longtext CHARACTER SET utf8mb4 NULL,
        `UserIds` longtext CHARACTER SET utf8mb4 NULL,
        `UserNum` int NOT NULL,
        `PushNum` int NOT NULL,
        `CreateTime` datetime(6) NOT NULL,
        `State` int NOT NULL,
        `CompleteTime` datetime(6) NOT NULL,
        `ExpirationTime` datetime(6) NOT NULL,
        `Remark` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Message_Session` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    CREATE TABLE `Message_Template` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `PlatformId` int NOT NULL,
        `MessageTypeCode` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
        `TemplateCode` varchar(256) CHARACTER SET utf8mb4 NULL,
        `ContentTemplate` varchar(512) CHARACTER SET utf8mb4 NULL,
        `UrlTemplate` varchar(512) CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Message_Template` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    CREATE TABLE `Message_Type` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Code` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Icon` varchar(256) CHARACTER SET utf8mb4 NULL,
        `TitleTemplate` varchar(512) CHARACTER SET utf8mb4 NULL,
        `DescriptionTemplate` varchar(512) CHARACTER SET utf8mb4 NULL,
        `Schema` longtext CHARACTER SET utf8mb4 NULL,
        `PushStrategy` int NOT NULL,
        `PushPlatform` varchar(512) CHARACTER SET utf8mb4 NULL,
        `ValidDays` int NOT NULL,
        `IsEnabled` tinyint(1) NOT NULL,
        CONSTRAINT `PK_Message_Type` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210712033251_DbInitMessageCenter') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20210712033251_DbInitMessageCenter', '5.0.7');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;
