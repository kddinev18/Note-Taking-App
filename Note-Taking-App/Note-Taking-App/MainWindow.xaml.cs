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

namespace Note_Taking_App
{
    public class FileName
    {
        public FileName()
        {
            name = String.Empty;
        }
        public FileName(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<FileName> fileNames { get; set; }
        private readonly string _path;
        public MainWindow()
        {
            InitializeComponent();
            _path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Notes");
            ListContent();
            this.DataContext = this;
        }
        public void ListContent()
        {
            Directory.CreateDirectory(_path);
            fileNames = new ObservableCollection<FileName>(new DirectoryInfo(_path).GetFiles()
                .Select(o => new FileName(o.Name))
                .ToList<FileName>());

            NotesList.ItemsSource = fileNames;
            NotesList.DataContext = fileNames;
        }
        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var note = new NoteCreationWindow(NotesCalendar.SelectedDate.Value.ToString("dd-MM-yyyy"),_path);
            note.Show();
            this.Close();
        }

    }
}
