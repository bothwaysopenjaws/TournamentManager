using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.DbLib.Model;

/// <summary>
/// Match d'une rencontre
/// </summary>
public class Match : EntityBase
{
    /// <summary>
    /// équipe gagnante de la rencontre
    /// </summary>
    public Team? WinningTeam { get; set; }

    /// <summary>
    /// Identifiant de l'équipe gagnante
    /// </summary>
    [ForeignKey(nameof(Match.WinningTeam))]
    public int WinningTeamIdentifier { get; set; }

    /// <summary>
    /// Score du vainqueur
    /// </summary>
    public int WinningScore { get; set; }

    /// <summary>
    /// Score du perdant
    /// </summary>
    public int LoosingScore { get; set; }

    /// <summary>
    /// Identifiant de la rencontre associé
    /// </summary>
    [ForeignKey(nameof(Match.Encounter))]
    public int EncounterIdentifier { get; set; }

    /// <summary>
    /// Rencontre associé
    /// </summary>
    public Encounter Encounter { get; set; }
}
