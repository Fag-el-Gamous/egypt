CREATE TABLE [dbo].[BiologicalSample] (
    [BiologicalSampleID ] INT           NOT NULL,
    [RackNumber]          SMALLINT      NULL,
    [BagNumber]           SMALLINT      NULL,
    [TubeNumber]          SMALLINT      NULL,
    [SizeML]              FLOAT (53)    NULL,
    [Location]            VARCHAR (20)  NULL,
    [BurialNumber]        VARCHAR (50)  NULL,
    [ExcavationYear]      SMALLINT      NULL,
    [Contents]            VARCHAR (500) NULL,
    [StorageNotes]        VARCHAR (500) NULL,
    [Initials]            VARCHAR (5)   NULL,
    CONSTRAINT [PK_BiologicalSample] PRIMARY KEY CLUSTERED ([BiologicalSampleID ] ASC),
    CONSTRAINT [FK_BiologicalSample_Burial] FOREIGN KEY ([Location], [ExcavationYear], [BurialNumber]) REFERENCES [dbo].[Burial] ([Location], [ExcavationYear], [BurialNumber]),
    CONSTRAINT [FK_BiologicalSample_Location] FOREIGN KEY ([Location]) REFERENCES [dbo].[Location] ([Location])
);

