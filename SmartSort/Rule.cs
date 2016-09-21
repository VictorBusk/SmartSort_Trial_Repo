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

        private string destination_temp;
        private string source_temp;

        public Rule(string _name, string _source, string _destination, string _keyWord, bool _includeFolders)
        {
            name = _name;
            source = _source;
            destination = _destination;
            keyWord = _keyWord;
            includeFolders = _includeFolders;
            destination_temp = _destination;
            source_temp = _source;
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
                    moveFile(f);
                }
                if (includeFolders)
                {
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        source_temp = d.Replace(source, "");
                        destination_temp = destination + source_temp;
                        Directory.CreateDirectory(destination_temp);
                        SearchDirectory(d);
                    }
                }
            }
            catch (System.Exception) { }
        }
        private void moveFile(String path)
        {
            var lol = destination + path.Replace(source, "");
            File.Move(path, lol);
        }
    }

}
