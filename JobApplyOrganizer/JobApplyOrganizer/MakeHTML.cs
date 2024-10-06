using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        String[] kontakt = new String[4];
        Utilities Util = new Utilities();
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
        public string CreateHTML(String[] fileList, String pagename, String jobPath, String templatePath, DateTime date)
        {
            String fullpath = jobPath +"\\"+ pagename + ".html";
            fullpath = Util.CleanPath(fullpath, "\\\\", "\\");
            //Pass the filepath and filename to the StreamWriter Constructor
            if (!File.Exists(fullpath))
            {
                // TODO: SKapa loop med hjälp av inlästa biblioteks sorter
                MakeHeader(pagename, fullpath.Replace("\\\\","\\"));
                foreach (var file in fileList)
                {
                    if (file.Contains("Kontakt.txt"))
                    {
                        MakeBodyPart(Type.TXT_Small, pagename, fullpath, Util.CleanPath(jobPath+"Kontakt.txt","\\\\","\\"));
                        Console.WriteLine("In MakeHTML rad 42 fullpath: {0}", fullpath);
                    }
                }
                foreach (var file in fileList)
                {
                    if (file.Contains(".pdf"))
                    {
                        String temp = file.Replace(jobPath, "");
                        MakeBodyPart(Type.PDF, pagename, fullpath, file);
                    }
                }
                foreach (var file in fileList)
                {
                    if (file.Contains(".txt") && !(file.Contains("Kontakt.txt")))
                    {
                        String temp = file.Replace(jobPath, "");
                        MakeBodyPart(Type.TXT, pagename, fullpath, file);
                    }
                }
                MakeFooter(pagename, fullpath);
            }
            else
            {
                Console.WriteLine("File already exist");
            }
            return jobPath+"\\Kontakt.txt";
        }
        public void MakeHeader(String title, String fullpath)
        {
            // Create a file to write to.
            Console.WriteLine("Make Header");
            using (StreamWriter sw = File.CreateText(fullpath))
            {
                try
                {
                    //Write a line of text
                    sw.WriteLine("<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"cp-1252\">\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<title>" + title + "</title>\n");
                    sw.WriteLine("<link href=\"https:\\\\fonts.googleapis.com\\css2?family=Poppins:wght@400;500;600&display=swap\"\nrel=\"stylesheet\"/>");
                    sw.WriteLine("<style>\nbody " +
                        "{\nmargin: 15px; " +
                        "margin-left: 200px;" +
                        " \nbackground: " +
                        " white;\nfont-family: \"Euclid Circular A\", \"Poppins\";" +
                        "\ncolor: #121212;" +
                        "\nheight: 100vh;\n}" +
                        "\n");
                    sw.WriteLine("footer {\nwidth: 110%;" +
                        "\nbackground-color: blue;\ncolor: white;" +
                        "\npadding-left: 200px;" +
                        "\ntranslate: -200px;" +
                        "\n}\n");
                    sw.WriteLine(".smf { \nfont-size: small\n}");
                    sw.WriteLine("a:link {\ncolor: #121212;\n" +
                        "text-decoration: none;\n}\na:hover {\ncolor: #121212;\n" +
                        "text-decoration: none;\n" +
                        "font-weight: 900;\n}\n" +
                        "a:visited {\n" +
                        "text-decoration: none;\n" +
                        "color: #121212;\n}\n");
                    sw.WriteLine(".pdf-button { \n" +
                        "height: 30px;\n" +
                        "width: 100px;\n " +
                        "margin-left: 10px; \n " +
                        "translate: 0 -15px; \n}");
                    sw.WriteLine("</style>\n</head>\n" +
                        "<body>\n<h3>Content in <br>\r\n<div class=\"smf\"> " + fullpath + "</div></h3>\n");
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
            if (type.ToString() == Type.TXT_Small.ToString())
            {
                using (StreamWriter sw = File.AppendText(fullpath))
                {
                    try
                    {
                        String path = file;
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+path+"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        OpenKontaktTXT(path);
                        //Pass the filepath and filename to the StreamWriter Constructor
                        //Write a line of text
                        sw.WriteLine("<iframe class =\"pdf\" src=\"" + file + "\" width = \"800\" height = \"120\" ></iframe ></br></br>\n");
                        sw.WriteLine("<a href=\"" + String.Format("{0}",kontakt[3]).Trim()  + "\"; target=\"_blank\">Jobb annonsen</a></br></br>\n");
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
            } else if (type.ToString() == Type.PDF.ToString())
            {
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
            else if (type.ToString() == Type.TXT.ToString())
            {
                using (StreamWriter sw = File.AppendText(fullpath))
                {
                    try
                    {
                        //Pass the filepath and filename to the StreamWriter Constructor
                        //Write a line of text
                        sw.WriteLine("<iframe class =\"pdf\" src=\"" + file + "\" width = \"800\" height = \"250\" ></iframe >\n");
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
            Console.WriteLine(path);

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
        void OpenKontaktTXT(String path)
        {
            String line;
            Console.WriteLine("##########  "+path);
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line.StartsWith("Namn:"))
                    {
                        kontakt[0] = line.Remove(0, 5);
                    }
                    else if (line.StartsWith("Tele:"))
                    {
                        kontakt[1] = line.Remove(0, 5);
                    }
                    else if (line.StartsWith("Mail:"))
                    {
                        kontakt[2] = line.Remove(0, 5);
                    }
                    else if (line.StartsWith("URL:"))
                    {
                        kontakt[3] = line.Remove(0, 4);
                        Console.WriteLine(" URL link: {0}", kontakt[3]);
                    }
                    //write the line to console window
                    Console.WriteLine(line + "från Kontakt.txt");
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
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
}




