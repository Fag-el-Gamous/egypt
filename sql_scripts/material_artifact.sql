CREATE TABLE [dbo].[Material_Artifact] (
    [ArtifactID] VARCHAR (20) NOT NULL,
    [Material]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Material_Artifact] PRIMARY KEY CLUSTERED ([ArtifactID] ASC, [Material] ASC),
    CONSTRAINT [FK_Material_Artifact_Artifact] FOREIGN KEY ([ArtifactID]) REFERENCES [dbo].[Artifact] ([ArtifactID]),
    CONSTRAINT [FK_Material_Artifact_Material] FOREIGN KEY ([Material]) REFERENCES [dbo].[Material] ([Material])
);

