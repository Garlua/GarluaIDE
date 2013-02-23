using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Garlua.IDE.Wizards
{
    /// <summary>
    /// Interaction logic for ProjectWizard.xaml
    /// </summary>
    public partial class ProjectWizard : Window
    {
        public ProjectWizard()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            (new GamemodeWizard()).ShowDialog();
        }
    }
}
