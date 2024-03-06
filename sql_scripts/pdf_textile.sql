CREATE TABLE [dbo].[PDF_Textile] (
    [TextileID] INT    NOT NULL,
    [BoxID]     BIGINT NOT NULL,
    CONSTRAINT [PK_PDF_Textile] PRIMARY KEY CLUSTERED ([BoxID] ASC, [TextileID] ASC),
    CONSTRAINT [FK_PDF_Textile_PDF] FOREIGN KEY ([BoxID]) REFERENCES [dbo].[PDF] ([BoxID]),
    CONSTRAINT [FK_PDF_Textile_Textile] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID])
);

