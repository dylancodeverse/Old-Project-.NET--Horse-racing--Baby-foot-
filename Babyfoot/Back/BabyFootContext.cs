using System;
using System.Collections.Generic;
using baby_foot.Models;
using Microsoft.EntityFrameworkCore;

namespace baby_foot.Context;

public partial class BabyFootContext : DbContext
{
    public BabyFootContext()
    {
    }

    public BabyFootContext(DbContextOptions<BabyFootContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=baby_foot;Username=walker;Password=w41k4z!;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    /* TABLES */
    public DbSet<BabyFoot>? babyFoots { get; set; }
    public DbSet<BabyFootMatch>? babyFootMatches { get; set; }
    public DbSet<BabyFootMatchDetails>? babyFootMatchDetails { get; set; }
    public DbSet<BabyFootToken>? babyFootTokens { get; set; }
    public DbSet<Person>? persons { get; set; }
    public DbSet<PersonMonetaryFlow>? personMonetaryFlows { get; set; }
    public DbSet<Player>? players { get; set; }
    public DbSet<Status>? statuses { get; set; }
    public DbSet<Team>? teams { get; set; }
    public DbSet<TeamPlayer>? teamPlayers { get; set; }

    /* VIEWS */
    public DbSet<VPeople>? peoples { get; set; }
}
