using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDocker
{
    
    class Item
    {
        string name, path;
        public Item(string name, string path)
        {
            this.name = name;
            this.path = path;
        }
        public string getName()
        {
            return this.name;
        }
        public string getPath()
        {
            return this.path;
        }
    }
}
