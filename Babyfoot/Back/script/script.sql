CREATE TABLE status (
    id SERIAL PRIMARY KEY,
    code VARCHAR(5) NOT NULL UNIQUE,
    description TEXT
);

CREATE TABLE person (
    id SERIAL PRIMARY KEY,
    name VARCHAR(25) NOT NULL,
    first_name VARCHAR(25) NOT NULL,
    birthdate DATE NOT NULL,
    address VARCHAR(50) NOT NULL
);

CREATE TABLE person_monetary_flow (
    id SERIAL PRIMARY KEY,
    date_time TIMESTAMP NOT NULL,
    person_id INTEGER REFERENCES person(id),
    status_code VARCHAR(5) REFERENCES status(code),
    amount DOUBLE PRECISION NOT NULL
);

CREATE TABLE player (
    id SERIAL PRIMARY KEY,
    person_id INTEGER REFERENCES person(id),
    player_name VARCHAR(25) NOT NULL
);
ALTER TABLE player ADD CONSTRAINT unique_player UNIQUE (id, person_id);

CREATE TABLE team (
    id SERIAL PRIMARY KEY,
    name VARCHAR(25) NOT NULL
);

CREATE TABLE team_player (
    id SERIAL PRIMARY KEY,
    team_id INTEGER REFERENCES team(id),
    player_id INTEGER REFERENCES player(id)
);

CREATE TABLE baby_foot (
    id SERIAL PRIMARY KEY,
    owner INTEGER REFERENCES person(id)
);

CREATE TABLE baby_foot_token (
    id SERIAL PRIMARY KEY,
    baby_foot_id INTEGER REFERENCES baby_foot(id),
    name VARCHAR(25) NOT NULL,
    token_price DOUBLE PRECISION NOT NULL,
    ball_count INTEGER NOT NULL DEFAULT 0,
    start_date TIMESTAMP NOT NULL,
    end_date TIMESTAMP,
    check(ball_count >= 0 AND token_price >= 0),
    check(start_date < end_date)
);
ALTER TABLE baby_foot_token ADD CONSTRAINT unique_baby_foot_token UNIQUE (baby_foot_id, start_date);

CREATE TABLE baby_foot_match (
    id SERIAL PRIMARY KEY,
    baby_foot_id INTEGER REFERENCES baby_foot(id),
    match_date TIMESTAMP NOT NULL
);

CREATE TABLE baby_foot_match_details (
    id SERIAL PRIMARY KEY,
    baby_foot_match_id INTEGER REFERENCES baby_foot_match(id),
    team1 INTEGER REFERENCES team(id),
    score1 INTEGER NOT NULL,
    team2 INTEGER REFERENCES team(id),
    score2 INTEGER NOT NULL,
    check(score1 >= 0 AND score2 >= 0 AND score1 != score2)
);