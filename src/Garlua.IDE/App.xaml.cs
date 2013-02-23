using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Garlua.IDE
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            UnityServiceLocator locator = new UnityServiceLocator(ConfigureUnityContainer());
            ServiceLocator.SetLocatorProvider(() => locator);

            MainWindow = ServiceLocator.Current.GetInstance<MainWindow>();
            MainWindow.Show();
        }

        private IUnityContainer ConfigureUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterInstance<Steam.Environment>(new Steam.Environment());

            return container;
        }
    }
}
