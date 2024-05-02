CREATE DATABASE ZooDB;
CREATE TABLE Family (
    FamilyID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255),
    Continent NVARCHAR(255),
    Habitat NVARCHAR(255)
);


CREATE TABLE Type (
    TypeID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255),
    DailyFeedIntake DECIMAL(10,2),
    FamilyID INT,
    FOREIGN KEY (FamilyID) REFERENCES Family(FamilyID)
);
CREATE TABLE Accommodation (
    AccommodationID INT PRIMARY KEY IDENTITY,
    TypeID INT,
    AmountOfAnimals INT,
    FOREIGN KEY (TypeID) REFERENCES Type(TypeID)
);
CREATE TABLE Placement (
    PlacementID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255),
    NoOfPlacement INT,
    PresenceOfReservoir BIT,
    PresenceOfHeating BIT,
    AccommodationID INT,
    FOREIGN KEY (AccommodationID) REFERENCES Accommodation(AccommodationID)
);
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(255),
    LastName NVARCHAR(255),
    Role BIT,  -- 0 for Hired, 1 for Permanent
    Department NVARCHAR(255),
    Picture VARBINARY(MAX)
);

CREATE TABLE VeterinaryRecord (
    RecordID INT PRIMARY KEY IDENTITY,
    AnimalID INT,
    StaffID INT,
    TreatmentDate DATE,
    Diagnosis NVARCHAR(255),
    Treatment NVARCHAR(255),
    FOREIGN KEY (AnimalID) REFERENCES Accommodation(AccommodationID),
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);
CREATE TABLE VisitorInteraction (
    InteractionID INT PRIMARY KEY IDENTITY,
    VisitorID INT,
    PlacementID INT,
    InteractionDate DATE,
    Comments TEXT,
    FOREIGN KEY (PlacementID) REFERENCES Placement(PlacementID)
);
CREATE TABLE FoodSupply (
    SupplyID INT PRIMARY KEY IDENTITY,
    TypeID INT,
    QuantityInStock INT,
    LastDeliveryDate DATE,
    FOREIGN KEY (TypeID) REFERENCES Type(TypeID)
);

CREATE table authorize (
    id INT PRIMARY KEY IDENTITY,
    "login" NVARCHAR(25) not null,
    "password" NVARCHAR(255) not null
);


INSERT INTO Family (Title, Continent, Habitat) VALUES
('Lion', 'Africa', 'Grasslands'),
('Tiger', 'Asia', 'Forests'),
('Elephant', 'Africa', 'Savannah'),
('Giraffe', 'Africa', 'Savannah'),
('Panda', 'Asia', 'Mountains'),
('Kangaroo', 'Australia', 'Grasslands'),
('Bear', 'North America', 'Forests'),
('Hippo', 'Africa', 'Rivers'),
('Penguin', 'Antarctica', 'Ice'),
('Wolf', 'North America', 'Forests'),
('Fox', 'Europe', 'Forests'),
('Eagle', 'Worldwide', 'Mountains'),
('Koala', 'Australia', 'Forests'),
('Crocodile', 'Australia', 'Rivers'),
('Monkey', 'Asia', 'Forests'),
('Zebra', 'Africa', 'Grasslands'),
('Rhino', 'Africa', 'Grasslands'),
('Polar Bear', 'Arctic', 'Ice'),
('Orangutan', 'Asia', 'Forests'),
('Dolphin', 'Worldwide', 'Oceans'),
('Whale', 'Worldwide', 'Oceans'),
('Shark', 'Worldwide', 'Oceans'),
('Octopus', 'Worldwide', 'Oceans'),
('Gorilla', 'Africa', 'Forests');

INSERT INTO Type (Title, DailyFeedIntake, FamilyID) VALUES
('African Lion', 7.5, 26), 
('Siberian Tiger', 9.0, 27), 
('African Elephant', 150.0, 28), 
('Masai Giraffe', 75.0, 5), 
('Giant Panda', 20.0, 4), 
('Red Kangaroo', 4.0, 6), 
('Grizzly Bear', 30.0, 7), 
('Common Hippo', 35.0, 8), 
('Emperor Penguin', 5.0, 9), 
('Gray Wolf', 5.0, 10),
('Red Fox', 3.0, 11), 
('Bald Eagle', 0.5, 12),
('Koala Bear', 1.0, 13), 
('Saltwater Crocodile', 20.0, 14), 
('Bornean Orangutan', 5.0, 20), 
('Common Zebra', 20.0, 16), 
('White Rhino', 35.0, 17), 
('Polar Bear', 50.0, 18), 
('Mountain Gorilla', 18.0, 25); 

INSERT INTO Accommodation (TypeID, AmountOfAnimals) VALUES
(19, 10),
(20, 8),
(21, 15),
(22, 20),
(23, 5),
(21, 30),
(7, 12),
(8, 10),
(9, 50),
(10, 25),
(11, 20),
(12, 2),
(13, 15),
(14, 10),
(20, 8),
(16, 25),
(17, 15),
(18, 5),
(25, 10);

INSERT INTO Placement (Name, NoOfPlacement, PresenceOfReservoir, PresenceOfHeating, AccommodationID) VALUES
('Placement 1', 5, 1, 0, 21),
('Placement 2', 4, 1, 1, 22),
('Placement 3', 10, 0, 1, 23),
('Placement 4', 15, 1, 0, 4),
('Placement 5', 3, 0, 0, 5),
('Placement 6', 20, 1, 1, 6),
('Placement 7', 8, 1, 0, 7),
('Placement 8', 5, 0, 1, 8),
('Placement 9', 25, 1, 1, 24),
('Placement 10', 12, 0, 0, 26),
('Placement 11', 15, 0, 1, 27),
('Placement 12', 2, 0, 0, 28),
('Placement 13', 10, 1, 1, 29),
('Placement 14', 8, 1, 0, 30),
('Placement 15', 5, 0, 1, 16),
('Placement 16', 20, 1, 1, 17),
('Placement 17', 5, 1, 0, 18),
('Placement 18', 10, 0, 1, 20),
('Placement 19', 3, 1, 0, 16),
('Placement 20', 15, 0, 0, 25);

INSERT INTO Staff (FirstName, LastName, Role, Department) VALUES
('John', 'Doe', 1, 'HR'),
('Jane', 'Smith', 0, 'Finance'),
('Michael', 'Johnson', 0, 'Marketing'),
('Emily', 'Brown', 1, 'Operations'),
('David', 'Williams', 0, 'IT'),
('Sarah', 'Jones', 1, 'HR'),
('Christopher', 'Davis', 0, 'Finance'),
('Jessica', 'Miller', 1, 'Marketing'),
('Daniel', 'Wilson', 0, 'Operations'),
('Ashley', 'Taylor', 1, 'IT'),
('Matthew', 'Anderson', 0, 'HR'),
('Elizabeth', 'Thomas', 1, 'Finance'),
('Andrew', 'Jackson', 0, 'Marketing'),
('Olivia', 'White', 1, 'Operations'),
('William', 'Harris', 0, 'IT');

INSERT INTO VeterinaryRecord (AnimalID, StaffID, TreatmentDate, Diagnosis, Treatment) VALUES
(3, 1, '2024-04-01', 'Infection', 'Antibiotics'),
(4, 2, '2024-04-02', 'Fracture', 'Surgery'),
(5, 3, '2024-04-03', 'Digestive issue', 'Medication'),
(6, 4, '2024-04-04', 'Respiratory infection', 'Antibiotics'),
(22, 5, '2024-04-05', 'Injury', 'Bandaging'),
(21, 6, '2024-04-06', 'Allergic reaction', 'Medication'),
(7, 7, '2024-04-07', 'Parasitic infestation', 'Deworming'),
(8, 8, '2024-04-08', 'Dental problem', 'Extraction'),
(27, 9, '2024-04-09', 'Eye infection', 'Eye drops'),
(26, 10, '2024-04-10', 'Skin condition', 'Topical treatment');


INSERT INTO VisitorInteraction (VisitorID, PlacementID, InteractionDate, Comments) VALUES
(11, 1, '2024-04-01', 'Visitor enjoyed seeing the lions.'),
(2, 2, '2024-04-02', 'Visitor asked about feeding times for tigers.'),
(3, 3, '2024-04-03', 'Visitor interacted closely with the elephants.'),
(4, 11, '2024-04-04', 'Visitor observed the giraffes from a distance.'),
(5, 5, '2024-04-05', 'Visitor took photos of the pandas.'),
(6, 6, '2024-04-06', 'Visitor learned about kangaroo behavior.'),
(7, 7, '2024-04-07', 'Visitor was fascinated by the bears.'),
(8, 8, '2024-04-08', 'Visitor enjoyed watching the hippos swim.'),
(9, 9, '2024-04-09', 'Visitor attended a penguin feeding session.'),
(10, 10, '2024-04-10', 'Visitor interacted with wolves during a guided tour.');


SELECT AVG(Accommodation.AmountOfAnimals) AS AverageAreaPerMonkey
FROM Accommodation
JOIN Type ON Accommodation.TypeID = Type.TypeID
WHERE Type.Title = 'Monkey';

SELECT *
FROM Placement
WHERE NoOfPlacement < 3
AND AccommodationID IN (SELECT AccommodationID FROM Accommodation
                       JOIN Type ON Accommodation.TypeID = Type.TypeID
                       WHERE Type.Title = 'Crocodile');


SELECT SUM(Accommodation.AmountOfAnimals) AS TotalWolves
FROM Accommodation
JOIN Type ON Accommodation.TypeID = Type.TypeID
JOIN Family ON Type.FamilyID = Family.FamilyID
WHERE Family.Title = 'Wolf';


SELECT AVG(Type.DailyFeedIntake) AS DailyFeedIntake
FROM Type
WHERE Type.Title = 'Terrarium';

GO
CREATE PROCEDURE AddFamily
    @Title NVARCHAR(255),
    @Continent NVARCHAR(255),
    @Habitat NVARCHAR(255)
AS
BEGIN
    INSERT INTO Family (Title, Continent, Habitat)
    VALUES (@Title, @Continent, @Habitat);
END;
GO
CREATE PROCEDURE UpdateStaff
    @StaffID INT,
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @Role BIT,
    @Department NVARCHAR(255)
AS
BEGIN
    UPDATE Staff
    SET FirstName = @FirstName, LastName = @LastName, Role = @Role, Department = @Department
    WHERE StaffID = @StaffID;
END;
GO
CREATE TRIGGER trg_UpdateLastDelivery
ON FoodSupply
AFTER UPDATE
AS
BEGIN
    IF UPDATE(QuantityInStock)
    BEGIN
        UPDATE FoodSupply
        SET LastDeliveryDate = GETDATE()
        WHERE SupplyID IN (SELECT DISTINCT SupplyID FROM Inserted);
    END
END;




-- Добавление новой семьи
EXEC AddFamily @Title = N'Lion', @Continent = N'Africa', @Habitat = N'Savannah';

-- для совместного просмотра данных о типах и семьях животных:
GO
CREATE VIEW View_TypeFamilyDetails AS
SELECT 
    t.TypeID,
    t.Title AS TypeTitle,
    t.DailyFeedIntake,
    f.FamilyID,
    f.Title AS FamilyTitle,
    f.Continent,
    f.Habitat
FROM Type t
JOIN Family f ON t.FamilyID = f.FamilyID;
GO -- для отслеживания размещения животных:
CREATE VIEW View_AccommodationDetails AS 
SELECT 
    a.AccommodationID,
    t.Title AS TypeTitle,
    a.AmountOfAnimals,
    p.Name AS PlacementName,
    p.PresenceOfReservoir,
    p.PresenceOfHeating
FROM Accommodation a
JOIN Type t ON a.TypeID = t.TypeID
JOIN Placement p ON p.AccommodationID = a.AccommodationID;
GO -- для ветеринарных записей с информацией о сотрудниках:
CREATE VIEW View_VeterinaryRecordsWithStaff AS
SELECT 
    v.RecordID,
    a.Name AS AnimalName,
    s.FirstName + ' ' + s.LastName AS StaffName,
    v.TreatmentDate,
    v.Diagnosis,
    v.Treatment
FROM VeterinaryRecord v
JOIN Accommodation a ON v.AnimalID =
--для взаимодействий посетителей:
GO
CREATE VIEW View_VisitorInteractions AS
SELECT 
    vi.InteractionID,
    vi.VisitorID,
    p.Name AS PlacementName,
    vi.InteractionDate,
    vi.Comments
FROM VisitorInteraction vi
JOIN Placement p ON vi.PlacementID = p.PlacementID;
