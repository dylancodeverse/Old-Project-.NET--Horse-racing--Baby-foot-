CREATE VIEW latest_people_money AS
    SELECT
        person_id,
        SUM(amount) as money
    FROM
        person_monetary_flow
    GROUP BY
        person_id
;

CREATE VIEW people AS
    SELECT
        person.*,
        latest_people_money.money
    FROM
        person
    JOIN
        latest_people_money
    ON
        person.id = latest_people_money.person_id
;
