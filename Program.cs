using CafeApp.DAL.Context;
using CafeApp.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CafeApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Result();
            Console.WriteLine("Please enter food: ");
            string dish=Console.ReadLine();
            Order(dish);

            Console.WriteLine("Please choose cook 1-5 ");
            int select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        Console.WriteLine("Please enter food: ");
                        Order(dish);
                        
                        break;
                    case 2:
                        Console.WriteLine("Please enter food: ");
                        Order(dish);
                        break;
                    case 3:
                        Console.WriteLine("Please enter food: ");
                        Order(dish);
                        break;
                    case 4:
                        Console.WriteLine("Please enter food: ");
                        Order(dish);
                        break;
                    case 5:
                        Console.WriteLine("Please enter food: ");
                        Order(dish);
                        break;
                }
            
        }

        public static void Result()
        {
            using (CafeAppDbContext db = new CafeAppDbContext())
            {
                
                var product = db.Dishes.Include(p => p.Ingredients).ToList();
              
                foreach (var p in product)
                {
                    Console.WriteLine("Dishes: {0} ", p.Name);
                    Console.WriteLine("Description: {0} ", p.Description);
                    foreach (var i in p.Ingredients)
                    {
                        Console.Write("Ingredients: {0} ", i.Name+",");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Price:{0} ", p.Price);
                }

            }
        }

       
        public static void Order(string name)
        {
            using (var _context = new CafeAppDbContext())
            {
                var dish = _context.Dishes.First(d => d.Name == name);

                var cook = (from c in _context.Cooks
                            where c.Dishes.DishesId==dish.DishesId   
                                      select c).ToList();

                foreach (var c in cook)
                {
                    Console.WriteLine("Name:{0} , OrderCount: {1}", c.Name,c.OrderCount);
                }
            }
        }



       
    }
}