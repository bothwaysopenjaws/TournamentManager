using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.DbLib.Model;

/// <summary>
/// Rencontre
/// </summary>
public class Encounter : EntityBase
{
    /// <summary>
    /// Equipe A
    /// </summary>
    public Team TeamA { get; set; }

    /// <summary>
    /// Identifiant de l'Equipe A
    /// </summary>
    [ForeignKey(nameof(Encounter.TeamA))]
    public int TeamAdentifier { get; set; }

    /// <summary>
    /// Equipe B
    /// </summary>
    public Team TeamB { get; set; }

    /// <summary>
    /// Identifiant de l'Equipe B
    /// </summary>
    [ForeignKey(nameof(Encounter.TeamB))]
    public int TeamBIdentifier { get; set; }

    /// <summary>
    /// Phase du tournoi
    /// </summary>
    public TournamentEnum Phase { get; set; }
 
    /// <summary>
    /// Tournoi associé
    /// </summary>
    public Tournament Tournament { get; set; }

    /// <summary>
    /// Identifiant du tournoi associé
    /// </summary>
    [ForeignKey(nameof(Encounter.Tournament))]
    public int TournamentIdentifier { get; set; }

}
