using System.ComponentModel.DataAnnotations;


namespace TournamentManager.DbLib.Model;

/// <summary>
/// Classe de base pour une entité
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Identifiant d'une entité
    /// </summary>
    [Key]
    public int Identifier { get; set; }
}
