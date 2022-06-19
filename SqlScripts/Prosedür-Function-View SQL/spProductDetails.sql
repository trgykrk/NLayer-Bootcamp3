CREATE PROCEDURE sp_ProductDetails
AS
SELECT
ISNULL(PR.Code,'') AS 'StockCode',
ISNULL(PR.Name,'') AS 'StockName' ,
ISNULL(CT.Name,'') AS 'CategoryName',
ISNULL(PF.Color,'') AS 'Color',
PR.Price AS 'Price' ,
PF.Widht ,
PF.Height FROM Products PR WITH(NOLOCK) 
LEFT JOIN dbo.Categories CT WITH(NOLOCK) ON CT.Id = PR.CategoryId
LEFT JOIN ProductFeatures PF WITH(NOLOCK) ON PR.Id=PF.Id



EXEC dbo.sp_ProductDetails
