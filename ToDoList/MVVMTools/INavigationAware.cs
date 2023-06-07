using System.Collections.Generic;

namespace MVVMTools
{
    public interface INavigationAware
    {
        void OnNavigateTo(IDictionary<string, object> parameters);

        void OnNavigateFrom();
    }
}
