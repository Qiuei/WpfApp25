using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp25
{
    public class TreeNodeClass
    {
        public string Name { get; set; }
        public string FilePathName { get; set; }
        public List<TreeNodeClass> Children { get; set; }

        public TreeNodeClass(string name,string fullPath)
        {
            Name = name;
            FilePathName = fullPath;
            Children = new List<TreeNodeClass>();
        }
    }
}
