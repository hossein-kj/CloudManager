using CloudManager.Common.Interfaces;
using CloudManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Modeld
{
    public class Provider : BaseEntity,IPath
    {
        public List<Infrastructure> infrastructures { get; set; }

        public string Path { get { return Name; } }


        public static string GetName()
        {
            return "Provider";
        }
    }
}
