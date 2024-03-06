CREATE TABLE [dbo].[Textile_TextileStructure] (
    [TextileID]        INT          NOT NULL,
    [TextileStructure] VARCHAR (23) NOT NULL,
    CONSTRAINT [PK_Textile_TextileStructure] PRIMARY KEY CLUSTERED ([TextileStructure] ASC, [TextileID] ASC),
    CONSTRAINT [FK_Textile_TextileStructure] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID]),
    CONSTRAINT [FK_Textile_TextileStructure_TextileStructure] FOREIGN KEY ([TextileStructure]) REFERENCES [dbo].[TextileStructure] ([TextileStructure])
);
