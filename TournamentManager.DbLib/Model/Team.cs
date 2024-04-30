namespace TournamentManager.DbLib.Model;

/// <summary>
/// Equipe
/// </summary>
public class Team : EntityBase
{
    /// <summary>
    /// Nom
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Liste de joueurs
    /// </summary>
    public List<Player> Players { get; set; }

    /// <summary>
    /// Liste des rencontre de l'équipe en tant que team A
    /// </summary>
    public List<Encounter> EncountersAsA { get; set; }

    /// <summary>
    /// Liste des rencontre de l'équipe en tant que team B
    /// </summary>
    public List<Encounter> EncountersAsB { get; set; }

    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public Team()
    {
        Players = new();
        EncountersAsA = new();
        EncountersAsB = new();
    }
}
