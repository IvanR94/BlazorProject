BEGIN TRAN

CREATE TABLE Zaposleni
(
	ZaposleniID INT IDENTITY(1, 1) PRIMARY KEY,
	JMBG NVARCHAR(13),
	Ime NVARCHAR(20),
	Prezime NVARCHAR(50)
)

CREATE TABLE TipTehnickogPregleda
(
	TipTehnickogPregledaID INT PRIMARY KEY,
	NazivTehnickogPregleda NVARCHAR(50)
)

CREATE TABLE Vlasnik
(
	VlasnikID INT IDENTITY(1, 1) PRIMARY KEY,
	Ime NVARCHAR(20),
	Prezime NVARCHAR(50)
)

CREATE TABLE Vozilo
(
	VoziloID INT IDENTITY(1, 1) PRIMARY KEY,
	MarkaVozila NVARCHAR(30),
	ModelVozila NVARCHAR(30),
	Godiste INT,
	VlasnikID INT,
	FOREIGN KEY (VlasnikID) REFERENCES Vlasnik(VlasnikID)
)

CREATE TABLE IzvestajTehnickogPregleda
(
	BrojIzvestajaID INT IDENTITY(1, 1) PRIMARY KEY,
	DatumVrsenjaTehnickogPregleda DATETIME,
	StatusTehnickogPregleda BIT,
	Napomena NVARCHAR(MAX),
	ZaposleniID INT,
	TipTehnickogPregledaID INT,
	VoziloID INT,
	FOREIGN KEY (ZaposleniID) REFERENCES Zaposleni(ZaposleniID),
	FOREIGN KEY (TipTehnickogPregledaID) REFERENCES TipTehnickogPregleda(TipTehnickogPregledaID),
	FOREIGN KEY (VoziloID) REFERENCES Vozilo(VoziloID)
)

CREATE TABLE NeispravneStavke
(
	NeispravneStavkeID INT,
	BrojIzvestajaID INT,
	NazivNeispravnogDela NVARCHAR(MAX),
	OpisNeispravnosti NVARCHAR(MAX),
	CONSTRAINT PK_NeispravneStavke PRIMARY KEY(BrojIzvestajaID, NeispravneStavkeID)
)

ROLLBACK TRAN