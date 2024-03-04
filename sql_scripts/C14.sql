CREATE TABLE [dbo].[C14] (
    [C14ID]                INT           NOT NULL,
    [BiologicalSampleID]   INT           NULL,
    [Contents]             VARCHAR (255) NULL,
    [LocationDescription]  VARCHAR (255) NULL,
    [Rack]                 INT           NULL,
    [TubeNum]              INT           NULL,
    [Sizeml]               FLOAT (53)    NULL,
    [NumFoci]              INT           NULL,
    [C14SampleNum2017]     INT           NULL,
    [AgeBP]                FLOAT (53)    NULL,
    [CalendarDate]         INT           NULL,
    [CalendarDateMax95]    FLOAT (53)    NULL,
    [CalendarDateMin95]    FLOAT (53)    NULL,
    [ResearchQuestions]    TEXT          NULL,
    [ResearchQuestionsNum] INT           NULL,
    [Labs]                 VARCHAR (255) NULL,
    [Notes]                VARCHAR (255) NULL,
    CONSTRAINT [PK_C14] PRIMARY KEY CLUSTERED ([C14ID] ASC),
    CONSTRAINT [FK_C14_BioSample] FOREIGN KEY ([BiologicalSampleID]) REFERENCES [dbo].[BiologicalSample] ([BiologicalSampleID ])
);

