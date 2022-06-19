--view Oluþturma
CREATE VIEW vw_ProductDetails
AS
SELECT PR.*,ISNULL(CT.Name,'') AS 'Category',ISNULL(PF.Color,'') AS 'Color' FROM Products PR WITH(NOLOCK)
LEFT JOIN Categories CT WITH(NOLOCK) ON CT.Id = PR.CategoryId 
LEFT JOIN ProductFeatures PF WITH(NOLOCK) ON PR.Id=PF.Id


SELECT * FROM vw_ProductDetails


