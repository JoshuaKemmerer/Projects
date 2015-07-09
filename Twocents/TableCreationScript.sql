-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema basetwo
-- -----------------------------------------------------
-- Database for twocents.com

-- -----------------------------------------------------
-- Schema basetwo
--
-- Database for twocents.com
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `basetwo` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `basetwo` ;

-- -----------------------------------------------------
-- Table `basetwo`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `username` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`sourceTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`sourceTypes` (
  `sourceTypeId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(45) NOT NULL COMMENT 'user, website, admin(?)',
  PRIMARY KEY (`sourceTypeId`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`commentSources`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`commentSources` (
  `commentSourceId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `typeId` INT NOT NULL COMMENT 'user, original website, other website',
  `sourceId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`commentSourceId`)  COMMENT '',
  INDEX `fk_commentSources_sourceTypes_idx` (`typeId` ASC)  COMMENT '',
  CONSTRAINT `fk_commentSources_sourceTypes`
    FOREIGN KEY (`typeId`)
    REFERENCES `basetwo`.`sourceTypes` (`sourceTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`flagTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`flagTypes` (
  `flagTypeId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `description` VARCHAR(64) NOT NULL COMMENT 'This should be a short, and meaningful, description of the flag',
  `creatorId` INT NOT NULL COMMENT 'userId of creator',
  PRIMARY KEY (`flagTypeId`)  COMMENT '',
  INDEX `fk_flagTypes_users_idx` (`creatorId` ASC)  COMMENT '',
  CONSTRAINT `fk_flagTypes_users`
    FOREIGN KEY (`creatorId`)
    REFERENCES `basetwo`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`commentFlags`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`commentFlags` (
  `commentFlagId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `flagTypeId` INT NOT NULL COMMENT '',
  `creatorId` INT NOT NULL COMMENT 'userId of flag creator',
  `details` VARCHAR(512) NOT NULL COMMENT '',
  `creationDate` DATETIME NOT NULL COMMENT '',
  PRIMARY KEY (`commentFlagId`)  COMMENT '',
  INDEX `fk_commentFlags_users_idx` (`creatorId` ASC)  COMMENT '',
  INDEX `fk_commentFlags_flagTypes_idx` (`flagTypeId` ASC)  COMMENT '',
  CONSTRAINT `fk_commentFlags_users`
    FOREIGN KEY (`creatorId`)
    REFERENCES `basetwo`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_commentFlags_flagTypes`
    FOREIGN KEY (`flagTypeId`)
    REFERENCES `basetwo`.`flagTypes` (`flagTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`accessTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`accessTypes` (
  `accessTypeId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(32) NOT NULL COMMENT '',
  `description` VARCHAR(64) NOT NULL COMMENT '',
  PRIMARY KEY (`accessTypeId`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`comments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`comments` (
  `commentId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `accessTypeId` INT NOT NULL COMMENT '',
  `parentId` INT NULL COMMENT '',
  `sourceId` INT NOT NULL COMMENT '',
  `body` VARCHAR(10000) NOT NULL COMMENT '',
  `postDate` DATETIME NOT NULL COMMENT '',
  `flagId` INT NULL COMMENT '',
  PRIMARY KEY (`commentId`)  COMMENT '',
  INDEX `fk_comments_commentSources_idx` (`sourceId` ASC)  COMMENT '',
  INDEX `fk_comments_commentFlags1_idx` (`flagId` ASC)  COMMENT '',
  INDEX `fk_comments_accessTypes_idx` (`accessTypeId` ASC)  COMMENT '',
  CONSTRAINT `fk_comments_commentSources`
    FOREIGN KEY (`sourceId`)
    REFERENCES `basetwo`.`commentSources` (`commentSourceId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comments_commentFlags`
    FOREIGN KEY (`flagId`)
    REFERENCES `basetwo`.`commentFlags` (`commentFlagId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comments_accessTypes`
    FOREIGN KEY (`accessTypeId`)
    REFERENCES `basetwo`.`accessTypes` (`accessTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`webpage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`webpage` (
  `webpageId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `url` VARCHAR(2083) NOT NULL COMMENT '',
  PRIMARY KEY (`webpageId`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`webpageComments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`webpageComments` (
  `webpageCommentId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `webpageId` INT NOT NULL COMMENT '',
  `commentId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`webpageCommentId`)  COMMENT '',
  INDEX `fk_webpageComments_comments_idx` (`commentId` ASC)  COMMENT '',
  INDEX `fk_webpageComments_webpages_idx` (`webpageId` ASC)  COMMENT '',
  CONSTRAINT `fk_webpageComments_comments`
    FOREIGN KEY (`commentId`)
    REFERENCES `basetwo`.`comments` (`commentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_webpageComments_webpages`
    FOREIGN KEY (`webpageId`)
    REFERENCES `basetwo`.`webpage` (`webpageId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = '	';


-- -----------------------------------------------------
-- Table `basetwo`.`websites`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`websites` (
  `websiteId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(64) NOT NULL COMMENT '',
  PRIMARY KEY (`websiteId`)  COMMENT '',
  UNIQUE INDEX `name_UNIQUE` (`name` ASC)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`voteTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`voteTypes` (
  `voteTypeId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(10) NOT NULL COMMENT 'agree/disagree, relevant/irrelevant, sponsored/unsponsored',
  `description` VARCHAR(64) NOT NULL COMMENT '',
  PRIMARY KEY (`voteTypeId`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`commentRatings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`commentRatings` (
  `commentRatingId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `rating` INT NOT NULL COMMENT '',
  `commentId` INT NOT NULL COMMENT '',
  `voteTypeId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`commentRatingId`)  COMMENT '',
  INDEX `fk_commentRating_comments_idx` (`commentId` ASC)  COMMENT '',
  INDEX `fk_commentRating_voteTypes_idx` (`voteTypeId` ASC)  COMMENT '',
  CONSTRAINT `fk_commentRating_comments`
    FOREIGN KEY (`commentId`)
    REFERENCES `basetwo`.`comments` (`commentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_commentRating_voteTypes`
    FOREIGN KEY (`voteTypeId`)
    REFERENCES `basetwo`.`voteTypes` (`voteTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`votes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`votes` (
  `voteId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `voteTypeId` INT NOT NULL COMMENT '',
  `userId` INT NOT NULL COMMENT '',
  `commentId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`voteId`)  COMMENT '',
  INDEX `fk_votes_users_idx` (`userId` ASC)  COMMENT '',
  INDEX `fk_votes_voteTypes_idx` (`voteTypeId` ASC)  COMMENT '',
  INDEX `fk_votes_comments_idx` (`commentId` ASC)  COMMENT '',
  CONSTRAINT `fk_votes_users`
    FOREIGN KEY (`userId`)
    REFERENCES `basetwo`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_votes_voteTypes`
    FOREIGN KEY (`voteTypeId`)
    REFERENCES `basetwo`.`voteTypes` (`voteTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_votes_comments`
    FOREIGN KEY (`commentId`)
    REFERENCES `basetwo`.`comments` (`commentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `basetwo`.`edits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`edits` (
  `editId` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `commentId` INT NOT NULL COMMENT '',
  `changes` VARCHAR(5000) NULL COMMENT '',
  `reason` VARCHAR(64) NULL COMMENT '',
  `date` DATETIME NOT NULL COMMENT '',
  PRIMARY KEY (`editId`)  COMMENT '',
  INDEX `fk_edits_comments1_idx` (`commentId` ASC)  COMMENT '',
  CONSTRAINT `fk_edits_comments1`
    FOREIGN KEY (`commentId`)
    REFERENCES `basetwo`.`comments` (`commentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `basetwo` ;

-- -----------------------------------------------------
-- Placeholder table for view `basetwo`.`commentsMasterView`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `basetwo`.`commentsMasterView` (`commentId` INT, `accessTypeId` INT, `parentId` INT, `sourceId` INT, `body` INT, `postDate` INT, `flagId` INT, `rating` INT, `voteType` INT, `voteTypeDescription` INT, `sourceTypeName` INT, `editDate` INT, `accessTypeName` INT);

-- -----------------------------------------------------
-- View `basetwo`.`commentsMasterView`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `basetwo`.`commentsMasterView`;
USE `basetwo`;
CREATE  OR REPLACE VIEW `commentsMasterView` AS
    SELECT 
        comments.*,
        commentRatings.rating AS rating,
        voteTypes.name AS voteType,
        voteTypes.description AS voteTypeDescription,
        sourceTypes.name AS sourceTypeName,
        edits.date AS editDate,
        accessTypes.name AS accessTypeName
    FROM
        comments
            JOIN
        commentRatings ON commentRatings.commentId = comments.commentId
            JOIN
        voteTypes ON voteTypes.voteTypeId = commentRatings.voteTypeId
            JOIN
        commentSources ON commentSources.commentSourceId = comments.sourceid
            JOIN
        sourceTypes ON sourceTypes.sourceTypeId = commentSources.typeid
            JOIN
        edits ON edits.commentId = comments.commentId
			JOIN
		accessTypes ON accessTypes.accessTypeId = comments.accessTypeId;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
