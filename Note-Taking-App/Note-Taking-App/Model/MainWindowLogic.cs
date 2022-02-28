using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;

namespace Note_Taking_App.Model
{
    static class MainWindowLogic
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
    }
}
