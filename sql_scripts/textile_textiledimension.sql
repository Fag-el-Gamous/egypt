CREATE TABLE [dbo].[Textile_TextileDimension] (
    [TextileID]         INT            NOT NULL,
    [DimensionID]       INT            NOT NULL,
    [CentimetersLength] NUMERIC (5, 2) NULL,
    CONSTRAINT [PK_Textile_TextileDimension] PRIMARY KEY CLUSTERED ([TextileID] ASC, [DimensionID] ASC),
    CONSTRAINT [FK_Textile_TextileDimension_Textile] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID]),
    CONSTRAINT [FK_Textile_TextileDimension_TextileDimension] FOREIGN KEY ([DimensionID]) REFERENCES [dbo].[TextileDimension] ([DimensionID])
);

