﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WypozyczalniaFilmow.DAL;

namespace WypozyczalniaFilmow.Migrations
{
    [DbContext(typeof(FilmyContext))]
    [Migration("20220321122918_dodanieDlugosciFilmu")]
    partial class dodanieDlugosciFilmu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WypozyczalniaFilmow.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataDodania")
                        .HasColumnType("datetime2");

                    b.Property<int>("DlugoscFilmu")
                        .HasColumnType("int");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Rezyser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaId");

                    b.ToTable("Filmy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 10m,
                            DataDodania = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 88,
                            KategoriaId = 1,
                            Opis = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                            Rezyser = "Marcus Nispel",
                            Tytul = "Teksańska Masakra Piłą Mechaniczną"
                        },
                        new
                        {
                            Id = 2,
                            Cena = 14m,
                            DataDodania = new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 67,
                            KategoriaId = 3,
                            Opis = "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.",
                            Rezyser = "Joel Schumacher",
                            Tytul = "Numer 23"
                        },
                        new
                        {
                            Id = 3,
                            Cena = 12m,
                            DataDodania = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 104,
                            KategoriaId = 3,
                            Opis = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                            Rezyser = "David Koepp",
                            Tytul = "Sekretne Okno"
                        },
                        new
                        {
                            Id = 4,
                            Cena = 20m,
                            DataDodania = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 75,
                            KategoriaId = 5,
                            Opis = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                            Rezyser = "Peter Jackson",
                            Tytul = "Władca Pierścieni: Drużyna Pierścienia"
                        },
                        new
                        {
                            Id = 5,
                            Cena = 11m,
                            DataDodania = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 78,
                            KategoriaId = 4,
                            Opis = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                            Rezyser = "Robert Schwentke",
                            Tytul = "Red"
                        },
                        new
                        {
                            Id = 6,
                            Cena = 0m,
                            DataDodania = new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 87,
                            KategoriaId = 2,
                            Opis = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                            Rezyser = "Tomasz Sekielski",
                            Tytul = "Tylko nie mów nikomu"
                        },
                        new
                        {
                            Id = 7,
                            Cena = 13m,
                            DataDodania = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 76,
                            KategoriaId = 5,
                            Opis = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                            Rezyser = "Neil Burger",
                            Tytul = "Iluzjonista"
                        },
                        new
                        {
                            Id = 8,
                            Cena = 15m,
                            DataDodania = new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 85,
                            KategoriaId = 3,
                            Opis = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                            Rezyser = "Vincenzo Natali",
                            Tytul = "Cube"
                        },
                        new
                        {
                            Id = 9,
                            Cena = 16m,
                            DataDodania = new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 87,
                            KategoriaId = 1,
                            Opis = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                            Rezyser = "Clive Barker",
                            Tytul = "Hellraiser: Wysłannik Piekieł"
                        },
                        new
                        {
                            Id = 10,
                            Cena = 17m,
                            DataDodania = new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DlugoscFilmu = 67,
                            KategoriaId = 3,
                            Opis = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                            Rezyser = "Jonathan Demme",
                            Tytul = "Milczenie Owiec"
                        });
                });

            modelBuilder.Entity("WypozyczalniaFilmow.Models.Kategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "Horror",
                            Opis = "Straszne filmy"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "Dokumentalny",
                            Opis = "Filmy oparte na faktach"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "Thriller",
                            Opis = "Dreszczowce"
                        },
                        new
                        {
                            Id = 4,
                            Nazwa = "Sensacyjne",
                            Opis = "Filmy z akcją"
                        },
                        new
                        {
                            Id = 5,
                            Nazwa = "Fantasty",
                            Opis = "Elementy magiczne i nadprzyrodzone"
                        });
                });

            modelBuilder.Entity("WypozyczalniaFilmow.Models.Film", b =>
                {
                    b.HasOne("WypozyczalniaFilmow.Models.Kategoria", "Kategoria")
                        .WithMany("Filmy")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");
                });

            modelBuilder.Entity("WypozyczalniaFilmow.Models.Kategoria", b =>
                {
                    b.Navigation("Filmy");
                });
#pragma warning restore 612, 618
        }
    }
}
