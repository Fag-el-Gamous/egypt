CREATE TABLE [dbo].[Artifact_Photo] (
    [ArtifactID]   VARCHAR (20) NOT NULL,
    [BoxID]        BIGINT       NOT NULL,
    [IsCoverPhoto] BIT          NULL,
    CONSTRAINT [PK_Artifact_Photo] PRIMARY KEY CLUSTERED ([ArtifactID] ASC, [BoxID] ASC),
    CONSTRAINT [FK_Artifact_Photo_Artifact] FOREIGN KEY ([ArtifactID]) REFERENCES [dbo].[Artifact] ([ArtifactID]),
    CONSTRAINT [FK_Artifact_Photo_Photo] FOREIGN KEY ([BoxID]) REFERENCES [dbo].[Photo] ([BoxID])
);
