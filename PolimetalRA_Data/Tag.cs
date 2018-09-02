using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimetalRA_Data
{
    public class Tag
    {
        //List<TagValue> tag
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public List<TagValue> TagValues = new List<TagValue>();
    }

    public class TagValue
    {
        public DateTime TimeStamp { get; set; }
        public decimal ValueFloat { get; set; }
        public string ValueString { get { return Convert.ToString(ValueFloat); }  }
    }
}
