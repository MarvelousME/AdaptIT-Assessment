SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================
-- Author:		Marvin Saunders
-- Description:	Using CTE approach to pass in a name, 
--				then get the id of the employee
--				and lastly do the mapping query
--				against the manager id to create 
--				the hierarchy of the sub-ordinates
--				under the line manager's name that
--				was passed in.
-- ====================================================

CREATE FUNCTION GetLineManagerHierarchy
(
    @EmployeeName varchar(20)
)
RETURNS TABLE
AS
RETURN  
(
	 WITH ManagerCTE 
	 AS 
	 ( 
			SELECT Id, Name, ManagerId, 0 AS ManagerLevel
			FROM Employees where Name  = @EmployeeName 
    
			UNION ALL
  
			SELECT employee.Id, employee.Name, employee.ManagerId, manager.[ManagerLevel]+1
			FROM Employees AS employee 	INNER JOIN ManagerCTE AS manager
			ON employee.ManagerId = manager.Id 
			WHERE employee.ManagerId IS NOT NULL
			
	)

	SELECT	Name			[Manager],
			ManagerId		[Manager's Id],
			[ManagerLevel]	[Level]
	FROM ManagerCTE 
  )
GO