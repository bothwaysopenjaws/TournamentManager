using Microsoft.EntityFrameworkCore;
using System.Net;

namespace TournamentManager.DbLib.Model;

/// <summary>
/// Contexte du tournoi
/// </summary>
public class TournamentDbContext : DbContext
{
    /// <summary>
    /// Liste des tournois
    /// </summary>
    public DbSet<Tournament> Tournaments { get; set; }
    
    /// <summary>
    /// Liste des rencontres
    /// </summary>
    public DbSet<Encounter> Encounters { get; set; }
    
    /// <summary>
    /// Liste des matchs
    /// </summary>
    public DbSet<Match> Matches{ get; set; }
    
    /// <summary>
    /// Liste des joueurs
    /// </summary>
    public DbSet<Player> Players { get; set; }
    
    /// <summary>
    /// Liste des équipes
    /// </summary>
    public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TournamentManager;Trusted_Connection=True;MultipleActiveResultSets=true;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Team>()
            .HasMany(t => t.EncountersAsA)
            .WithOne(e => e.TeamA)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Team>()
            .HasMany(t => t.EncountersAsB)
            .WithOne(e => e.TeamB)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

