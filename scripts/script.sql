CREATE TABLE positions (
    positionid VARCHAR(50) NOT NULL,
    productid VARCHAR(50) NOT NULL,
    clientid VARCHAR(50) NOT NULL,
    date DATE NOT NULL,
    value NUMERIC(18, 2) NOT NULL,
    quantity NUMERIC(18, 2) NOT NULL,
    PRIMARY KEY (positionId, date)
);