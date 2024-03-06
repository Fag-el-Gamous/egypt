CREATE TABLE [dbo].[Textile_TextileColor] (
    [TextileID]    INT         NOT NULL,
    [TextileColor] VARCHAR (6) NOT NULL,
    CONSTRAINT [PK_Textile_TextileColor] PRIMARY KEY CLUSTERED ([TextileID] ASC, [TextileColor] ASC),
    CONSTRAINT [FK_Textile_TextileColor] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID]),
    CONSTRAINT [FK_Textile_TextileColor_TextileColor] FOREIGN KEY ([TextileColor]) REFERENCES [dbo].[TextileColor] ([TextileColor])
);

