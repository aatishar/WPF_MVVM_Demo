using System.Collections.Generic;

namespace MVVMTools
{
    public interface INavigator
    {
        void Navigate(string viewName, IDictionary<string, object>? parameters = null);
    }
}