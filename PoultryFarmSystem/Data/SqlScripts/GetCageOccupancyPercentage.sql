USE PoultryFarm
GO

CREATE OR ALTER PROCEDURE GetCageOccupancyPercentage
    @CageId INT
AS
BEGIN
    DECLARE @BirdsCount INT;
    DECLARE @Capacity INT;
    DECLARE @OccupancyPercentage INT;
    
    SELECT @BirdsCount = COUNT(*) 
    FROM Birds 
    WHERE CageId = @CageId;
    
    SELECT @Capacity = Capacity 
    FROM Cages 
    WHERE Id = @CageId;
    
    IF @Capacity > 0
        SET @OccupancyPercentage = (@BirdsCount * 100) / @Capacity;
    ELSE
        SET @OccupancyPercentage = 0;
    
    SELECT @OccupancyPercentage AS OccupancyPercentage;
END
GO