CREATE TABLE [dbo].[YarnManipulation] (
    [TextileID]          INT          NOT NULL,
    [YarnManipulationID] INT          NOT NULL,
    [Component]          VARCHAR (10) NULL,
    [Material]           VARCHAR (7)  NULL,
    [Manipulation]       VARCHAR (20) NULL,
    [PlyDirection]       VARCHAR (1)  NULL,
    [TwistDirection]     VARCHAR (1)  NULL,
    [SpinAngle]          VARCHAR (11) NULL,
    [ThreadCount]        SMALLINT     NULL,
    [Thickness]          VARCHAR (21) NULL,
    CONSTRAINT [PK_YarnManipulation] PRIMARY KEY CLUSTERED ([YarnManipulationID] ASC, [TextileID] ASC),
    CONSTRAINT [FK_YarnManipulation_Textile] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID]),
    CONSTRAINT [FK_YarnManipulation_TextileManipulation] FOREIGN KEY ([Manipulation]) REFERENCES [dbo].[TextileManipulation] ([TextileManipulation]),
    CONSTRAINT [FK_YarnManipulation_TextileMaterial] FOREIGN KEY ([Material]) REFERENCES [dbo].[TextileMaterial] ([TextileMaterial]),
    CONSTRAINT [FK_YarnManipulation_TextilePlyDirection] FOREIGN KEY ([PlyDirection]) REFERENCES [dbo].[TextilePlyDirection] ([TextilePlyDirection]),
    CONSTRAINT [FK_YarnManipulation_TextileSpinAngle] FOREIGN KEY ([SpinAngle]) REFERENCES [dbo].[TextileSpinAngle] ([TextileSpinAngle]),
    CONSTRAINT [FK_YarnManipulation_TextileThickness] FOREIGN KEY ([Thickness]) REFERENCES [dbo].[TextileThickness] ([TextileThickness]),
    CONSTRAINT [FK_YarnManipulation_TextileTwistDirection] FOREIGN KEY ([TwistDirection]) REFERENCES [dbo].[TextileTwistDirection] ([TextileTwistDirection])
);

