using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Enums;

namespace ToDoList.ModelView
{
    public class TaskModelView : BindableBase
    {
        private string title = String.Empty;
        private Status status = default!;
        private DateTime creationDate = DateTime.Now;
        private ObservableCollection<ToDoItemModelView> toDoItems = new();

        public string Title
        {
            get => title;
            set => this.SetProperty(ref title, value);
        }

        public Status Status
        {
            get => status;
            set => this.SetProperty(ref status, value);
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set => this.SetProperty(ref creationDate, value);
        }

        public ObservableCollection<ToDoItemModelView> ToDoItems
        {
            get => toDoItems;
            set => this.SetProperty(ref toDoItems, value);
        }
    }
}
