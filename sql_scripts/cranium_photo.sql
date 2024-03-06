CREATE TABLE [dbo].[Cranium_Photo] (
    [CraniaID]     INT    NOT NULL,
    [BoxID]        BIGINT NOT NULL,
    [IsCoverPhoto] BIT    NULL,
    CONSTRAINT [PK_Cranium_Photo] PRIMARY KEY CLUSTERED ([CraniaID] ASC, [BoxID] ASC),
    CONSTRAINT [FK_Cranium_Photo_Cranium] FOREIGN KEY ([CraniaID]) REFERENCES [dbo].[Cranium] ([CraniaID]),
    CONSTRAINT [FK_Cranium_Photo_Photo] FOREIGN KEY ([BoxID]) REFERENCES [dbo].[Photo] ([BoxID])
);

