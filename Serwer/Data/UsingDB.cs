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

    }
}
