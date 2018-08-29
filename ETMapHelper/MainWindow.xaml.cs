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
using System.Windows.Navigation;
using System.IO;
using ETMapHelper.Objects;
using Microsoft.Win32;
using System.Diagnostics;

namespace ETMapHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string line = "")
        {
            consoleControl.Text += $"\n{DateTime.Now.ToString("hh:mm:ss")} - {line}";

            consoleControl.ScrollToEnd();
        }

        private void LogV(string line = "")
        {
            if (Properties.Settings.Default.Verbose)
                Log(line);
        }

        private void ClearLog()
        {
            consoleControl.Text = "";
        }

        private void buttonAseModelFix_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "ASE-models (*.ase)|*.ase";

            if (fileDialog.ShowDialog() != true) return;

            var fileName = fileDialog.FileName;
            var fileType = Path.GetExtension(fileName).ToLower();

            if ( fileType != ".ase")
            {
                var dialogResult = MessageBox.Show(
                    $"Filetype is \"{fileType}\" instead of \".ase\", proceed anyway?",
                    "Incorrect filetype",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (dialogResult != MessageBoxResult.Yes) return;
            }



            var model = new AseModel(fileName);
            var reply = model.FixBitmaps();
            Log(reply);
        }
    }
}
