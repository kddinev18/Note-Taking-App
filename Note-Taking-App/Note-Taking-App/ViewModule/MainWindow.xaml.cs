using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Note_Taking_App.Model;

namespace Note_Taking_App.ViewModule
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _path;
        public MainWindow()
        {
            InitializeComponent();
            _path = MainWindowLogic.GetNotePath();
            MainWindowLogic.CreateNoteDirectory(_path);
            ListContent(MainWindowLogic.GetNoteNames(_path));
            this.DataContext = this;
        }
        public void ListContent(ObservableCollection<FileName> fileNames)
        {
            NotesList.ItemsSource = fileNames;
            NotesList.DataContext = fileNames;
        }
        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var note = new NoteCreationWindow(NotesCalendar.SelectedDate.Value.ToString("dd-MM-yyyy"),_path,ListContent);
            note.Show();
        }

        private void Delete_Note(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            FileName fileName = button.DataContext as FileName;
            MainWindowLogic.DeleteNote(_path, fileName.name);
            ListContent(MainWindowLogic.GetNoteNames(_path));
        }

        private void Open_Note(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            FileName fileName = button.DataContext as FileName;
            string content = MainWindowLogic.ReadNote(_path, fileName.name);

            var noteEdit = new NoteEditor(content, fileName.name.Split(".txt")[0], _path, ListContent);
            noteEdit.Show();
        }
    }
}
