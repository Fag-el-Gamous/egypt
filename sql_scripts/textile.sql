CREATE TABLE [dbo].[Textile] (
    [TextileID]              INT            NOT NULL,
    [ExcavationYear]         SMALLINT       NULL,
    [Location]               VARCHAR (20)   NULL,
    [BurialNumber]           VARCHAR (50)   NULL,
    [TextileReferenceNumber] VARCHAR (20)   NULL,
    [AnalysisType]           VARCHAR (20)   NULL,
    [AnalysisDate]           DATE           NULL,
    [SampleTakenDate]        DATE           NULL,
    [Description]            VARCHAR (2000) NULL,
    [AnalysisBy]             VARCHAR (20)   NULL,
    CONSTRAINT [PK_Textile] PRIMARY KEY CLUSTERED ([TextileID] ASC),
    CONSTRAINT [FK_Textile_Burial] FOREIGN KEY ([Location], [ExcavationYear], [BurialNumber]) REFERENCES [dbo].[Burial] ([Location], [ExcavationYear], [BurialNumber]),
    CONSTRAINT [FK_Textile_Location] FOREIGN KEY ([Location]) REFERENCES [dbo].[Location] ([Location])
);

