using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;

namespace Note_Taking_App_BusinessLogic
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

    public static class Note_Taking_App_BusinessLogic
    {
        // Creates notes directory if they don't exist
        public static void CreateNoteDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        // Returns the current directory where the notes are stored at
        public static string GetNotePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Notes");
        }

        // Returns all note names
        public static ObservableCollection<FileName> GetNoteNames(string path)
        {
            var fileNames = new ObservableCollection<FileName>(new DirectoryInfo(path).GetFiles("*.txt")
                .Select(o => new FileName(o.Name))
                .ToList<FileName>());
            return fileNames;
        }

        // Deletes a note
        public static void DeleteNote(string path, string noteName)
        {
            File.Delete(Path.Combine(path, noteName));
        }

        // Returns all the text in a note
        public static string ReadNote(string path, string noteName)
        {
            return File.ReadAllText(Path.Combine(path, noteName));
        }

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
