using CafeApp.BLL.Helpers;
using CafeApp.DAL.Context;
using CafeApp.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CafeApp
{
    
    public class Program
    { 
        public static void Main(string[] args)
        {
            using (var _context = new CafeAppDbContext())
            {
                BussinessLogic logic = new BussinessLogic();
                logic.Result();
               
                bool enter = true;
                
                while (enter)
                {
                    Console.WriteLine("Please select..... ");
                    Console.WriteLine("1.View free cooks: ");
                    Console.WriteLine("2.Enter dishes: ");
                    Console.WriteLine("3.Exit");
                    Console.WriteLine("You enter: ");
                    int select = 0;
                    try
                    {
                            select = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: {0} , DateTime: {1}", ex.InnerException, DateTime.Now);  
                    }

                    switch (select)
                    {
                        case 1:
                            logic.DisplayFreeCooks();
                            break;
                        case 2:
                            Console.WriteLine("Please enter name: ");
                            string cookName = Console.ReadLine();

                            Console.WriteLine("Please enter food: ");
                            string dish = Console.ReadLine();
                            
                            logic.OrderDish(dish,cookName);
                            logic.UpdateOrders(cookName);
                            break;
                       
                        case 3:
                        default:
                            enter = false;
                            break;
                    }
                }
            }

        }

      
        //Выбираем блюдо -- по нему ищем повара у которого меньше заказов -- выбрали повара --обновили кол-во заказов --повторили операцию выбора

    }
}