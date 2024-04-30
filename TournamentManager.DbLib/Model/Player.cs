using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentManager.DbLib.Model;

/// <summary>
/// Joueur de seconde zone
/// </summary>
public class Player : EntityBase
{
    /// <summary>
    /// Pseudo du joueur
    /// </summary>
    public string Pseudo { get; set; }

    /// <summary>
    /// Riot Id
    /// </summary>
    public string? RiotId { get; set; }

    /// <summary>
    /// Identifiant de l'équipe associé
    /// </summary>
    [ForeignKey(nameof(Player.Team))]
    public int TeamIdentifier { get; set; }

    /// <summary>
    /// Equipe associé
    /// </summary>
    public Team Team { get; set; }
}
