using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSort
{
    public class Rule
    {
        public String name { get; set; }
        public String source { get; set; }
        public String destination { get; set; }
        public String keyWord { get; set; }
        public bool includeFolders { get; set; }
        private List<String> elements;
        private string subfolder;

        public Rule(string _name, string _source, string _destination, string _keyWord, bool _includeFolders)
        {
            name = _name;
            source = _source;
            destination = _destination;
            keyWord = _keyWord;
            includeFolders = _includeFolders;
        }

        public void executeRule(List<String> _elements)
        {
            foreach(String element in _elements)
            {
                executeRule(element);
            }
        }

        public void executeRule(String element)
        {
            FileAttributes fiat = File.GetAttributes(element); // Mmmmmmm FUNNNNYYYY JOKE!!!
            if ((fiat & FileAttributes.Directory) == FileAttributes.Directory)
            {
                System.IO.Directory.CreateDirectory("");
                Console.WriteLine("Its a directory");
            }
            else
            {
                Console.WriteLine("Its a file");
            }
        }

        private void createFolder()
        {

        }

        private void moveFolder()
        {

        }

        private void SearchDirectory(string dir)
        {
            elements = new List<String>();
 			try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    elements.Add(f);
                }
                if (includeFolders)
                {
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        elements.Add(d);
                        SearchDirectory(d);
                    }
                }
            }
            catch (System.Exception) { }
        }
    }
}
