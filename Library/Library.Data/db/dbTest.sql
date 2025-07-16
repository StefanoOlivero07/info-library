-- Verifies if there is a loan which is not terminated
SELECT *
FROM Loans l
WHERE l.Id = 2
AND DATEADD(DAY, 90, l.DateOfLoan) < GETDATE();

-- Returns booked books
SELECT bk.Id AS BookId, bk.Title, bk.AuthorId, bk.Year, bk.NationId, bk.LanguageId, Price, Pages
FROM Bookings bks
JOIN Books bk ON bks.BookId = bk.Id;