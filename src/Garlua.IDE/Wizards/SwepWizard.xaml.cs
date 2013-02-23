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

namespace Garlua.IDE.Wizards
{
    /// <summary>
    /// Interaction logic for SwepWizard.xaml
    /// </summary>
    public partial class SwepWizard : UserControl
    {
        public ViewModel.SwepWizardModel SwepModel { get; set; }

        public SwepWizard()
        {
            InitializeComponent();

            this.SwepModel = new ViewModel.SwepWizardModel();
        }

        private void ExportTemplate_Click(object sender, RoutedEventArgs e)
        {
            Steam.Environment SteamEnv = new Steam.Environment();

            Service.Template.WeaponTemplate weaponTemplate = new Service.Template.WeaponTemplate();
            weaponTemplate.GenerateTemplate(SwepModel, System.IO.Path.Combine(SteamEnv.WeaponsPath, SwepModel.PrintName.Replace(' ', '_') + ".lua"));

            (new Service.GameController()).RunIngameCommand("+reload");
        }
    }
}
