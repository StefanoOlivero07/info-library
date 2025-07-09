-- Verify if there is a loan which is not terminated
SELECT *
FROM Loans l
WHERE l.Id = 2
AND DATEADD(DAY, 90, l.DateOfLoan) < GETDATE();