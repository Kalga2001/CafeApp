using CafeApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DAL.Entity
{
    public class Cooks
    {
        public Guid CooksId { get; set; }
        public string Name { get; set; }
        public Dishes Dishes { get; set; }
        public int OrderCount { get; set; }

        

    }
       
}
