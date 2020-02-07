
DROP PROCEDURE GetSearchKeywordMatchedItems
GO
CREATE PROCEDURE GetSearchKeywordMatchedItems  
    @SearchKeyword nvarchar(10) 
AS
BEGIN
    SET NOCOUNT ON;  

	SELECT b.Name [MatchedItem]
	FROM  SearchKeyword a WITH (READUNCOMMITTED)
				left join SearchKeywordMatch b WITH (READUNCOMMITTED) on a.Id = b.SearchKeywordId
	WHERE a.Name = @SearchKeyword

END  
GO 


