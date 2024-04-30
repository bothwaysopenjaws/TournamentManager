namespace TournamentManager.DbLib.Model;

/// <summary>
/// Tournoi
/// </summary>
public class Tournament : EntityBase
{
    /// <summary>
    /// Nom du tournoi
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Date de début du tournoi
    /// </summary>
    public DateTime StartDateTime { get; set; }
    
    /// <summary>
    /// Date de fin du tournoi
    /// </summary>
    public DateTime EndDateTime { get; set; }

    /// <summary>
    /// La liste des rencontre
    /// </summary>
    public List<Encounter> Encounters { get; set; }
    
    /// <summary>
    /// Constructeur d'une rencontre
    /// </summary>
    public Tournament() => Encounters = new();

}
