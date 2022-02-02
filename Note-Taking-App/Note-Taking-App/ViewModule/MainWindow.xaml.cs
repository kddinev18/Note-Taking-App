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
using Note_Taking_App.Module;

namespace Note_Taking_App.ViewModule
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<FileName> fileNames;// { get; set; }
        private readonly string _path;
        public MainWindow()
        {
            InitializeComponent();
            _path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Notes");
            ListContent(fileNames);
            this.DataContext = this;
        }
        public MainWindow(string newFileName, string fileContent, string oldFileName)
        {
            InitializeComponent();
            _path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Notes");
            ListContent(fileNames);
            this.DataContext = this;
        }
        public void ListContent(ObservableCollection<FileName> fileNames)
        {
            Directory.CreateDirectory(_path);
            fileNames = new ObservableCollection<FileName>(new DirectoryInfo(_path).GetFiles("*.txt")
                .Select(o => new FileName(o.Name))
                .ToList<FileName>());

            NotesList.ItemsSource = fileNames;
            NotesList.DataContext = fileNames;
        }
        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var note = new NoteCreationWindow(NotesCalendar.SelectedDate.Value.ToString("dd-MM-yyyy"),_path,
                ref fileNames,ListContent);
            note.Show();
        }

        private void Delete_Note(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            FileName fileName = button.DataContext as FileName;
            File.Delete(System.IO.Path.Combine(_path, fileName.name));
            ListContent(fileNames);
        }

        private void Open_Note(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            FileName fileName = button.DataContext as FileName;
            string content = File.ReadAllText(System.IO.Path.Combine(_path, fileName.name));

            var noteEdit = new NoteEditor(content, fileName.name.Split(".txt")[0], _path, ref fileNames, ListContent);
            noteEdit.Show();
        }
    }
}
