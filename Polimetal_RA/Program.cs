using PolimetalRA_BL;
using PolimetalRA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimetal_RA
{
    class Program
    {
        static void Main(string[] args)
        {
            //CSVClass cSVClass = new CSVClass();
            //cSVClass.GetDynamicListFromCSV(@"C:\VAlex\mycsv.csv");

            //string ss = Translit.GetTranslit("Шла Маша по шоссе");
            //string ss1 = Transliteration.Front("Шла Маша по шоссе");


            CSVClass cSVClass = new CSVClass();
            //List<TagCSV> list = cSVClass.GetListTagDynamicFromCSV(@"C:\VAlex\mycsv.csv");
            List<TagCSV> list = cSVClass.GetListTagFromCSV(@"C:\VAlex\1-3.01.2018.csv");
            //1 - 3.01.2018.csv

            List<string> files = new List<string>();
            files.Add(@"C:\VAlex\1-3.01.2018.csv");
            files.Add(@"C:\VAlex\4-6.01.2018.csv");

            List<TagCSV> tagsCSV = new List<TagCSV>();
            tagsCSV.Add(list[0]);
            tagsCSV.Add(list[1]);

            if (list!=null)
            {
                //Tag tag = cSVClass.GetTagFromCSV(@"C:\VAlex\mycsv.csv", list[0]);
                //Tag tag = cSVClass.GetTagFromCSV(@"C:\VAlex\1-3.01.2018.csv", list[0]);
                //Tag tag = cSVClass.GetTagFromCSV(files, list[0]);
                List<Tag> tags = cSVClass.GetTagFromCSV(files, tagsCSV);
            }
           
            Console.ReadLine();
        }
    }
}
