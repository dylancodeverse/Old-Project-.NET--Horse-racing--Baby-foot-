-- Table "horse"
CREATE TABLE horse (
  horseId INT  PRIMARY KEY auto_increment,
  horseNumber INT,
  horseVitess DECIMAL(10,2)
);
--  Table "horse_endurance"

CREATE Table horse_endurance(
  horseenduranceId int PRIMARY key auto_increment ,
  horseId int REFERENCES horse(horseId) ,
  percentageLimit DECIMAL(5,2)
);

CREATE VIEW V_resJoinHorse AS
  SELECT horse.horseId, horse_endurance.percentageLimit
  FROM horse
  JOIN horse_endurance ON horse.horseId = horse_endurance.horseId ;

CREATE VIEW V_FHorseInf as SELECT * from  V_resJoinHorse ORDER BY horseId , percentageLimit;



-- Table "people"
CREATE TABLE people (
  peopleId VARCHAR(50) PRIMARY KEY,
  peopleName VARCHAR(50)
);

-- Table "peopleMoneyPerDate"
CREATE TABLE peopleMoneyPerDate (
  peopleMoneyPerDateId INT PRIMARY KEY auto_increment,
  pMPD_peopleId VARCHAR(50) REFERENCES people(peopleId),
  pMPD_money DECIMAL(10,2),
  pMPD_date DATE
);

-- Table "rule"
CREATE TABLE rule (
  ruleId INT PRIMARY KEY auto_increment,
  bet DECIMAL(10,2),
  secondRule DECIMAL(10,2),
  added DECIMAL(10 ,2)
);

-- Table "match"
CREATE TABLE match_table (
  matchId INT PRIMARY KEY,
  matchName VARCHAR(50),
  ruleId INT REFERENCES rule(ruleId)
);

-- Table "horseInMatch"
CREATE TABLE horseInMatch (
  horseId INT PRIMARY KEY,
  matchId INT,
  FOREIGN KEY (horseId) REFERENCES horse(horseId),
  FOREIGN KEY (matchId) REFERENCES match_table(matchId)
);

CREATE TABLE match_info (
  match_infoID int PRIMARY key auto_increment ,
  horseId int REFERENCES horse(horseId) ,
  secondRecorded DECIMAL(5,2)
);


CREATE VIEW V_resJoinHorseInMatch AS
  SELECT hm.horseId, hm.matchId, mi.secondRecorded
  FROM horseInMatch hm
  JOIN match_info mi ON hm.horseId = mi.horseId;


CREATE VIEW V_finalJoin AS
SELECT j.horseId, h.horseNumber, h.horseVitess, j.matchId, j.secondRecorded
FROM V_resJoinHorseInMatch j
JOIN horse h ON j.horseId = h.horseId;


ALTER TABLE horse ENGINE = InnoDB;
ALTER TABLE people ENGINE = InnoDB;
ALTER TABLE peopleMoneyPerDate ENGINE = InnoDB;
ALTER TABLE horseInMatch ENGINE = InnoDB;
ALTER TABLE match_table ENGINE = InnoDB;
ALTER TABLE rule ENGINE = InnoDB;
ALTER table horse_endurance ENGINE = InnoDB ;
ALTER TABLE match_info ENGINE = InnoDB ;
