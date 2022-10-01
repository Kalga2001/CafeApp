using CafeApp.DAL.Context;
using CafeApp.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.BLL.Helpers
{
   public class BussinessLogic
    {
       public void Result()
        {
            try
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
                            Console.Write("Ingredients: {0} ", i.Name + ",");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Price:{0} ", p.Price);
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: {0} , DateTime: {1}", ex.InnerException, DateTime.Now);
            }
        }

        public static List<Cooks> GetCookWithMinimalOrderCount() //Получение повара у которого наименьшее количество блюд
        {
            var list=new List<Cooks>();
            try
            {
                using (var _context = new CafeAppDbContext())
                {
                    var cooks = _context.Cooks.ToList();
                    int min = cooks.Select(x => x.OrderCount).Min();
                    int val = 0;

                    var cook = _context.Cooks.Where(x => x.OrderCount == min || x.OrderCount == val).ToList();

                    list = cook;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0} , DateTime: {1}", ex.InnerException, DateTime.Now);
            }

            return list;
        }

        public static int CookingTime(string name)
        {
            int time = 0;
            try
            {
                using (var _context = new CafeAppDbContext())
                {
                    var dish = _context.Dishes.First(n => n.Name == name);

                    time = dish.cookingTime;

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: {0} , DateTime: {1}", ex.InnerException, DateTime.Now);
            }

            return time;
        }


        public void OrderDish(string dishName, string cookName) //Выбираем блюдо и повара  
        {
            if(string.IsNullOrWhiteSpace(dishName))
            {
                Console.WriteLine("You do not enter dish name!");
            }

            if (string.IsNullOrWhiteSpace(cookName))
            {
                Console.WriteLine("You do not enter cook name!");
            }

            try
            {
                using (var _context = new CafeAppDbContext())
                {

                    var cooks = GetCookWithMinimalOrderCount();
                    bool c = cooks.Any(x => x.Name == cookName);

                    if (!c)
                    {
                        Console.WriteLine("Error!");
                    }

                    int time = CookingTime(dishName);

                    Console.WriteLine("You ordered: {0} , it will be cooked after: {1} ", dishName, time);

                }
            }
     
             catch (Exception ex)
            {
                Console.WriteLine("Error: {0} , DateTime: {1}", ex.InnerException, DateTime.Now);
            }
        }
        

        public void DisplayFreeCooks()
        {
            List<Cooks> cooks = GetCookWithMinimalOrderCount();

            var result = cooks.DistinctBy(x => x.Name).ToList();

            foreach(var r in result)
            {
                Console.WriteLine("Free cooks: {0}", r.Name);
            }
           
            
        }

        public async void UpdateOrders(string cookName,string word=null)
        {
            try
            {
                using (var _context = new CafeAppDbContext())
                {
                    var cook = _context.Cooks.First(n => n.Name == cookName);

                    var result = _context.Cooks.Where(n => n.Name == cook.Name).ToList();


                    if (cook.OrderCount < 5)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            result[i].OrderCount += 1;
                            _context.Entry(result[i]).State = EntityState.Modified;
                            _context.Cooks.Update(result[i]);
                            _context.SaveChanges();
                        }
                    }

                    if (cook.OrderCount == 5)
                    {
                        Console.WriteLine("Cook is busy");
                    }


                    if (word == "Update")
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            result[i].OrderCount = 0;
                            _context.Entry(result[i]).State = EntityState.Modified;
                            _context.Cooks.Update(result[i]);
                            _context.SaveChanges();
                        }
                    }
                    Console.WriteLine("We have received your order ");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0} , DateTime: {1}",ex.InnerException,DateTime.Now);
            }
            
        }
    }
}
