using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.Model
{
    class NoteCreationWindowLogic
    {
        // Creates a note
        public static void CreateNote(string path, string noteName)
        {
            if (!File.Exists(Path.Combine(path, string.Concat(noteName, ".txt"))))
            {
                var noteFile = File.Create(System.IO.Path.Combine(path, string.Concat(noteName, ".txt")));
                noteFile.Close();
            }
            else
            {
                throw new Exception("The file already exists");
            }
        }
    }
}
