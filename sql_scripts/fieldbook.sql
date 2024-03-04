CREATE TABLE [dbo].[FieldBook] (
    [FieldBookID] INT           NOT NULL,
    [BoxID]       BIGINT        NULL,
    [YearName]    TINYINT       NULL,
    [Notes]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_FieldBook] PRIMARY KEY CLUSTERED ([FieldBookID] ASC),
    CONSTRAINT [FK_FieldBook_PDF] FOREIGN KEY ([BoxID]) REFERENCES [dbo].[PDF] ([BoxID])
);

