// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAPI.DataContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoviesAPI.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20211017134612_addInitial")]
    partial class addInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MoviesAPI.Models.Actors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ActorName")
                        .HasColumnType("text");

                    b.Property<int?>("MoviesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("actorsContext");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActorName = "Tom Hanks"
                        },
                        new
                        {
                            Id = 2,
                            ActorName = "Johnny Depp"
                        },
                        new
                        {
                            Id = 3,
                            ActorName = "Morgan Freeman"
                        },
                        new
                        {
                            Id = 4,
                            ActorName = "Clancy Brown"
                        },
                        new
                        {
                            Id = 5,
                            ActorName = "Mark Ruffalo"
                        },
                        new
                        {
                            Id = 6,
                            ActorName = "Jim Carrey"
                        });
                });

            modelBuilder.Entity("MoviesAPI.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string[]>("Actors")
                        .HasColumnType("text[]");

                    b.Property<string>("MovieBio")
                        .HasColumnType("text");

                    b.Property<string>("MovieName")
                        .HasColumnType("text");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("moviesContext");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Actors = new[] { "3", "4" },
                            MovieBio = "In 1947 Portland, Maine, banker Andy Dufresne is convicted of murdering his wife and her lover and is sentenced to two consecutive life sentences at the Shawshank State Prison.",
                            MovieName = "The Shawshank Redemption",
                            Producer = "3",
                            ReleaseDate = "1994-09-22"
                        },
                        new
                        {
                            Id = 2,
                            Actors = new[] { "3", "5" },
                            MovieBio = "Now You See Me is a 2013 American heist thriller film directed by Louis Leterrier from a screenplay by Ed Solomon, Boaz Yakin, and Edward Ricourt and a story by Yakin and Ricourt. It is the first installment in the Now You See Me series. The film features an ensemble cast of Jesse Eisenberg, Mark Ruffalo, Woody Harrelson, Isla Fisher, Dave Franco, Mélanie Laurent, Michael Caine, and Morgan Freeman. ",
                            MovieName = "Now You See Me",
                            Producer = "4",
                            ReleaseDate = "2013-05-31"
                        },
                        new
                        {
                            Id = 3,
                            Actors = new[] { "3", "6" },
                            MovieBio = "A military dog that helped American Marines in Afghanistan returns to the United States and is adopted by his handler's family after suffering a traumatic experience.",
                            MovieName = "Max",
                            Producer = "4",
                            ReleaseDate = "2015-06-26"
                        });
                });

            modelBuilder.Entity("MoviesAPI.Models.Producers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MoviesId")
                        .HasColumnType("integer");

                    b.Property<string>("ProducerName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("producerContext");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProducerName = "David Heyman"
                        },
                        new
                        {
                            Id = 2,
                            ProducerName = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 3,
                            ProducerName = "Niki Marvin"
                        },
                        new
                        {
                            Id = 4,
                            ProducerName = "Boaz Yakin"
                        });
                });

            modelBuilder.Entity("MoviesAPI.Models.Actors", b =>
                {
                    b.HasOne("MoviesAPI.Models.Movies", null)
                        .WithMany("ActorList")
                        .HasForeignKey("MoviesId");
                });

            modelBuilder.Entity("MoviesAPI.Models.Producers", b =>
                {
                    b.HasOne("MoviesAPI.Models.Movies", null)
                        .WithMany("ProducerList")
                        .HasForeignKey("MoviesId");
                });

            modelBuilder.Entity("MoviesAPI.Models.Movies", b =>
                {
                    b.Navigation("ActorList");

                    b.Navigation("ProducerList");
                });
#pragma warning restore 612, 618
        }
    }
}
