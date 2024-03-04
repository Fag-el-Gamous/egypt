CREATE TABLE [dbo].[Burial_Photo] (
    [BoxID]          BIGINT       NOT NULL,
    [Location]       VARCHAR (20) NOT NULL,
    [ExcavationYear] SMALLINT     NOT NULL,
    [BurialNumber]   VARCHAR (50) NOT NULL,
    [IsCoverPhoto]   BIT          NULL,
    CONSTRAINT [PK_Burial_Photo] PRIMARY KEY CLUSTERED ([BoxID] ASC, [Location] ASC, [ExcavationYear] ASC, [BurialNumber] ASC),
    CONSTRAINT [FK_Burial_Photo_Burial] FOREIGN KEY ([Location], [ExcavationYear], [BurialNumber]) REFERENCES [dbo].[Burial] ([Location], [ExcavationYear], [BurialNumber]),
    CONSTRAINT [FK_Burial_Photo_Photo] FOREIGN KEY ([BoxID]) REFERENCES [dbo].[Photo] ([BoxID])
);

