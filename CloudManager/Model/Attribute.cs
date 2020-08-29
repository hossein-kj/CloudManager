using CloudManager.Common.Interfaces;
using CloudManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Modeld
{
    public class Attribute: BaseEntity
    {
        public string Value { get; set; }

        public static string GetName()
        {
            return "Attribute";
        }
    }
}
