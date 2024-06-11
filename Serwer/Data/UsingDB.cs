using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer.Data
{
    class UsingDB
    {
        public void SaveData(DataServer data)
        {
            using (var context = new MyDBContext())
            {
                context.Database.EnsureCreated();

                Console.WriteLine("dlaczego tu jestes");
                context.Games.Add(data);
                context.SaveChanges();
            }
        }

        public List<DataServer> GetAllData()
        {
            using (var context = new MyDBContext())
            {
                return context.Games.ToList();
            }
        }


        public bool DeleteData(int id)
        {
            using (var context = new MyDBContext())
            {
                var dataToRemove = context.Games.FirstOrDefault(g => g.GameId == id);
                if (dataToRemove != null)
                {
                    context.Games.Remove(dataToRemove);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Element with ID {id} does not exist.");
                    return false;
                }

            }

            return true;
        }


        public void EditData(DataServer editdata, int id)
        {
            using (var context = new MyDBContext())
            {
                var game = context.Games.FirstOrDefault(g => g.GameId == id);

                if (game != null)
                {
                    game.Title = editdata.Title;
                    game.Developer = editdata.Developer;
                    game.Rating = editdata.Rating;
                    game.Review = editdata.Review;
                }

                Console.WriteLine($"{game.GameId}, {game.Title}, {game.Developer}, {game.Rating}, {game.Review}");

                context.SaveChanges();
            }

        }
    }
}
