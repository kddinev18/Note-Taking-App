using System;
using System.IO;
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

namespace Note_Taking_App
{
    /// <summary>
    /// Interaction logic for NoteCreationWindow.xaml
    /// </summary>
    public partial class NoteCreationWindow : Window
    {
        private readonly string _path;
        private readonly string _recommendedName;

        public NoteCreationWindow(string recommendedName, string path)
        {
            _recommendedName = recommendedName;
            _path = path;
            InitializeComponent();
            NoteName.Text = recommendedName;
        }

        private void OpenMainWindow()
        {
            if (!File.Exists(System.IO.Path.Combine(_path, string.Concat(NoteName.Text, ".txt"))))
            {
                File.Create(System.IO.Path.Combine(_path, string.Concat(NoteName.Text, ".txt")));
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The note already exist", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NoteName_KeyDown(object sender, KeyEventArgs e)
        {
            //Check if the user has pressed "Enter" while he is on "username" input field
            if (e.Key == Key.Enter)
            {
                OpenMainWindow();
            }

        }

        private void Continue_Click(object sender, EventArgs e)
        {
            OpenMainWindow();
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
