CREATE TABLE [dbo].[Person_Textile] (
    [PersonID]  INT NOT NULL,
    [TextileID] INT NOT NULL,
    CONSTRAINT [FK_Person_Textile_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]),
    CONSTRAINT [FK_Person_Textile_Textile] FOREIGN KEY ([TextileID]) REFERENCES [dbo].[Textile] ([TextileID])
);

