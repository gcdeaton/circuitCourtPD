﻿CREATE TABLE [dbo].[CaseTable]
(
	[CASENUMBER] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [USERNAME] VARCHAR(40) NULL, 
    [DATEOF] VARCHAR(50) NULL, 
    [CASETYPE] VARCHAR(50) NULL, 
    [LITIGANT] VARCHAR(50) NULL, 
    CONSTRAINT [CASEUSERNAMEKEY] FOREIGN KEY ([USERNAME]) REFERENCES [LoginTable]([USERNAME])
)
