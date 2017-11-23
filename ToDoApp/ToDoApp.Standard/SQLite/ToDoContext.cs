using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Standard.Model;
using Xamarin.Forms;

namespace ToDoApp.Standard.SQLite
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("MyDb.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");

        }

        public DbSet<ToDoItem> ToDo { get; set; }
    }
}
