CREATE TABLE [dbo].[Textile_Photo] (
    [BoxID]        BIGINT NOT NULL,
    [TextileID]    INT    NOT NULL,
    [IsCoverPhoto] BIT    NULL,
    CONSTRAINT [PK_Textile_Photo] PRIMARY KEY CLUSTERED ([BoxID] ASC, [TextileID] ASC),
    CONSTRAINT [FK_Textile_Photo_Photo] FOREIGN KEY ([BoxID]) REFERENCES [dbo].[Photo] ([BoxID]),
    CONSTRAINT [FK_Textile_Photo_Textile] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID])
);

