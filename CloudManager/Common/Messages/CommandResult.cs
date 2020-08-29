using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Common
{
    public class CommandResult
    {
        public CommandResult()
        {
            ResultMessages = new List<ResultMessage>();
        }
        public List<ResultMessage> ResultMessages { get; set; }
    }
}
