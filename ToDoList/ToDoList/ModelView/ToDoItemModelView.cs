using MVVMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Enums;

namespace ToDoList.ModelView
{
    public class ToDoItemModelView : BindableBase
    {
        private string title = String.Empty;
        private Status status = default!;
        private DateTime creationDate = DateTime.Now;

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

    }
}
