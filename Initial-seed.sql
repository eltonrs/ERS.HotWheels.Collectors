use HTCollectors

SELECT * FROM Brand
SELECT * FROM ToyCar
SELECT * FROM Collection
SELECT * FROM WheelType

SELECT NEWID()

SELECT [tc].[Name] AS [ToyCarName], [c].[Name] AS [CollectionName] FROM [Collection] AS [c]
INNER JOIN [ToyCar] AS [tc] ON [tc].[CollectionId] = [c].[Id]

SELECT [tc].[Name] AS [ToyCarName], [c].[Name] AS [CollectionName]
FROM [dbo].[Collection] AS [c]
INNER JOIN [dbo].[ToyCar] AS [tc] ON [tc].[CollectionId] = [c].[Id]

SELECT [tc].[Name] AS [ToyCarName], [c].[Name] AS [CollectionName] FROM [dbo].[Collection] AS [c]
INNER JOIN [dbo].[ToyCar] AS [tc] ON [tc].[CollectionId] = [c].[Id]


/* SEED */

DECLARE
	@BrandMega UNIQUEIDENTIFIER = '8E75F107-E8E6-4C75-A24F-3DE195ED426D',
	@BrandSuper UNIQUEIDENTIFIER = 'A81DB23C-B4E1-4EDD-A25F-70DA8B827C57',
	@BrandFire UNIQUEIDENTIFIER = 'E694848B-4A38-48DB-85CC-215FAE085195',
	@BrandHotters UNIQUEIDENTIFIER = '01BECEE5-4C88-4D0E-AC88-6C76F7295846',
	
	@WheelTypeDefault UNIQUEIDENTIFIER = '25F44A2C-4E81-4914-9408-CFE45A1963D6',
	@WheelTypeStar UNIQUEIDENTIFIER = 'A8B96D12-D321-4E12-883A-EA5B38D1CD32',
	
	@CollectionRoadHot UNIQUEIDENTIFIER = 'C2AEA6B6-31CB-483B-8AC3-C47B7CB7ACCF',
	@CollectionDriftters UNIQUEIDENTIFIER = '5511104F-0ACA-45EE-905F-AEAFEE95260F';


INSERT INTO Brand (Id, Name)
VALUES
	(@BrandMega, 'Mega'),
	(@BrandSuper, 'Super'),
	(@BrandFire, 'Fire'),
	(@BrandHotters, 'Hotters');

INSERT INTO Collection (Id, Name, ReleaseDate, EndDate, TotalToyCar)
VALUES
	(@CollectionRoadHot, 'Road Hot', DATEADD(YEAR, -3, GETDATE()), DATEADD(YEAR, -1, GETDATE()), 23),
	(@CollectionDriftters, 'Driftters', DATEADD(YEAR, -10, GETDATE()), NULL, 67)

INSERT INTO WheelType (Id, LetterCode, DescriptionType, Notes)
VALUES
	(@WheelTypeDefault, '1', 'Default', 'Simple e most used in all world'),
	(@WheelTypeStar, '2', 'Start', 'Five point star')


INSERT INTO ToyCar (Id, Name, ReleaseYear, BrandID, CollectionIndex, Tampography, WheelTypeId, CollectionId)
VALUES
	(NEWID(), 'Car One', DATEADD(YEAR, -3, GETDATE()), @BrandMega, 1, NULL, @WheelTypeDefault, @CollectionRoadHot),
	(NEWID(), 'Car Two', DATEADD(YEAR, -7, GETDATE()), @BrandMega, 2, NULL, @WheelTypeDefault, @CollectionRoadHot),
	(NEWID(), 'Car Three', DATEADD(YEAR, -1, GETDATE()), @BrandFire, 1, NULL, @WheelTypeStar, @CollectionDriftters),
	(NEWID(), 'Car Four'	, DATEADD(YEAR, -7, GETDATE()), @BrandHotters, 2, NULL, @WheelTypeDefault, @CollectionDriftters);


SELECT COUNT(*) AS Qtde
FROM [ToyCar] AS [tc]
INNER JOIN [Collection] AS [c] ON [tc].[CollectionId] = [c].[Id] WHERE [tc].[CollectionId] = 'C2AEA6B6-31CB-483B-8AC3-C47B7CB7ACCF'