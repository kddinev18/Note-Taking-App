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

        private bool _isContentChanged = false;
        private bool _isNameChanged = false;
        public NoteEditor(string content, string name, string path)
        {
            InitializeComponent();
            _archivedNoteName = name; 
            NoteNameProp = name;
            NoteContentProp = content;
            NoteName.Text = NoteNameProp;
            NoteContent.Text = NoteContentProp;
            this.DataContext = this;
        }
        ~NoteEditor()
        {
            /*if(NoteNameProp != _archivedNoteName)
            {
                try
                {
                    File.Move(_archivedNoteName, NoteNameProp);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    var noteEdit = new NoteEditor();
                }
            }*/
            throw new NotImplementedException(";-;");
        }

        private void NoteContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isContentChanged = true;
        }

        private void NoteName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isNameChanged = true;
        }
    }
}
