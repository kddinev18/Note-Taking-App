using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Interaction logic for NoteEditor.xaml
    /// </summary>

    public partial class NoteEditor : Window
    {
        public string NoteNameProp { get; set; }
        public string NoteContentProp { get; set; }

        private string _archivedNoteName;

        private readonly string _path;
        public NoteEditor(string content, string name, string path)
        {
            InitializeComponent();
            _path = path;
            _archivedNoteName = name; 
            NoteNameProp = name;
            NoteContentProp = content;
            NoteName.Text = NoteNameProp;
            NoteContent.Text = NoteContentProp;
            this.DataContext = this;
        }
        ~NoteEditor()
        {
            SaveChnages();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveChnages();
            MessageBox.Show("Chnaages saved", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveChnages()
        {
            if (NoteNameProp != _archivedNoteName)
            {
                try
                {
                    File.Move(System.IO.Path.Combine(_path, _archivedNoteName),
                              System.IO.Path.Combine(_path, NoteNameProp));
                    File.WriteAllText(System.IO.Path.Combine(_path, NoteNameProp), NoteContentProp);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                File.WriteAllText(System.IO.Path.Combine(_path, string.Concat(NoteNameProp, ".txt")), NoteContentProp);
            }
        }
    }
}
