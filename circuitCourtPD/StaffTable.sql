﻿CREATE TABLE [dbo].[StaffTable]
(
	[USERNAME] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [FIRSTNAME] VARCHAR(50) NULL, 
    [LASTNAME] VARCHAR(50) NULL, 
    [EMAIL] VARCHAR(50) NULL, 
    CONSTRAINT [USERNAMEKEY] FOREIGN KEY ([USERNAME]) REFERENCES [LoginTable]([USERNAME])
)
