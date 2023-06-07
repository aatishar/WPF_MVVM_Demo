using MVVMTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.ModelView;
using ToDoList.View;
using ToDoList.ViewModel;

namespace ToDoList
{
    public class MainWindowViewModel : BindableBase
    {
        private ListOfToDoListViewModel listOfToDoListViewModel = new();
        private ToDoListEditorViewModel toDoListEditorViewModel = new();
        private BindableBase currentViewModel = default!;

        public MainWindowViewModel()
        {
            var application = new MVVMApplication();
            application.RegisterView<ListOfToDoListView, ListOfToDoListViewModel>();
            application.RegisterView<ToDoListEditorView, ToDoListEditorViewModel>();
            application.RegisterDiaglog<ToDoItemEditorView, ToDoItemEditorViewModel>("ToDoItemDialog");
            application.Build();

            CurrentViewModel = listOfToDoListViewModel;
            SwitchView = new DelegateCommand(() =>
            {
                switch (currentViewModel)
                {
                    case ListOfToDoListViewModel:
                        CurrentViewModel = toDoListEditorViewModel;
                        application.Navigator.Navigate("ToDoListEditorView");
                        application.DialogService.ShowDialog("ToDoItemDialog", new ToDoItemModelView(), (ToDoItemModelView? toDoItem) => { });
                        break;
                    case ToDoListEditorViewModel:
                        CurrentViewModel = listOfToDoListViewModel;
                        application.Navigator.Navigate("ListOfToDoListView");
                        break;
                    default:
                        break;
                }
            });
        }

        public ICommand SwitchView { get; set; }

        public BindableBase CurrentViewModel
        {
            get => currentViewModel;
            set => this.SetProperty(ref currentViewModel, value);
        }
    }
}
