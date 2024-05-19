-- database : mini_foot

CREATE TABLE person (
    person_id VARCHAR(30) primary key,
    person_name varchar(30) not null     
);

CREATE TABLE person_money(
    person_money_id int auto_increment primary key ,
    pm_person_id varchar(30) references person(person_id),
    pm_money float ,
    pm_date date  
);

CREATE TABLE rule (
    rule_id VARCHAR(20) PRIMARY KEY,
    r_nb_of_ball INT NOT NULL UNIQUE,
    r_money FLOAT DEFAULT 0
);


CREATE TABLE matches (
    match_id int auto_increment primary key ,
    match_ruleid varchar(30) references rule(rule_id),
    pari float default 0,
    match_date date not null
);

CREATE TABLE match_infoperson (
    match_infoperson_id int auto_increment primary key ,
    mm_match_id int references matches(match_id),
    person_id varchar(30) references person(person_id) ,
    score int default 0
);

ALTER TABLE person ENGINE = InnoDB;
ALTER TABLE person_money ENGINE = InnoDB;
ALTER TABLE rule ENGINE = InnoDB;
ALTER TABLE matches ENGINE = InnoDB;
ALTER TABLE match_infoperson ENGINE = InnoDB;

CREATE VIEW view_person_with_total_money AS
SELECT p.person_id, p.person_name, COALESCE(SUM(pm.pm_money), 0) AS total_money
FROM person p
LEFT JOIN person_money pm ON p.person_id = pm.pm_person_id
GROUP BY p.person_id, p.person_name;
