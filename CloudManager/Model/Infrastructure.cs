using CloudManager.Common.Interfaces;
using CloudManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Modeld
{
    public class Infrastructure : BaseEntity, IPath
    {
        public Provider Provider { get; set; }
        public List<Resource> Resources { get; set; }

        public string Path { get { return Provider.Name + "/" + Name; } }

        public static string GetName()
        {
            return "Infrastructure";
        }
    }
}
