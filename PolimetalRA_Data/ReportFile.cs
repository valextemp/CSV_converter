using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimetalRA_Data
{
    public class ReportFile
    {
        public string ReportFileName { get; set; }
        public string ReportFullPath { get; set; }
        public string ReportPath { get; set; } //Путь к файлу отчетов без имени, и на конце нет слеша закрывающего

        public override string ToString()
        {
            return ReportFileName;
        }
    }
}
