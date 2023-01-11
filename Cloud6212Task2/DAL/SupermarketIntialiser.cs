using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Cloud6212Task2.Models;

namespace Cloud6212Task2.DAL
{
    /// <summary>    
    /// ##Notes
    /// Intialiser method to state how the database is created and predefined rows to enter
    /// By default the database is created on intial run and throw an exception if the model (hence columns) changes 
    /// </summary>
    /// 

    public class SupermarketIntialiser
    {
        public static void  Intialise(SupermarketContext context)
        {
            //checks if database exists in sql server
            //if !found then it will load it with these data 
            //else do nothing end
                // tutorial suggests using arrays instead of lists as a list ha an 0(1) time complexity to read vs a List with 0(n) -->0(4) in this case

            context.Database.EnsureCreated();
            if(context.Items.Any())
            {
                return;
            }

            var items = new Item[] {
                new Item{Name="Smarties",Price=32.99,Quantity="150g",ImageUrl=" ",FileName=" "},
                new Item{Name="Jik",Price=20.99,Quantity="1L",ImageUrl=" ",FileName=" "},
                new Item{Name="Sunflower Oil",Price=50.99,Quantity="4L",ImageUrl=" ", FileName = " "},
                new Item{Name="Fatti and Moni's Spaghetti",Price=22.99,Quantity="500g",ImageUrl=" ", FileName = " "},
            };
            foreach (var i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();
        }
    }
}
