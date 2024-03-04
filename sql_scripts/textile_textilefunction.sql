CREATE TABLE [dbo].[Textile_TextileFunction] (
    [TextileID]       INT          NOT NULL,
    [TextileFunction] VARCHAR (19) NOT NULL,
    [Locale]          VARCHAR (20) NULL,
    CONSTRAINT [PK_Textile_TextileFunction] PRIMARY KEY CLUSTERED ([TextileFunction] ASC, [TextileID] ASC),
    CONSTRAINT [FK_Textile_TextileFunction] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID]),
    CONSTRAINT [FK_Textile_TextileFunction_TextileFunction] FOREIGN KEY ([TextileFunction]) REFERENCES [dbo].[TextileFunction] ([TextileFunction])
);

