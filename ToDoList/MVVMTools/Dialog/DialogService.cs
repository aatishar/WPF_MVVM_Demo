using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MVVMTools.Dialog
{
    public class DialogService : IDialogService
    {
        private IServiceProvider serviceProvider;
        private IMVVMApplication application;
        public DialogService(IServiceProvider serviceProvider, IMVVMApplication application )
        {
            this.serviceProvider = serviceProvider;
            this.application = application;
        }
        public void ShowDialog<TParameter, TResult>(string dialogName, TParameter parameter, Action<TResult?> callback)
        {
            var dialog = new DialogWindow();
            dialog.Owner = Application.Current.MainWindow;

            var viewViewModelPairValue = application.ViewViewModelPairs[dialogName];
            var view = serviceProvider.GetRequiredService(viewViewModelPairValue.view);
            var viewModel = serviceProvider.GetRequiredService(viewViewModelPairValue.viewModel);

            (view as UserControl)!.DataContext = viewModel;
            
            var dialogViewModel = viewModel as Dialog<TParameter, TResult>;
            if (dialogViewModel is not null)
            {
                dialogViewModel.RequestClose = (result) =>
                {
                    callback(result);
                    dialogViewModel.OnCloseDialog();
                    dialog.Close();
                };

                dialogViewModel.Close = () =>
                {
                    callback(default);
                    dialogViewModel.OnCloseDialog();
                };

                dialogViewModel.OnOpenDialog(parameter);
                dialog.Title = dialogViewModel.Tittle;
            }

            dialog.DialogViewContainer.Content = view;
            dialog.Show();
        }
    }
}
