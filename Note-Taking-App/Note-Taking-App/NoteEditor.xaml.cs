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

namespace Note_Taking_App
{
    /// <summary>
    /// Interaction logic for NoteEditor.xaml
    /// </summary>

    public partial class NoteEditor : Window
    {
        public string NoteNameProp { get; set; }
        public string NoteContentProp { get; set; }
        public NoteEditor(string content, string name)
        {
            InitializeComponent();
            NoteNameProp = name;
            NoteContentProp = content;
            NoteName.Text = NoteNameProp;
            NoteContent.Text = NoteContentProp;
            this.DataContext = this;
        }

    }
}
