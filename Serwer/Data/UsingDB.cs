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

    }
}
