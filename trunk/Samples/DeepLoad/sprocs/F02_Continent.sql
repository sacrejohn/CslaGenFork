/****** Object:  StoredProcedure [AddF02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF02_Continent]
GO

CREATE PROCEDURE [AddF02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateF02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF02_Continent]
GO

CREATE PROCEDURE [UpdateF02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF02_Continent]
GO

CREATE PROCEDURE [DeleteF02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F04_SubContinent as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F03_Continent_ReChild as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F03_Continent_Child as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark F02_Continent object as not active */
        UPDATE [1_Continents]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
