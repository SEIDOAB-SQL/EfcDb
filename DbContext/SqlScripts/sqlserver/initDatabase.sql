USE [efc-friends];
GO


IF SUSER_ID (N'usr') IS NULL
    CREATE LOGIN usr WITH PASSWORD=N'pa$Word1', 
        DEFAULT_DATABASE=[efc-friends], DEFAULT_LANGUAGE=us_english, 
        CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;

IF SUSER_ID (N'dbo') IS NULL
    CREATE LOGIN dbo WITH PASSWORD=N'pa$Word1', 
        DEFAULT_DATABASE=[efc-friends], DEFAULT_LANGUAGE=us_english, 
        CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;

--create users
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'usrUser' AND type = 'S')
    CREATE USER usrUser FROM LOGIN usr;
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'dboUser' AND type = 'S')
    CREATE USER dboUser FROM LOGIN dbo;

--create roles
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'usrRole' AND type = 'R')
    CREATE ROLE usrRole;

-- Grant role privileges (adjust as needed)
GRANT SELECT to usrRole;

-- Grant full privileges to dboRole using built-in db_owner role
ALTER ROLE db_owner ADD MEMBER dboUser;
ALTER ROLE usrRole ADD MEMBER usrUser;

GO


