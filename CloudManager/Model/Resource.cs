using CloudManager.Common.Interfaces;
using CloudManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Modeld
{
    public class Resource : BaseEntity
    {
        public List<Attribute> Attributes { get; set; }

        public List<Resource> Resources { get; set; }

        public static string GetName()
        {
            return "Resource";
        }
    }
}
