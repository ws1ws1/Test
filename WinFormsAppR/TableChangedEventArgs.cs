using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppR
{
    public class TableChangedEventArgs
    {
        public int Id { get; set; }
        public bool Flag { get; set; }
        public string Text { get; set; }
        public string ChangeType { get; set; }

        public TableChangedEventArgs(int id, bool flag, string text, string changeType)
        {
            Id = id;
            Flag = flag;
            Text = text;
            ChangeType = changeType;
        }

        public TableChangedEventArgs() { }
    }
}
