using CloudManager.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Common.Helper
{
    public class PathHelper : IPath
    {
        private string _path;
        public string Path { get { return GetRealPath(_path); } set { _path = value; } }

        private string GetRealPath(string path)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}
