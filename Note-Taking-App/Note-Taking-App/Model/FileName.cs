using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Note_Taking_App.Model
{
    public class FileName
    {
        public FileName()
        {
            Name = String.Empty;
        }
        public FileName(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

        // Returns all note names
        public static ObservableCollection<FileName> GetNoteNames(string path)
        {
            var fileNames = new ObservableCollection<FileName>(new DirectoryInfo(path).GetFiles("*.txt")
                .Select(o => new FileName(o.Name))
                .ToList<FileName>());
            return fileNames;
        }
    }
}
