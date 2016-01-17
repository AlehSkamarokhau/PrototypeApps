use daycalc100;

DROP TABLE IF EXISTS `app_configuration`;

CREATE TABLE app_configuration (
                pk_app_configuration_id INT AUTO_INCREMENT NOT NULL,
                key_configuration VARCHAR(100) NOT NULL,
                value_configuration VARCHAR(100) NOT NULL,
                PRIMARY KEY (pk_app_configuration_id)
);

DROP TABLE IF EXISTS `lucky_day`;

CREATE TABLE lucky_day (
                pk_lucky_day_id INT AUTO_INCREMENT NOT NULL,
                name_user VARCHAR(25) NOT NULL,
                lucky_date VARCHAR(25) NOT NULL,
                description VARCHAR(250) NOT NULL,
                PRIMARY KEY (pk_lucky_day_id)
);