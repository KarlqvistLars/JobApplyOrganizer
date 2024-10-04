using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JobApplyOrganizer
{
    public class MakeHTML
    {
        enum Type
        {
            TXT_Small = 0,
            TXT = 1,
            PDF = 2,
            FOLD = 3,
        }
        public MakeHTML()
        {
        }

        public void CreateHTML(String pagename, String installpath, DateTime date)
        {
            String jobPath = installpath + "\\P" + date.ToString("yyyyMMdd") + "_" + pagename + "\\";
            string templatePath = installpath + "\\Templates\\";
            if (!Directory.Exists(jobPath))
            {
                Directory.CreateDirectory(jobPath);
                CopyDirectory(templatePath, jobPath, true);
            }
            String fullpath = jobPath + pagename + ".html";
            Console.WriteLine(fullpath);

            //Pass the filepath and filename to the StreamWriter Constructor
            if (!File.Exists(fullpath))
            {
                // TODO: SKapa loop med hjälp av inlästa biblioteks sorter
                String[] txtFiles = SearchFolders(Type.TXT, installpath);
                //String[] pdfFiles = SearchFolders(Type.PDF, installpath);

                MakeHeader(pagename, fullpath);
                MakeBodyPart(Type.TXT_Small, pagename, fullpath, "Kontakt.txt");
                MakeFooter(pagename, fullpath);
            }
            else
            {
                Console.WriteLine("File already exist");
            }
        }

        public void MakeHeader(String title, String fullpath)
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(fullpath))
            {
                try
                {
                    //Write a line of text
                    sw.WriteLine("<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"cp-1252\">\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<title>" + title + "</title>\n");
                    sw.WriteLine("<link href=\"https:\\\\fonts.googleapis.com\\css2?family=Poppins:wght@400;500;600&display=swap\"\nrel=\"stylesheet\"/>");
                    sw.WriteLine("<style>\nbody {\nmargin: 15px; margin-left: 200px; \nbackground:  white;\nfont-family: \"Euclid Circular A\", \"Poppins\";\ncolor: #121212;\nheight: 100vh;\n}\n");
                    sw.WriteLine("footer {\r\nwidth: 110%;\r\nbackground-color: blue;\r\ncolor: white;\r\npadding-left: 200px;\r\ntranslate: -200px;\r\n}\n");
                    sw.WriteLine("a:link {\ncolor: #121212;\ntext-decoration: none;\n}\na:hover {\ncolor: #121212;\ntext-decoration: none;\nfont-weight: 900;\n}\na:visited {\ntext-decoration: none;\ncolor: #121212;\n}\n");
                    sw.WriteLine(".pdf-button { \nheight: 30px;\nwidth: 100px;\n margin-left: 10px; \n translate: 0 -15px; \n}");
                    sw.WriteLine("</style>\n</head>\n<body>\n<h3>Content in " + fullpath + "</h3>\n");
                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }

        public void MakeBodyPart(Enum type, String title, String fullpath, String file)
        {
            Console.WriteLine("Make body");
            using (StreamWriter sw = File.AppendText(fullpath))
            {
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    //Write a line of text
                    sw.WriteLine("<iframe class =\"pdf\" src=\"" + file + "\" width = \"800\" height = \"500\" ></iframe >\n");
                    sw.WriteLine("<a href=\"" + file + "\"; target=\"_blank\">\n<button class=\"pdf-button\">\nOpen\n</button></a></br></br>\n");
                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }

        public void MakeFooter(String title, String fullpath)
        {
            Console.WriteLine("Make Footer");
            using (StreamWriter sw = File.AppendText(fullpath))
            {
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    //Write a line of text
                    sw.WriteLine("</body>\n<footer><br><p>Ansökan till " + title + "</p><br><br><br><br><br><br></footer></html>");
                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }            
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        String[] SearchFolders(Enum type, String path)
        {
            // TODO: Sök jobbibiloteket efter ingående
            List<string> searchFiles = Directory.GetFiles(path, "*.*").ToList();
            List<string> searchDirs = Directory.GetDirectories(path, "*.*").ToList();

            foreach (string files in searchFiles)
            {
                String str1 = @"\\";
                String str2 = @"\";
                String f = files.Replace(str1, str2);
                Console.WriteLine("Search test files + "+ f.ToString());
            }

            foreach (string folder in searchDirs)
            {
                String str1 = @"\\";
                String str2 = @"\";
                String f = folder.Replace(str1,str2);
                Console.WriteLine("Search test Dirs + " + f.ToString());
            }

            return new String[] { "", "" };
        }
    }
}




