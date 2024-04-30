// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TournamentManager.DbLib.Model;

internal class Program
{
    private static void Main(string[] args) => GetMenu();
    
    
    public static void GetMenu()
    {
        bool keepGoing = true;
        do
        {
            Console.Clear();
            Console.WriteLine("---Super menu---");
            Console.WriteLine("1 - Ajouter un Tournoi");
            Console.WriteLine("2 - Supprimer un Tournoi");
            Console.WriteLine("3 - Lister un Tournoi");
            Console.WriteLine("0 - Quitter");

            string? saisieUser = Console.ReadLine();

            switch (saisieUser)
            {
                case "1":
                    AddTournament();
                    break;
                case "3":
                    ListTournaments();
                    break;
                case "0":
                    keepGoing = false;
                    break;
                default:
                    break;
            }
        } while (keepGoing);

    }

    private static void ListTournaments()
    {
        using (TournamentDbContext context = new())
        {
            context.Tournaments
                .ToList()
                .ForEach(t => Console.WriteLine(t.Name));

        }
        Console.WriteLine( "Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    private static void AddTournament()
    {
        string? name = null;
        do
        {
            Console.WriteLine("Saisir le nom du tournoi : ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        using (TournamentDbContext context = new())
        {
            context.Tournaments.Add(new()
            {
                Name = name,
                EndDateTime = DateTime.Now.Date.AddDays(3),
                StartDateTime = DateTime.Now.Date.AddDays(5),
            });

            context.SaveChanges();

            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
}
}
