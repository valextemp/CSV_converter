using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimetalRA_Data
{
    // Для хранение имени тега и номеров колонок для значений
    public class TagCSV
    {
        public string TagName { get; set;}
        public string TagNameRus { get; set; }
        public int TimeStampColumn { get; set; }
        public int ValueColumn { get; set; }

        public override string ToString()
        {
            return TagNameRus + " - "+ TagName;
        }
    }
}
