﻿// <auto-generated />
using InteractiveData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InteractiveData.Migrations
{
    [DbContext(typeof(MarshallContext))]
    [Migration("20190731133847_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InteractiveDomain.InteractiveAmplifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model");

                    b.Property<int>("Power");

                    b.HasKey("Id");

                    b.ToTable("InteractiveAmplifiers");
                });

            modelBuilder.Entity("InteractiveDomain.InteractiveElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("InteractiveAmplifierId");

                    b.Property<string>("MeshName");

                    b.Property<string>("Name");

                    b.Property<string>("Panel");

                    b.HasKey("Id");

                    b.HasIndex("InteractiveAmplifierId");

                    b.ToTable("InteractiveElements");
                });

            modelBuilder.Entity("InteractiveDomain.InteractiveElement", b =>
                {
                    b.HasOne("InteractiveDomain.InteractiveAmplifier", "InteractiveAmplifier")
                        .WithMany("InteractiveElements")
                        .HasForeignKey("InteractiveAmplifierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
