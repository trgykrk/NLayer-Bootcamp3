--Ekleme i�lemi
INSERT INTO dbo.Categories(Name)
VALUES
('Beyaz E�ya'),
('Hal�'),
('Elektronik Aletler'),
('Giyim'),
('Spor');

--Ekleme  i�lemi
INSERT INTO Products (Code,Name,Price,CategoryId)
VALUES
('P0001','Buzdolab�',5100,1),
('P0002','Dokuma Kilim',1510,2),
('P0003','Monit�r',4500,3),
('P0004','G�mlek',100,4),
('P0005','Bar',1500,5);

--Ekleme  i�lemi
INSERT INTO ProductFeatures (Id,Color,Widht,Height)
VALUES
(1,'Beyaz',100,400),
(4,'K�rm�z�',50,100),
(5,'Beyaz',10,0);


--G�ncelleme ��lemi
UPDATE dbo.Products SET Name = 'Cam' WHERE Id = 5

--Silme ��lemi 
DELETE FROM dbo.ProductFeatures WHERE Id = 5

--Okuma  ��lemleri
SELECT * FROM dbo.Categories 
SELECT * FROM Products 
SELECT * FROM ProductFeatures 

