using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoldPlease.Models;

namespace HoldPlease.Migrations
{
    [DbContext(typeof(HoldPleaseContext))]
    [Migration("20170607010124_00000000000000_CreateIdentitySchema")]
    partial class _00000000000000_CreateIdentitySchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
