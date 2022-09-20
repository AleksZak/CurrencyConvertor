USE CurrencyConvertor;

INSERT INTO Currencies(Name,Code,IsActive)
VALUES('Ukrainian hrivna', 'UAH',1),('American Dollar','USD',1),('Euro', 'EUR',1);

INSERT INTO CurrencyRates(CurrencyId,TargetCode,RateDate,RateValue) 
VALUES(1,'USD','2022-01-01',0.027),(1,'EUR','2022-01-01',0.030),(2,'UAH','2022-01-01',27)
,(2,'EUR','2022-01-01',0.85),(3,'UAH','2022-01-01',30),(3,'USD','2022-01-01',1.18);


