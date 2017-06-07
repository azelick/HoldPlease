using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoldPlease.Models;

namespace HoldPlease.Migrations
{
    [DbContext(typeof(HoldPleaseContext))]
    partial class HoldPleaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("HoldPlease.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("clientId");

                    b.Property<DateTime>("endAt");

                    b.Property<string>("location");

                    b.Property<string>("name");

                    b.Property<int>("serviceProviderId");

                    b.Property<DateTime>("startAt");

                    b.Property<string>("status");

                    b.HasKey("ID");

                    b.ToTable("Service");
                });
        }
    }
}
