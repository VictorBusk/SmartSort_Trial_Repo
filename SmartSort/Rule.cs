using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartSort
{
    public class Rule
    {
        public string name { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public string keyWord { get; set; }
        public bool includeFolders { get; set; }
        public bool FoldersNeedKey { get; set; }
        public string fileExtension { get; set; }
        public bool keepSource { get; set; }
        public bool replaceFile { get; set; }
        public bool allFilesInKeyFolder { get; set; }
        private string destination_temp;
        private string source_temp;

        public Rule(string _name, string _source, string _destination, string _keyWord, string _fileExtension, bool _includeFolders, bool _FoldersNeedKey, bool _keepSource, bool _replaceFile, bool _allFilesInKeyFolder)
        {
            name = _name;
            source = _source;
            destination = _destination;
            keyWord = _keyWord;
            keepSource = _keepSource;
            fileExtension = _fileExtension;
            includeFolders = _includeFolders;
            destination_temp = _destination;
            source_temp = _source;
            FoldersNeedKey = _FoldersNeedKey;
            replaceFile = _replaceFile;
            allFilesInKeyFolder = _allFilesInKeyFolder;
        }

        public void executeRule()
        {
            SearchDirectory(source);
        }

        private void SearchDirectory(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    if (f.Substring(f.LastIndexOf(@"\")).Contains(keyWord) && f.Substring(f.LastIndexOf(@"\")).Contains(fileExtension))
                    {
                        moveFile(f);
                    }
                    else if (allFilesInKeyFolder)
                    {
                        moveFile(f);
                    }
                }
                if (includeFolders)
                {
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        if (FoldersNeedKey == true && d.Contains(keyWord))
                        {
                            source_temp = d.Replace(source, "");
                            destination_temp = destination + source_temp;
                            Directory.CreateDirectory(destination_temp);
                            SearchDirectory(d);
                        }
                        else
                        {
                            source_temp = d.Replace(source, "");
                            destination_temp = destination + source_temp;
                            Directory.CreateDirectory(destination_temp);
                            SearchDirectory(d);
                        }
                    }
                }
            }
            catch (System.Exception) { }
        }
        private void moveFile(string path)
        {
            var fileDestination = destination + path.Replace(source, "");
            string filename = fileDestination.Substring(path.LastIndexOf(@"\"));
            char left = '[', right = ']';
            if (filename.Contains(left) && filename.Contains(right))
            {
                string folderpath = fileDestination.Substring(0, path.LastIndexOf(@"\"));
                string newfolder = inbetween(filename, left.ToString(), right.ToString());
                if (!Directory.Exists(folderpath + newfolder))
                {
                    Directory.CreateDirectory(folderpath + newfolder);
                }
                filename = RemoveBetween(filename, left, right);
                fileDestination = folderpath + newfolder + @"\" + filename;
            }
            if (keepSource)
            {
                if (!replaceFile)
                {
                    fileDestination = fileDestination.Insert(fileDestination.LastIndexOf("."), "(" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ")");
                    Console.WriteLine(fileDestination);
                }
                File.Copy(path, fileDestination, replaceFile);
            }
            else {
                if (!replaceFile)
                {
                    fileDestination = fileDestination.Insert(fileDestination.LastIndexOf("."), "(" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ")");
                    Console.WriteLine(fileDestination);
                }
                else {
                    if (File.Exists(fileDestination))
                    {
                        File.Delete(fileDestination);
                    }
                }
                File.Move(path, fileDestination);
            }
        }
        private string inbetween(string source, string first, string last)
        {
            string st = source;
            int pFrom = st.IndexOf(first) + first.Length;
            int pTo = st.LastIndexOf(last);
            return st.Substring(pFrom, pTo - pFrom);
        }
        private string RemoveBetween(string s, char begin, char end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, string.Empty);
        }
    }
}
