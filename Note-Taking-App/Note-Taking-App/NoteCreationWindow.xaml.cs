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
            NoteName.Text = recommendedName.Split(".")[0];
        }

        private void NoteName_KeyDown(object sender, KeyEventArgs e)
        {
            //Check if the user has pressed "Enter" while he is on "username" input field
            if (e.Key == Key.Enter)
            {
                if (!File.Exists(_path))
                {
                    File.Create(System.IO.Path.Combine(_path, NoteName.Text));
                }
                else
                {
                    //error
                }
            }

        }

        private void NoteName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NoteName.Text == _recommendedName)
                NoteName.Text = "";
            else
                NoteName.SelectAll();
        }

        private void NoteName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NoteName.Text == "")
                NoteName.Text = _recommendedName;
        }

    }
}
