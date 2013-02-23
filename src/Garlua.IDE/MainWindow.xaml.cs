using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Garlua.IDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Environment Settings
        /// </summary>
        protected Steam.Environment SteamEnv;

        /// <summary>
        /// Most recent selected Project Path
        /// </summary>
        String LastProjectPath;

        public MainWindow(Steam.Environment steamEnv)
        {
#if !DEBUG
            // Show Splash in release version
            System.Threading.Thread.Sleep(2000);
#endif
            InitializeComponent();

            SteamEnv = steamEnv;

            labelAccountName.Content = "Account: " + SteamEnv.AccountName;
        }

        #region Window Actions
        private void Minimize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        #endregion

        #region Menu

        /// <summary>
        /// Open nieuw dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult Result = dialog.ShowDialog();

            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dialog.SelectedPath);

                LastProjectPath = dialog.SelectedPath;

                projectExplorerTree.Items.Clear();

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    TreeViewItem treeViewItem = new TreeViewItem()
                    {
                        Header = file.Name,
                        Tag = file.FullName
                    };

                    treeViewItem.MouseDoubleClick += treeViewItem_MouseDoubleClick;
                    projectExplorerTree.Items.Add(treeViewItem);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(LastProjectPath);

            String LuaPath = System.IO.Path.Combine(SteamEnv.GarrysModPath, "lua");

            foreach (FileInfo File in dirInfo.GetFiles("*.lua"))
            {
                System.IO.File.Copy(File.FullName, System.IO.Path.Combine(LuaPath, File.Name));
            }
        }

        /// <summary>
        /// Start a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Wizards.ProjectWizard projectWizard = new Wizards.ProjectWizard();
            projectWizard.ShowDialog();
        }

        #endregion

        /// <summary>
        /// Add a new document with scintilla
        /// </summary>
        protected void AddNewDocument(string Filename = null)
        {
            AvalonDock.Layout.LayoutDocument Doc = new AvalonDock.Layout.LayoutDocument()
            {
                Title = "New Document"
            };

            Scintilla.ScintillaControl Editor = new Scintilla.ScintillaControl();

            // Change title to the filename when its available
            if (false == String.IsNullOrEmpty(Filename))
            {
                Editor.scintillaEditor1.Text = System.IO.File.ReadAllText(Filename);
                Doc.Title = System.IO.Path.GetFileName(Filename);
                
            }

            Doc.Content = new WindowsFormsHost()
            {
                Child = Editor
            };

            centerDocuments.Children.Add(Doc);

            Editor.scintillaEditor1.Lexing.Colorize();
            centerDocuments.SelectedContentIndex = centerDocuments.ChildrenCount - 1;
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String Filename = (projectExplorerTree.SelectedItem as TreeViewItem).Tag.ToString();
            AddNewDocument(Filename);
        }

        private void MenuNewSwep_Click(object sender, RoutedEventArgs e)
        {
            AvalonDock.Layout.LayoutDocument Doc = new AvalonDock.Layout.LayoutDocument()
            {
                Title = "New Weapon",
                Content = new Wizards.SwepWizard()
            };

            centerDocuments.Children.Add(Doc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (new Service.GameController()).RunIngameCommand("lua_openscript hello.lua");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            (new Service.GameController()).LaunchGame();
        }
    }
}
