-- Create a sample database and table to demonstrate Window Functions
CREATE DATABASE CognizantTrainingDB;
GO
USE CognizantTrainingDB;
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10,2)
);

INSERT INTO Employees VALUES 
(1, 'mit', 'Sharma', 'IT', 85000.00),
(2, 'riya', 'Patel', 'IT', 95000.00),
(3, 'Rahul', 'Verma', 'HR', 60000.00),
(4, 'neha', 'Reddy', 'HR', 65000.00),
(5, 'Vikram', 'Singh', 'Finance', 105000.00),
(6, 'nanya', 'Das', 'Finance', 95000.00);
GO

-- --- RUNNING THE WINDOW FUNCTIONS QUERY ---
SELECT 
    EmployeeID,
    FirstName,
    Department,
    Salary,
    -- 1. ROW_NUMBER(): Unique sequential integer for rows within a partition
    ROW_NUMBER() OVER (PARTITION BY Department ORDER BY Salary DESC) AS RowNum,

    -- 2. RANK(): Ranks with gaps if duplicates exist
    RANK() OVER (PARTITION BY Department ORDER BY Salary DESC) AS DeptRank,

    -- 3. DENSE_RANK(): Ranks without any gaps
    DENSE_RANK() OVER (ORDER BY Salary DESC) AS OverallDenseRank,

    -- 4. Running Total using SUM() OVER()
    SUM(Salary) OVER (PARTITION BY Department ORDER BY EmployeeID) AS DeptRunningTotal
FROM Employees;
GO
