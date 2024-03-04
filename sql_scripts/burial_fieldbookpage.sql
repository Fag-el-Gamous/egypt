CREATE TABLE [dbo].[Burial_FieldbookPage] (
    [Location]       VARCHAR (20) NOT NULL,
    [ExcavationYear] SMALLINT     NOT NULL,
    [BurialNumber]   VARCHAR (50) NOT NULL,
    [FieldBookID]    INT          NOT NULL,
    [PDFPageNumber]  SMALLINT     NOT NULL,
    CONSTRAINT [PK_Burial_FieldbookPage] PRIMARY KEY CLUSTERED ([ExcavationYear] ASC, [BurialNumber] ASC, [FieldBookID] ASC, [PDFPageNumber] ASC, [Location] ASC),
    CONSTRAINT [FK_Burial_Fieldbook_Page_Burial] FOREIGN KEY ([Location], [ExcavationYear], [BurialNumber]) REFERENCES [dbo].[Burial] ([Location], [ExcavationYear], [BurialNumber]),
    CONSTRAINT [FK_Burial_Fieldbook_Page_FieldBook] FOREIGN KEY ([FieldBookID]) REFERENCES [dbo].[FieldBook] ([FieldBookID])
);