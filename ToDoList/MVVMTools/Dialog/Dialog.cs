using System;

namespace MVVMTools.Dialog
{
    public abstract class Dialog<TParameter, TResult> : DialogBase
    {
        public Action<TResult?>? RequestClose;

        public abstract void OnOpenDialog(TParameter parameters);
    }
}
