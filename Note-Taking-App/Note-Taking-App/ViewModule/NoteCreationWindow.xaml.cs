using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Note_Taking_App.Module;

namespace Note_Taking_App.ViewModule
{
    /// <summary>
    /// Interaction logic for NoteCreationWindow.xaml
    /// </summary>
    public partial class NoteCreationWindow : Window
    {
        private readonly string _path;
        private readonly string _recommendedName;

        private ObservableCollection<FileName> _fileNames;
        private Action<ObservableCollection<FileName>> _listContent;

        public NoteCreationWindow(string recommendedName, string path, ref ObservableCollection<FileName> fileNames, Action<ObservableCollection<FileName>> ListContent)
        {
            _fileNames = fileNames;
            _listContent = ListContent;

            _recommendedName = recommendedName;
            _path = path;
            InitializeComponent();
            NoteName.Text = recommendedName;
        }

        private void CreateNote()
        {
            if (!File.Exists(System.IO.Path.Combine(_path, string.Concat(NoteName.Text, ".txt"))))
            {
                var noteFile = File.Create(System.IO.Path.Combine(_path, string.Concat(NoteName.Text, ".txt")));
                noteFile.Close();

                _listContent(_fileNames);

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
                CreateNote();
            }

        }

        private void Continue_Click(object sender, EventArgs e)
        {
            CreateNote();
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
