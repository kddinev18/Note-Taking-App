using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Note_Taking_App
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
            _path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Notes");
            ListContent();
        }
        public void ListContent()
        {
            Directory.CreateDirectory(_path);
            var fileNames = new DirectoryInfo(_path).GetFiles()
                .Select(o => o.Name)
                .ToList<string>();

            NotesList.ItemsSource = fileNames;
        }
        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var note = new NoteCreationWindow(NotesCalendar.SelectedDate.Value.ToString("dd-MM-yyyy"),_path);
            note.Show();
            this.Close();
        }

    }
}
