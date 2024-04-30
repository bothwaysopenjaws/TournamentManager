namespace TournamentManager.DbLib.Model;

/// <summary>
/// Liste des phases possibles pour un tournoi
/// </summary>
public enum TournamentEnum
{
    /// <summary>
    /// Phase de sélection d'un tournoi
    /// </summary>
    PreleminaryPhase,
    /// <summary>
    /// Phase de demi-finales
    /// </summary>
    PhaseSemiFinal,
    /// <summary>
    /// Phase finale
    /// </summary>
    PhaseFinal,
}
