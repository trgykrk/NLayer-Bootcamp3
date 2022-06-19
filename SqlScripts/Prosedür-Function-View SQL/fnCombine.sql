--Function Oluþturma
CREATE Function fn_Combine(@Code Nvarchar(20),@Name Nvarchar(30))
Returns Nvarchar(51)
As
Begin
Return @Code + Space(1)+ @Name
END




SELECT dbo.fn_Combine('TURGAY','KARAKOC')