-- Languages
INSERT INTO Languages (Name) VALUES
('Italiano'),
('Inglese'),
('Francese'),
('Spagnolo'),
('Tedesco');

-- Nations
INSERT INTO Nations (Name) VALUES
('Italia'),
('Francia'),
('Spagna'),
('Germania'),
('Stati Uniti');

-- Genres
INSERT INTO Genres (Description) VALUES
('Romanzo'),
('Giallo'),
('Fantasy'),
('Thriller'),
('Storico');

-- Authors
INSERT INTO Authors (Name, Surname) VALUES
('Umberto', 'Eco'),
('George', 'Orwell'),
('J.K.', 'Rowling'),
('Stephen', 'King'),
('Isabel', 'Allende');

-- Users
INSERT INTO Users (DateOfBirth, Name, Surname, Email) VALUES
('1990-04-12', 'Marco', 'Rossi', 'marco.rossi@example.com'),
('1985-11-23', 'Laura', 'Bianchi', 'laura.bianchi@example.com'),
('1992-07-30', 'Luca', 'Verdi', 'luca.verdi@example.com'),
('1988-01-15', 'Anna', 'Neri', 'anna.neri@example.com'),
('1995-09-05', 'Paolo', 'Gialli', 'paolo.gialli@example.com');

-- Books
INSERT INTO Books (Title, AuthorId, Year, NationId, LanguageId, Price, Pages) VALUES
('Il Nome della Rosa', 1, 1980, 1, 1, 19, 500),
('1984', 2, 1949, 2, 2, 15, 328),
('Harry Potter e la Pietra Filosofale', 3, 1997, 3, 2, 12, 223),
('It', 4, 1986, 4, 2, 18, 1138),
('La Casa degli Spiriti', 5, 1982, 5, 3, 14, 481);
