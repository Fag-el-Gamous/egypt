CREATE TABLE [dbo].[Photo] (
    [BoxID]    BIGINT        NOT NULL,
    [FileName] VARCHAR (500) NULL,
    CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED ([BoxID] ASC)
);

