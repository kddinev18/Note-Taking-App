using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.Model
{
    class NoteEditorWindowLogic
    {
        // Save changes to the note
        public static void SaveChnages(string path, string noteName, string archivedNoteName, string noteContent)
        {
            if (noteName != archivedNoteName)
            {
                File.Move(
                    Path.Combine(path, string.Concat(archivedNoteName, ".txt")),
                    Path.Combine(path, string.Concat(noteName, ".txt"))
                );
                File.WriteAllText(System.IO.Path.Combine(
                    path,
                    string.Concat(noteName, ".txt")),
                    noteName
                );
            }
            else
            {
                File.WriteAllText(
                    Path.Combine(
                        path,
                        string.Concat(noteName, ".txt")
                    ),
                    noteContent
                );
            }
        }
    }
}
