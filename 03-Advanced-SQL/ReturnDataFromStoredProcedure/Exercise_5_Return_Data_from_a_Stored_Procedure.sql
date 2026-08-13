
CREATE PROCEDURE GetDepartmentMetrics
    @DeptName VARCHAR(50),
    @TotalSalaryBudget DECIMAL(10,2) OUTPUT, 
    @EmployeeCount INT OUTPUT                 
AS
BEGIN
    SET NOCOUNT ON;

    
    SELECT 
        @TotalSalaryBudget = ISNULL(SUM(Salary), 0),
        @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE Department = @DeptName;
END;
GO


DECLARE @BudgetOut DECIMAL(10,2);
DECLARE @CountOut INT;


EXEC GetDepartmentMetrics 
    @DeptName = 'Finance', 
    @TotalSalaryBudget = @BudgetOut OUTPUT, 
    @EmployeeCount = @CountOut OUTPUT;


SELECT 
    'Finance' AS DepartmentName,
    @BudgetOut AS TotalAllocatedBudget,
    @CountOut AS TotalActiveResources;
GO
