BEGIN TRAN

INSERT INTO TipTehnickogPregleda
(
	TipTehnickogPregledaID,
	NazivTehnickogPregleda
)
VALUES
(
	1,
	N'Redovni godisnji'
)
INSERT INTO TipTehnickogPregleda
(
	TipTehnickogPregledaID,
	NazivTehnickogPregleda
)
VALUES
(
	2,
	N'Redovni sestomesecni'
)
INSERT INTO TipTehnickogPregleda
(
	TipTehnickogPregledaID,
	NazivTehnickogPregleda
)
VALUES
(
	3,
	N'Vanredni'
)
INSERT INTO TipTehnickogPregleda
(
	TipTehnickogPregledaID,
	NazivTehnickogPregleda
)
VALUES
(
	4,
	N'Kontrolni tehnicki pregled'
)

INSERT INTO Zaposleni
(
	Ime,
	Prezime,
	JMBG
)
VALUES
(
	N'Ime1',
	N'Prezime1',
	N'1111111111111'
)

INSERT INTO Zaposleni
(
	Ime,
	Prezime,
	JMBG
)
VALUES
(
	N'Ime2',
	N'Prezime2',
	N'2222222222222'
)

INSERT INTO Zaposleni
(
	Ime,
	Prezime,
	JMBG
)
VALUES
(
	N'Ime3',
	N'Prezime3',
	N'3333333333333'
)

SELECT * FROM IzvestajTehnickogPregleda
SELECT * FROM NeispravneStavke
SELECT * FROM TipTehnickogPregleda
SELECT * FROM Vlasnik
SELECT * FROM Vozilo
SELECT * FROM Zaposleni

ROLLBACK TRAN

DBCC CHECKIDENT ('Zaposleni', RESEED, 0)