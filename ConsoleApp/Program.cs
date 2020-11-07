using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            //AddSamurai();
            //GetSamurais("After Add:");
            //InsertMultipleSamurais();
            //GetSamuraisSimpler();
            //QueryFilters();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //RtrieveAndDeleteASamurai();
            // MultipleDatabaseOperations();
            // InsertBattle();
            //QueryAndUpdateBattle_Disconnected();
        }

        private static void AddSamuraiWithDbSetTracking()
        {
            var samurai = new Samurai { Name = "Sampson" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var query = _context.Samurais;

            var objects = query.ToList();
            //another  way to atchive it
            var samurais = _context.Samurais.ToList(); //after matrializing objects 


            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void InsertMultipleSamurais()
        {
            //more than 3 operation ef will use patch commands
            var samurai = new Samurai { Name = "Sampson" };
            var samurai2 = new Samurai { Name = "Tasha" };
            var samurai3 = new Samurai { Name = "Number3" };
            var samurai4 = new Samurai { Name = "Number 4" };
            
            _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);


            var samuraiList = new List<Samurai>()
            {
            new Samurai { Name = "Sampson" },
            new Samurai { Name = "Tasha" },
            new Samurai { Name = "Number3" },
            new Samurai { Name = "Number 4" }
        };
            
            _context.Samurais.AddRange(samuraiList);
            
            _context.SaveChanges();
        }
        private static void AddSamuraiWithDbContextRracking()
        {
            var samurai = new Samurai { Name = "Sampson" };
            _context.Add(samurai);

            _context.SaveChanges();
        }

        private static void QueryFilters()
        {
            var name = "Sampson";
            var samurais = _context.Samurais.Where(s => s.Name == "Sampson").ToList();
            //var samurai = _context.Samurais.Find(2);
            //var filter = "J%";
            //var samurais=_context.Samurais.Where(s=>EF.Functions.Like(s.Name,filter)).ToList();
            //var last = _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);
            //the following will throw an exception:
            //var lastNoOrder= _context.Samurais.LastOrDefault(s => s.Name == name);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }
        private static void RetrieveAndDeleteASamurai()
        {
            var samurai = _context.Samurais.Find(18);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.Samurais.Add(new Samurai { Name = "Kikuchiyo" });
            _context.SaveChanges();
        }

        private static void InsertBattle()
        {
            _context.Battels.Add(new Battel
            {
                Name = "Battle of Okehazama",
                StartDate = new DateTime(1560, 05, 01),
                EndDate = new DateTime(1560, 06, 15)
            });
            _context.SaveChanges();
        }

        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battels.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(1560, 06, 30);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battels.Update(battle);
                newContextInstance.SaveChanges();
            }
        }
    }
}