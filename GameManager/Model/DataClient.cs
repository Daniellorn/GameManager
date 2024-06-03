using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameManager.Model
{
    public class DataClient
    {
        public int GameId { get; set; }
        public string? Title { get; set; }
        public string? Developer { get; set; }
        public string? Rating { get; set; }
        public string? Review { get; set; }

    }
}
