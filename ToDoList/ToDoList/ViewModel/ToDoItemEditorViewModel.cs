using MVVMTools;
using MVVMTools.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ModelView;

namespace ToDoList.ViewModel
{
    public class ToDoItemEditorViewModel : Dialog<ToDoItemModelView, ToDoItemModelView>
    {
        public override bool CanCloseDialog()
        {
            return true;
        }

        public override void OnCloseDialog()
        {

        }

        public override void OnOpenDialog(ToDoItemModelView parameters)
        {
        }
    }
}
