using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DAL.Entity
{
   public class Dishes
    {
        public Guid DishesId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public int cookingTime { get; set; }

        
        public ICollection<Ingredients> Ingredients { get; set; }

    }
}
