CREATE TABLE ProjectAssignments (
    AssignmentID INT PRIMARY KEY,
    EmployeeID INT,
    ProjectName VARCHAR(100),
    AllocationPercentage INT,
    Role VARCHAR(50)
);

INSERT INTO ProjectAssignments VALUES 
(1, 1, 'Cloud Migration', 100, 'Lead Architect'),
(2, 2, 'Cloud Migration', 50, 'Senior Developer'),
(3, 5, 'Financial Audit Automation', 100, 'Data Analyst');
GO

-- --- CREATING THE STORED PROCEDURE ---
CREATE PROCEDURE GetEmployeeProjectDetails
    @TargetDept VARCHAR(50) -- Input parameter to filter by department
AS
BEGIN
    -- Settling configuration for optimal execution performance
    SET NOCOUNT ON;

    SELECT 
        e.EmployeeID,
        CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
        e.Department,
        p.ProjectName,
        p.Role,
        p.AllocationPercentage
    FROM Employees e
    INNER JOIN ProjectAssignments p ON e.EmployeeID = p.EmployeeID
    WHERE e.Department = @TargetDept;
END;
GO

-- --- HOW TO EXECUTE IT ---
-- EXEC GetEmployeeProjectDetails @TargetDept = 'IT';
