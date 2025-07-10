-- Verifies if there is a loan which is not terminated
SELECT *
FROM Loans l
WHERE l.Id = 2
AND DATEADD(DAY, 90, l.DateOfLoan) < GETDATE();

-- Returns booked books
SELECT bk.*
FROM Bookings bks
JOIN Books bk ON bks.BookId = bk.Id
GROUP BY bk.Id;