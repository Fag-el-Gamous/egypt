CREATE TABLE [dbo].[Location] (
    [Location]         VARCHAR (20)   NOT NULL,
    [MetersNorthSouth] SMALLINT       NULL,
    [NorthOrSouth]     VARCHAR (1)    NULL,
    [MetersEastWest]   SMALLINT       NULL,
    [EastOrWest]       VARCHAR (1)    NULL,
    [Quadrant]         NVARCHAR (2)   NULL,
    [Notes]            NVARCHAR (200) NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Location] ASC)
);

