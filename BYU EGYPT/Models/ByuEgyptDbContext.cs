using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BYU_EGYPT.Models;

public partial class ByuEgyptDbContext : DbContext
{
    public ByuEgyptDbContext()
    {
    }

    public ByuEgyptDbContext(DbContextOptions<ByuEgyptDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artifact> Artifacts { get; set; }

    public virtual DbSet<ArtifactPhoto> ArtifactPhotos { get; set; }

    public virtual DbSet<BiologicalSample> BiologicalSamples { get; set; }

    public virtual DbSet<BodyAnalysis> BodyAnalyses { get; set; }

    public virtual DbSet<BodyAnalysisSheet> BodyAnalysisSheets { get; set; }

    public virtual DbSet<Burial> Burials { get; set; }

    public virtual DbSet<BurialFieldbookPage> BurialFieldbookPages { get; set; }

    public virtual DbSet<BurialPhoto> BurialPhotos { get; set; }

    public virtual DbSet<C14> C14s { get; set; }

    public virtual DbSet<Cranium> Crania { get; set; }

    public virtual DbSet<CraniumAnalysisSheet> CraniumAnalysisSheets { get; set; }

    public virtual DbSet<CraniumPhoto> CraniumPhotos { get; set; }

    public virtual DbSet<Excavation> Excavations { get; set; }

    public virtual DbSet<FieldBook> FieldBooks { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonTextile> PersonTextiles { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<Textile> Textiles { get; set; }

    public virtual DbSet<TextileAnalysisSheet> TextileAnalysisSheets { get; set; }

    public virtual DbSet<TextileColor> TextileColors { get; set; }

    public virtual DbSet<TextileDecoration> TextileDecorations { get; set; }

    public virtual DbSet<TextileDimension> TextileDimensions { get; set; }

    public virtual DbSet<TextileFunction> TextileFunctions { get; set; }

    public virtual DbSet<TextileManipulation> TextileManipulations { get; set; }

    public virtual DbSet<TextileMaterial> TextileMaterials { get; set; }

    public virtual DbSet<TextilePhoto> TextilePhotos { get; set; }

    public virtual DbSet<TextilePlyDirection> TextilePlyDirections { get; set; }

    public virtual DbSet<TextileSpinAngle> TextileSpinAngles { get; set; }

    public virtual DbSet<TextileStructure> TextileStructures { get; set; }

    public virtual DbSet<TextileTextileDimension> TextileTextileDimensions { get; set; }

    public virtual DbSet<TextileTextileFunction> TextileTextileFunctions { get; set; }

    public virtual DbSet<TextileThickness> TextileThicknesses { get; set; }

    public virtual DbSet<TextileTwistDirection> TextileTwistDirections { get; set; }

    public virtual DbSet<YarnManipulation> YarnManipulations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:byu-egypt-db.c2dqr5tvp2f1.us-east-2.rds.amazonaws.com,1433;Initial Catalog=byu-egypt-db;Persist Security Info=False;User ID=admin;Password=Garage-Deflected7-Oversized;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artifact>(entity =>
        {
            entity.ToTable("Artifact");

            entity.Property(e => e.ArtifactId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ArtifactID");
            entity.Property(e => e.ArtifactEra)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConservationNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Dimensions)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ExcavatorNum)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Finder)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.KomAushimEntryDate).HasColumnType("date");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationAtSite)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Provenance)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StorageSite)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Artifacts)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("FK_Artifact_Location");

            entity.HasOne(d => d.Person).WithMany(p => p.Artifacts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Artifact_Person");

            entity.HasOne(d => d.Burial).WithMany(p => p.Artifacts)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .HasConstraintName("FK_Artifact_Burial");

            entity.HasMany(d => d.Materials).WithMany(p => p.Artifacts)
                .UsingEntity<Dictionary<string, object>>(
                    "MaterialArtifact",
                    r => r.HasOne<Material>().WithMany()
                        .HasForeignKey("Material")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Material_Artifact_Material"),
                    l => l.HasOne<Artifact>().WithMany()
                        .HasForeignKey("ArtifactId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Material_Artifact_Artifact"),
                    j =>
                    {
                        j.HasKey("ArtifactId", "Material");
                        j.ToTable("Material_Artifact");
                        j.IndexerProperty<string>("ArtifactId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("ArtifactID");
                        j.IndexerProperty<string>("Material")
                            .HasMaxLength(50)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<ArtifactPhoto>(entity =>
        {
            entity.HasKey(e => new { e.ArtifactPhotoFilePath, e.ArtifactPhotoFileName });

            entity.ToTable("ArtifactPhoto");

            entity.Property(e => e.ArtifactPhotoFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.ArtifactPhotoFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.ArtifactId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ArtifactID");

            entity.HasOne(d => d.Artifact).WithMany(p => p.ArtifactPhotos)
                .HasForeignKey(d => d.ArtifactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtifactPhoto_Artifact");
        });

        modelBuilder.Entity<BiologicalSample>(entity =>
        {
            entity.ToTable("BiologicalSample");

            entity.Property(e => e.BiologicalSampleId)
                .ValueGeneratedNever()
                .HasColumnName("BiologicalSampleID ");
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contents)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Initials)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SizeMl).HasColumnName("SizeML");
            entity.Property(e => e.StorageNotes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.BiologicalSamples)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("FK_BiologicalSample_Location");

            entity.HasOne(d => d.Burial).WithMany(p => p.BiologicalSamples)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .HasConstraintName("FK_BiologicalSample_Burial");
        });

        modelBuilder.Entity<BodyAnalysis>(entity =>
        {
            entity.HasKey(e => new { e.BodyAnalysisFilePath, e.BodyAnalysisFileName });

            entity.ToTable("BodyAnalysis");

            entity.Property(e => e.BodyAnalysisFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.BodyAnalysisFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Burial).WithMany(p => p.BodyAnalyses)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BodyAnalysis_Burial");
        });

        modelBuilder.Entity<BodyAnalysisSheet>(entity =>
        {
            entity.HasKey(e => new { e.BodyAnalysisSheetFilePath, e.BodyAnalysisSheetFileName });

            entity.ToTable("BodyAnalysisSheet");

            entity.Property(e => e.BodyAnalysisSheetFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.BodyAnalysisSheetFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Burial).WithMany(p => p.BodyAnalysisSheets)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BodyAnalysisSheet_Burial");
        });

        modelBuilder.Entity<Burial>(entity =>
        {
            entity.HasKey(e => new { e.Location, e.ExcavationYear, e.BurialNumber });

            entity.ToTable("Burial");

            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdultSubadult)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.AgeGroup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BodyAnalysisNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BodyExaminationDate).HasColumnType("date");
            entity.Property(e => e.BodyPreservationLevel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BurialNotes).HasMaxLength(2000);
            entity.Property(e => e.CariesPeriodontalDisease)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Depth).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.DorsalPittingPelvis).HasMaxLength(10);
            entity.Property(e => e.EstimateSex)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.EstimateStature).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.EstimatedAgeAtDeath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FemurEpiphysealUnion).HasMaxLength(10);
            entity.Property(e => e.FemurHeadDiameter).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.FemurLength).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.GonionCranium).HasMaxLength(10);
            entity.Property(e => e.GraveGoodsDescription).HasMaxLength(2000);
            entity.Property(e => e.HairColor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HairDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HeadDirection)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HillDesignation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HumerusEpiphysealUnion).HasMaxLength(10);
            entity.Property(e => e.HumerusHeadDiameter).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.HumerusLength).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.LamboidSutureCranium).HasMaxLength(10);
            entity.Property(e => e.Length).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.MedialIpramusPelvis)
                .HasMaxLength(10)
                .HasColumnName("MedialIPRamusPelvis");
            entity.Property(e => e.NuchalCrestCranium).HasMaxLength(10);
            entity.Property(e => e.OrbitEdgeCranium).HasMaxLength(10);
            entity.Property(e => e.Osteophytosis)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ParietalBossingCranium).HasMaxLength(10);
            entity.Property(e => e.PubicBonePelvis).HasMaxLength(10);
            entity.Property(e => e.RobustCranium).HasMaxLength(10);
            entity.Property(e => e.SciaticNotchPelvis).HasMaxLength(10);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SouthToFeet).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.SouthToHead).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.SphenoOccipitalSynchondrosisCranium).HasMaxLength(10);
            entity.Property(e => e.SquamousSutureCranium).HasMaxLength(10);
            entity.Property(e => e.SubpubicAnglePelvis).HasMaxLength(10);
            entity.Property(e => e.SupraorbitalRidgesCranium).HasMaxLength(10);
            entity.Property(e => e.TibiaLength).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.ToothAttrition)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ToothEruptionAgeEstimate).HasMaxLength(100);
            entity.Property(e => e.ToothEruptionDescription).HasMaxLength(200);
            entity.Property(e => e.VentralArcPelvis).HasMaxLength(10);
            entity.Property(e => e.WestToFeet).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.WestToHead).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.WrappingLevel)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.ZygomaticCrestCranium).HasMaxLength(10);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Burials)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Burial_Location");
        });

        modelBuilder.Entity<BurialFieldbookPage>(entity =>
        {
            entity.HasKey(e => new { e.Location, e.ExcavationYear, e.BurialNumber, e.FieldBookId, e.PdfpageNumber, e.BookPageNumber });

            entity.ToTable("Burial_FieldbookPage");

            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FieldBookId).HasColumnName("FieldBookID");
            entity.Property(e => e.PdfpageNumber).HasColumnName("PDFPageNumber");

            entity.HasOne(d => d.FieldBook).WithMany(p => p.BurialFieldbookPages)
                .HasForeignKey(d => d.FieldBookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Burial_Fieldbook_Page_FieldBook");

            entity.HasOne(d => d.Burial).WithMany(p => p.BurialFieldbookPages)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Burial_Fieldbook_Page_Burial");
        });

        modelBuilder.Entity<BurialPhoto>(entity =>
        {
            entity.HasKey(e => new { e.BurialPhotoFilePath, e.BurialPhotoFileName });

            entity.ToTable("BurialPhoto");

            entity.Property(e => e.BurialPhotoFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.BurialPhotoFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Burial).WithMany(p => p.BurialPhotos)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BurialPhoto_Burial");
        });

        modelBuilder.Entity<C14>(entity =>
        {
            entity.ToTable("C14");

            entity.Property(e => e.C14id)
                .ValueGeneratedNever()
                .HasColumnName("C14ID");
            entity.Property(e => e.AgeBp).HasColumnName("AgeBP");
            entity.Property(e => e.BiologicalSampleId).HasColumnName("BiologicalSampleID");
            entity.Property(e => e.C14sampleNum2017).HasColumnName("C14SampleNum2017");
            entity.Property(e => e.Contents)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Labs)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LocationDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ResearchQuestions).HasColumnType("text");

            entity.HasOne(d => d.BiologicalSample).WithMany(p => p.C14s)
                .HasForeignKey(d => d.BiologicalSampleId)
                .HasConstraintName("FK_C14_BioSample");
        });

        modelBuilder.Entity<Cranium>(entity =>
        {
            entity.HasKey(e => e.CraniumId).HasName("PK__Cranium__BB37B3F9D1823C6B");

            entity.ToTable("Cranium");

            entity.Property(e => e.CraniumId)
                .ValueGeneratedNever()
                .HasColumnName("CraniumID");
            entity.Property(e => e.BasionBregmaHeight).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.BasionNasionLength).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.BasionProsthionLength).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.BizygomaticDiameter).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CalcBasionNasion).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CalcBasionProsthion).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CalcBizygomaticDiameter).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CalcMaxCraniumLength).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CalcNasionProsthionHeight).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CalculatedSex)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CraniumCalcSum).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.InterorbitalBreadth).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaxCraniumBreadth).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MaxCraniumLength).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MaxNasalBreadth).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.NasionProsthionHeight).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.Burial).WithMany(p => p.Crania)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .HasConstraintName("FK_Cranium_Burial");
        });

        modelBuilder.Entity<CraniumAnalysisSheet>(entity =>
        {
            entity.HasKey(e => new { e.CraniumAnalysisSheetFilePath, e.CraniumAnalysisSheetFileName });

            entity.ToTable("CraniumAnalysisSheet");

            entity.Property(e => e.CraniumAnalysisSheetFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.CraniumAnalysisSheetFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.CraniumId).HasColumnName("CraniumID");
        });

        modelBuilder.Entity<CraniumPhoto>(entity =>
        {
            entity.HasKey(e => new { e.CraniumPhotoFilePath, e.CraniumPhotoFileName });

            entity.ToTable("CraniumPhoto");

            entity.Property(e => e.CraniumPhotoFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.CraniumPhotoFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.CraniumId).HasColumnName("CraniumID");

            entity.HasOne(d => d.Cranium).WithMany(p => p.CraniumPhotos)
                .HasForeignKey(d => d.CraniumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CraniumPhoto_Cranium");
        });

        modelBuilder.Entity<Excavation>(entity =>
        {
            entity.HasKey(e => new { e.Location, e.Year, e.SourceInformation });

            entity.ToTable("Excavation");

            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SourceInformation)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Excavations)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Excavation_Location");
        });

        modelBuilder.Entity<FieldBook>(entity =>
        {
            entity.ToTable("FieldBook");

            entity.Property(e => e.FieldBookId)
                .ValueGeneratedNever()
                .HasColumnName("FieldBookID");
            entity.Property(e => e.FieldBookFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.FieldBookFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.YearName)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Location1);

            entity.ToTable("Location");

            entity.Property(e => e.Location1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Location");
            entity.Property(e => e.Area)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.EastOrWest)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NorthOrSouth)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.Quadrant).HasMaxLength(2);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Material1);

            entity.ToTable("Material");

            entity.Property(e => e.Material1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Material");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonTextile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Person_Textile");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.TextileId).HasColumnName("TextileID");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Textile_Person");

            entity.HasOne(d => d.Textile).WithMany()
                .HasForeignKey(d => d.TextileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Textile_Textile");
        });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.PublicationId).HasName("PK_PublicationID");

            entity.ToTable("Publication");

            entity.Property(e => e.PublicationId)
                .ValueGeneratedNever()
                .HasColumnName("PublicationID");
            entity.Property(e => e.Author).IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.IsFree)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OnlineLink).IsUnicode(false);
            entity.Property(e => e.PublicationDate).HasColumnType("date");
            entity.Property(e => e.PublicationFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.PublicationFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.PublicationTitle).IsUnicode(false);
            entity.Property(e => e.PublicationType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Topic)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Textile>(entity =>
        {
            entity.ToTable("Textile");

            entity.Property(e => e.TextileId)
                .ValueGeneratedNever()
                .HasColumnName("TextileID");
            entity.Property(e => e.AnalysisDate).HasColumnType("date");
            entity.Property(e => e.AnalysisType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BurialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SampleTakenDate).HasColumnType("date");
            entity.Property(e => e.TextileReferenceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Textiles)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("FK_Textile_Location");

            entity.HasOne(d => d.Burial).WithMany(p => p.Textiles)
                .HasForeignKey(d => new { d.Location, d.ExcavationYear, d.BurialNumber })
                .HasConstraintName("FK_Textile_Burial");

            entity.HasMany(d => d.TextileColors).WithMany(p => p.Textiles)
                .UsingEntity<Dictionary<string, object>>(
                    "TextileTextileColor",
                    r => r.HasOne<TextileColor>().WithMany()
                        .HasForeignKey("TextileColor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Textile_TextileColor_TextileColor"),
                    l => l.HasOne<Textile>().WithMany()
                        .HasForeignKey("TextileId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Textile_TextileColor"),
                    j =>
                    {
                        j.HasKey("TextileId", "TextileColor");
                        j.ToTable("Textile_TextileColor");
                        j.IndexerProperty<int>("TextileId").HasColumnName("TextileID");
                        j.IndexerProperty<string>("TextileColor")
                            .HasMaxLength(6)
                            .IsUnicode(false);
                    });

            entity.HasMany(d => d.TextileDecorations).WithMany(p => p.Textiles)
                .UsingEntity<Dictionary<string, object>>(
                    "TextileTextileDecoration",
                    r => r.HasOne<TextileDecoration>().WithMany()
                        .HasForeignKey("TextileDecoration")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Textile_TextileDecoration_TextileDecoration"),
                    l => l.HasOne<Textile>().WithMany()
                        .HasForeignKey("TextileId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Textile_TextileDecoration"),
                    j =>
                    {
                        j.HasKey("TextileId", "TextileDecoration");
                        j.ToTable("Textile_TextileDecoration");
                        j.IndexerProperty<int>("TextileId").HasColumnName("TextileID");
                        j.IndexerProperty<string>("TextileDecoration")
                            .HasMaxLength(50)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<TextileAnalysisSheet>(entity =>
        {
            entity.HasKey(e => new { e.TextileAnalysisSheetFilePath, e.TextileAnalysisSheetFileName });

            entity.ToTable("TextileAnalysisSheet");

            entity.Property(e => e.TextileAnalysisSheetFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.TextileAnalysisSheetFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.TextileId).HasColumnName("TextileID");

            entity.HasOne(d => d.Textile).WithMany(p => p.TextileAnalysisSheets)
                .HasForeignKey(d => d.TextileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextileAnalysisSheet_Textile");
        });

        modelBuilder.Entity<TextileColor>(entity =>
        {
            entity.HasKey(e => e.TextileColor1);

            entity.ToTable("TextileColor");

            entity.Property(e => e.TextileColor1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("TextileColor");
        });

        modelBuilder.Entity<TextileDecoration>(entity =>
        {
            entity.HasKey(e => e.TextileDecoration1);

            entity.ToTable("TextileDecoration");

            entity.Property(e => e.TextileDecoration1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TextileDecoration");
        });

        modelBuilder.Entity<TextileDimension>(entity =>
        {
            entity.HasKey(e => e.DimensionId);

            entity.ToTable("TextileDimension");

            entity.Property(e => e.DimensionId)
                .ValueGeneratedNever()
                .HasColumnName("DimensionID");
            entity.Property(e => e.DimensionType)
                .HasMaxLength(14)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TextileFunction>(entity =>
        {
            entity.HasKey(e => e.TextileFunction1);

            entity.ToTable("TextileFunction");

            entity.Property(e => e.TextileFunction1)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("TextileFunction");
            entity.Property(e => e.TextileFunctionNotes)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TextileManipulation>(entity =>
        {
            entity.HasKey(e => e.TextileManipulation1);

            entity.ToTable("TextileManipulation");

            entity.Property(e => e.TextileManipulation1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TextileManipulation");
        });

        modelBuilder.Entity<TextileMaterial>(entity =>
        {
            entity.HasKey(e => e.TextileMaterial1);

            entity.ToTable("TextileMaterial");

            entity.Property(e => e.TextileMaterial1)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("TextileMaterial");
        });

        modelBuilder.Entity<TextilePhoto>(entity =>
        {
            entity.HasKey(e => new { e.TextilePhotoFilePath, e.TextilePhotoFileName });

            entity.ToTable("TextilePhoto");

            entity.Property(e => e.TextilePhotoFilePath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.TextilePhotoFileName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.TextileId).HasColumnName("TextileID");

            entity.HasOne(d => d.Textile).WithMany(p => p.TextilePhotos)
                .HasForeignKey(d => d.TextileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextilePhoto_Textile");
        });

        modelBuilder.Entity<TextilePlyDirection>(entity =>
        {
            entity.HasKey(e => e.TextilePlyDirection1);

            entity.ToTable("TextilePlyDirection");

            entity.Property(e => e.TextilePlyDirection1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TextilePlyDirection");
        });

        modelBuilder.Entity<TextileSpinAngle>(entity =>
        {
            entity.HasKey(e => e.TextileSpinAngle1);

            entity.ToTable("TextileSpinAngle");

            entity.Property(e => e.TextileSpinAngle1)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TextileSpinAngle");
        });

        modelBuilder.Entity<TextileStructure>(entity =>
        {
            entity.HasKey(e => e.TextileStructure1);

            entity.ToTable("TextileStructure");

            entity.Property(e => e.TextileStructure1)
                .HasMaxLength(23)
                .IsUnicode(false)
                .HasColumnName("TextileStructure");

            entity.HasMany(d => d.Textiles).WithMany(p => p.TextileStructures)
                .UsingEntity<Dictionary<string, object>>(
                    "TextileTextileStructure",
                    r => r.HasOne<Textile>().WithMany()
                        .HasForeignKey("TextileId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Textile_TextileStructure"),
                    l => l.HasOne<TextileStructure>().WithMany()
                        .HasForeignKey("TextileStructure")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Textile_TextileStructure_TextileStructure"),
                    j =>
                    {
                        j.HasKey("TextileStructure", "TextileId");
                        j.ToTable("Textile_TextileStructure");
                        j.IndexerProperty<string>("TextileStructure")
                            .HasMaxLength(23)
                            .IsUnicode(false);
                        j.IndexerProperty<int>("TextileId").HasColumnName("TextileID");
                    });
        });

        modelBuilder.Entity<TextileTextileDimension>(entity =>
        {
            entity.HasKey(e => new { e.TextileId, e.DimensionId });

            entity.ToTable("Textile_TextileDimension");

            entity.Property(e => e.TextileId).HasColumnName("TextileID");
            entity.Property(e => e.DimensionId).HasColumnName("DimensionID");
            entity.Property(e => e.CentimetersLength).HasColumnType("numeric(5, 2)");

            entity.HasOne(d => d.Dimension).WithMany(p => p.TextileTextileDimensions)
                .HasForeignKey(d => d.DimensionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Textile_TextileDimension_TextileDimension");

            entity.HasOne(d => d.Textile).WithMany(p => p.TextileTextileDimensions)
                .HasForeignKey(d => d.TextileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Textile_TextileDimension_Textile");
        });

        modelBuilder.Entity<TextileTextileFunction>(entity =>
        {
            entity.HasKey(e => new { e.TextileFunction, e.TextileId });

            entity.ToTable("Textile_TextileFunction");

            entity.Property(e => e.TextileFunction)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.TextileId).HasColumnName("TextileID");
            entity.Property(e => e.Locale)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.TextileFunctionNavigation).WithMany(p => p.TextileTextileFunctions)
                .HasForeignKey(d => d.TextileFunction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Textile_TextileFunction_TextileFunction");

            entity.HasOne(d => d.Textile).WithMany(p => p.TextileTextileFunctions)
                .HasForeignKey(d => d.TextileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Textile_TextileFunction");
        });

        modelBuilder.Entity<TextileThickness>(entity =>
        {
            entity.HasKey(e => e.TextileThickness1);

            entity.ToTable("TextileThickness");

            entity.Property(e => e.TextileThickness1)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("TextileThickness");
        });

        modelBuilder.Entity<TextileTwistDirection>(entity =>
        {
            entity.HasKey(e => e.TextileTwistDirection1);

            entity.ToTable("TextileTwistDirection");

            entity.Property(e => e.TextileTwistDirection1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TextileTwistDirection");
        });

        modelBuilder.Entity<YarnManipulation>(entity =>
        {
            entity.HasKey(e => new { e.YarnManipulationId, e.TextileId });

            entity.ToTable("YarnManipulation");

            entity.Property(e => e.YarnManipulationId).HasColumnName("YarnManipulationID");
            entity.Property(e => e.TextileId).HasColumnName("TextileID");
            entity.Property(e => e.Component)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Manipulation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.PlyDirection)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SpinAngle)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Thickness)
                .HasMaxLength(21)
                .IsUnicode(false);
            entity.Property(e => e.TwistDirection)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.ManipulationNavigation).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.Manipulation)
                .HasConstraintName("FK_YarnManipulation_TextileManipulation");

            entity.HasOne(d => d.MaterialNavigation).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.Material)
                .HasConstraintName("FK_YarnManipulation_TextileMaterial");

            entity.HasOne(d => d.PlyDirectionNavigation).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.PlyDirection)
                .HasConstraintName("FK_YarnManipulation_TextilePlyDirection");

            entity.HasOne(d => d.SpinAngleNavigation).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.SpinAngle)
                .HasConstraintName("FK_YarnManipulation_TextileSpinAngle");

            entity.HasOne(d => d.Textile).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.TextileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YarnManipulation_Textile");

            entity.HasOne(d => d.ThicknessNavigation).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.Thickness)
                .HasConstraintName("FK_YarnManipulation_TextileThickness");

            entity.HasOne(d => d.TwistDirectionNavigation).WithMany(p => p.YarnManipulations)
                .HasForeignKey(d => d.TwistDirection)
                .HasConstraintName("FK_YarnManipulation_TextileTwistDirection");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
