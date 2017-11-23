using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Standard.Model;
using ToDoApp.Standard.SQLite;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDoItems { get; set; } = new ObservableCollection<ToDoItem>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        void Refresh()
        {
            this.ToDoItems.Clear();
            using (var context = new ToDoContext())
            {
                foreach (var toDo in context.ToDo)
                {
                    this.ToDoItems.Add(toDo);
                }
            }
        }

        void OnAddClicked(object sender, EventArgs e)
        {
            using (var context = new ToDoContext())
            {
                context.ToDo.Add(new ToDoItem
                {
                    Text = "Test"
                });

                context.SaveChanges();
            }

            this.Refresh();
        }
    }
}
