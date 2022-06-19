--Ekleme iþlemi
INSERT INTO dbo.Categories(Name)
VALUES
('Beyaz Eþya'),
('Halý'),
('Elektronik Aletler'),
('Giyim'),
('Spor');

--Ekleme  iþlemi
INSERT INTO Products (Code,Name,Price,CategoryId)
VALUES
('P0001','Buzdolabý',5100,1),
('P0002','Dokuma Kilim',1510,2),
('P0003','Monitör',4500,3),
('P0004','Gömlek',100,4),
('P0005','Bar',1500,5);

--Ekleme  iþlemi
INSERT INTO ProductFeatures (Id,Color,Widht,Height)
VALUES
(1,'Beyaz',100,400),
(4,'Kýrmýzý',50,100),
(5,'Beyaz',10,0);


--Güncelleme Ýþlemi
UPDATE dbo.Products SET Name = 'Cam' WHERE Id = 5

--Silme Ýþlemi 
DELETE FROM dbo.ProductFeatures WHERE Id = 5

--Okuma  Ýþlemleri
SELECT * FROM dbo.Categories 
SELECT * FROM Products 
SELECT * FROM ProductFeatures 

