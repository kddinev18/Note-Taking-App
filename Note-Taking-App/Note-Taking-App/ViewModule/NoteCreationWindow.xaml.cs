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
using Note_Taking_App_BusinessLogic;

namespace Note_Taking_App.ViewModule
{
    /// <summary>
    /// Interaction logic for NoteCreationWindow.xaml
    /// </summary>
    public partial class NoteCreationWindow : Window
    {
        private readonly string _path;
        private readonly string _recommendedName;

        private Action<ObservableCollection<FileName>> _listContent;

        public NoteCreationWindow(string recommendedName, string path, Action<ObservableCollection<FileName>> ListContent)
        {
            _listContent = ListContent;

            _recommendedName = recommendedName;
            _path = path;
            InitializeComponent();
            NoteName.Text = recommendedName;
        }

        private void NoteName_KeyDown(object sender, KeyEventArgs e)
        {
            //Check if the user has pressed "Enter" while he is on "username" input field
            if (e.Key == Key.Enter)
            {
                Note_Taking_App_BusinessLogic.Note_Taking_App_BusinessLogic.CreateNote(_path, NoteName.Text);
            }

        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Note_Taking_App_BusinessLogic.Note_Taking_App_BusinessLogic.CreateNote(_path, NoteName.Text);
            _listContent(Note_Taking_App_BusinessLogic.Note_Taking_App_BusinessLogic.GetNoteNames(_path));
            this.Close();
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
