CREATE TABLE [dbo].[TextileDimension] (
    [DimensionID]   INT          NOT NULL,
    [DimensionType] VARCHAR (14) NULL,
    CONSTRAINT [PK_TextileDimension] PRIMARY KEY CLUSTERED ([DimensionID] ASC)
);

