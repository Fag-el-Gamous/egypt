CREATE TABLE [dbo].[Textile_TextileDecoration] (
    [TextileID]         INT          NOT NULL,
    [TextileDecoration] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Textile_TextileDecoration] PRIMARY KEY CLUSTERED ([TextileID] ASC, [TextileDecoration] ASC),
    CONSTRAINT [FK_Textile_TextileDecoration] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID]),
    CONSTRAINT [FK_Textile_TextileDecoration_TextileDecoration] FOREIGN KEY ([TextileDecoration]) REFERENCES [dbo].[TextileDecoration] ([TextileDecoration])
);

