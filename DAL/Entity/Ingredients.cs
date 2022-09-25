using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DAL.Entity
{
    public class Ingredients
    {
        public Guid IngredientsId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public Guid DishesId { get; set; }
        public Dishes Dishes { get; set; } 
    }
}
