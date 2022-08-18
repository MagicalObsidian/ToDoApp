using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ToDoApp.Api.Context
{
    public class ToDoAppContext :DbContext
    {
        public ToDoAppContext()
        {
                
        }

        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options)
        {

        }


        public DbSet<ToDo> Todos { get; set; }

        public DbSet<Memo> Memos { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
