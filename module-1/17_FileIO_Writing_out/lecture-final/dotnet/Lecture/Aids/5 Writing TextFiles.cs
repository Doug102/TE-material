﻿using System;
using System.IO;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {
            string directory = Environment.CurrentDirectory;
            string filename = "output.txt";
            string fullPath = Path.Combine(directory, filename);
            // string fullPath = @"C:\NicePlace\output.txt";

            // Creates a new stream writer
            // FALSE indicates that the file should be overwritten instead of appended to
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                // Prints the current datetime
                sw.WriteLine(DateTime.UtcNow);

                // Prints Hello World!
                sw.Write("Hello ");
                sw.Write("World!");

                // Prints blank line
                sw.WriteLine();

                // Prints
                // Tech
                // Elevator
                sw.WriteLine("Tech");
                sw.WriteLine("Elevator");
            }

            // After the using statement ends, file has now been written
            // and closed for further writing
        }
    }
}