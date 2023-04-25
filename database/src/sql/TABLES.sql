DROP DATABASE dreamteam_data;

CREATE DATABASE dreamteam_data;

USE dreamteam_data;

CREATE TABLE CountryCodes (
    code VARCHAR(3) PRIMARY KEY,
    name VARCHAR(64) UNIQUE
);

CREATE TABLE GDPPerCapita (
    country VARCHAR(3),
    year INT(4),
    GDPPC FLOAT(18,6),

    PRIMARY KEY (country, year),

    FOREIGN KEY (country) REFERENCES CountryCodes(code)

);