using System;

namespace MVVMTools.Dialog
{
    public abstract class DialogBase: BindableBase
    {
        public required string Tittle { get; set; } = "Dialog";

        public abstract void OnCloseDialog();

        public abstract bool CanCloseDialog();

        public Action? Close;
    }
}
