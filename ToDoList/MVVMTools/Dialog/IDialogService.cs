using System;

namespace MVVMTools.Dialog
{
    public interface IDialogService
    {
        void ShowDialog<TParameter, TResult>(string dialogName, TParameter parameter, Action<TResult?> callback);
    }
}
