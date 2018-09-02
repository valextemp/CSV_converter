using Microsoft.VisualBasic.FileIO;
using PolimetalRA_Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PolimetalRA_BL
{
    public class CSVClass
    {
        private StreamReader OpenFile(string fileName)

        {
            var srcEncoding = Encoding.GetEncoding(1251);

            if (File.Exists(fileName))
            {
                return new StreamReader(fileName, encoding: srcEncoding);
            }
            return null;
        }

        public List<dynamic> GetDynamicListFromCSV(string fileName)
        {
            List<dynamic> retList = new List<dynamic>();

            StreamReader fileStream = OpenFile(fileName);

            if (fileStream != null)
            {
                string[] headerLine = fileStream.ReadLine().Split(';');


                while (fileStream.Peek() > 0)

                {

                    string[] dataLine = fileStream.ReadLine().Split(';');

                    dynamic dynamicEntity = new ExpandoObject();

                    for (int i = 0; i < headerLine.Length; i++)

                    {
                        ((IDictionary<string, object>)dynamicEntity).Add(headerLine[i], dataLine[i]);
                    }
                    retList.Add(dynamicEntity);
                }
                fileStream.Close();
            }
            
            return retList;
        }

        /// <summary>
        /// Временный метод
        /// </summary>
        /// <returns></returns>
        public List<Tag> GetListTagVBFromCSV()
        {
            List<Tag> retList = new List<Tag>();

            using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }
                }
            }

            return retList;
        }

        /// <summary>
        /// Получения списка Тегов в содержащихся в файле CSV
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<TagCSV> GetListTagFromCSV(string fileName)
        {
            List<TagCSV> retList = new List<TagCSV>();
            StreamReader fileStream = OpenFile(fileName);

            //debug
            string fistLine;

            if (fileStream != null)
            {
                //char[] charsToTrim = { '%','"', '/', '\'' };
                //не удаляет первый символ "\"
                //fistLine = fileStream.ReadLine().Trim(charsToTrim);
                fistLine = fileStream.ReadLine();
                fistLine=Regex.Replace(fistLine, "[@,%\\.\"'\\\\]", string.Empty);
                fistLine=fistLine.Replace("-", "_");
                fistLine = fistLine.Replace("/", "_");

                //s = s.Replace("\"", "")

                string[] headerLine = fistLine.Split(';');

                string ll;

                //После удаления ковычек стало работать нормально
                //for (int i = 0; i < headerLine.Length; i++)
                //{
                //    ll=headerLine[i].Remove(0, 1);
                //    headerLine[i] = ll;
                //}

                //foreach (string line in headerLine)
                //{
                //    //Удаляем первый символ который почему-то "\"
                    
                //    ll= line.Remove(0, 1);
                //    line = ll;
                //}
                ////string[] headerLine = fileStream.ReadLine().Split(';');

                string nameTagTemp;
                int columnTimeStamp;
                int columnValue;

                for (int i = 0; i < headerLine.Length; i++)
                {
                    if (headerLine[i].IndexOf("Time") != -1)
                    {
                        columnTimeStamp = i;
                        nameTagTemp = headerLine[i].Remove(headerLine[i].IndexOf("Time")).Trim();

                        for (int j = 0; j < headerLine.Length; j++)
                        {
                            if ((headerLine[j].IndexOf(nameTagTemp) != -1)&&(headerLine[j].IndexOf("ValueY") != -1))
                            {
                                columnValue = j;
                                TagCSV tagCSV = new TagCSV() { TagNameRus = nameTagTemp, TagName = Translit.GetTranslit(nameTagTemp), TimeStampColumn = columnTimeStamp, ValueColumn = columnValue };
                                retList.Add(tagCSV);
                            }
                        }

                    }

                }

            }
            return retList;
        }

        public Tag GetTagFromCSV(string fileName, TagCSV tagCSV)
        {
            Tag tag = new Tag() {TagName=tagCSV.TagName, TagDescription=tagCSV.TagNameRus };

            StreamReader fileStream = OpenFile(fileName);

            string timeStampStr;
            string valueStr;

            string fistLine;

            if (fileStream != null)
            {
                fistLine = fileStream.ReadLine();
                fistLine = Regex.Replace(fistLine, "[@,%\\.\"'\\\\]", string.Empty);
                fistLine = fistLine.Replace("-", "_");
                fistLine = fistLine.Replace("/", "_");

                string[] headerLine = fistLine.Split(';');
                //string[] headerLine = fileStream.ReadLine().Split(';');

                //TODO: Доработать проверку что в этом  есть этот тег
                if (headerLine[tagCSV.TimeStampColumn].Contains(tagCSV.TagNameRus) && headerLine[tagCSV.ValueColumn].Contains(tagCSV.TagNameRus))
                {
                    NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

                    while (fileStream.Peek() > 0)
                    {
                        string[] dataLine = fileStream.ReadLine().Split(';');

                        if (tagCSV.TimeStampColumn < dataLine.Length-1 && tagCSV.ValueColumn < dataLine.Length - 1)
                        {
                            timeStampStr = dataLine[tagCSV.TimeStampColumn];
                            valueStr= dataLine[tagCSV.ValueColumn];

                            if (!string.IsNullOrEmpty(timeStampStr) && !string.IsNullOrEmpty(valueStr))
                            {
                                TagValue tagValue = new TagValue();
                                //tagValue.ValueString = valueStr.Trim();
                                tagValue.ValueFloat = decimal.Parse(valueStr, NumberStyles.Float, nfi);
                                tagValue.TimeStamp = Convert.ToDateTime(timeStampStr.Trim());
                                tag.TagValues.Add(tagValue);
                            }

                        }

                    }
                }
                fileStream.Close();
            }
            return tag;
        }

        public Tag GetTagFromCSV(List<string> fileNames, TagCSV tagCSV)
        {
            Tag tag = new Tag() { TagName = tagCSV.TagName, TagDescription = tagCSV.TagNameRus };

            foreach (string fileName in fileNames)
            {
                StreamReader fileStream = OpenFile(fileName);

                string timeStampStr;
                string valueStr;

                if (fileStream != null)
                {
                    string[] headerLine = fileStream.ReadLine().Split(';');
                    
                    if (headerLine[tagCSV.TimeStampColumn].Contains(tagCSV.TagNameRus) && headerLine[tagCSV.ValueColumn].Contains(tagCSV.TagNameRus))
                    {
                        NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                        while (fileStream.Peek() > 0)
                        {
                            string[] dataLine = fileStream.ReadLine().Split(';');

                            if (tagCSV.TimeStampColumn < dataLine.Length - 1 && tagCSV.ValueColumn < dataLine.Length - 1)
                            {
                                timeStampStr = dataLine[tagCSV.TimeStampColumn];
                                valueStr = dataLine[tagCSV.ValueColumn];

                                if (!string.IsNullOrEmpty(timeStampStr) && !string.IsNullOrEmpty(valueStr))
                                {
                                    if (decimal.TryParse(valueStr.Replace(',', '.').Trim(), NumberStyles.Float, nfi, out decimal d))
                                    {
                                        TagValue tagValue = new TagValue();
                                        tagValue.ValueFloat = d;
                                        tagValue.TimeStamp = Convert.ToDateTime(timeStampStr.Trim());
                                        tag.TagValues.Add(tagValue);
                                    }

                                    //TagValue tagValue = new TagValue();
                                    ////tagValue.ValueString = valueStr.Trim();
                                    //tagValue.ValueFloat = decimal.Parse(valueStr, NumberStyles.Float, nfi);
                                    //tagValue.TimeStamp = Convert.ToDateTime(timeStampStr.Trim());
                                    //tag.TagValues.Add(tagValue);
                                }

                            }

                        }
                    }
                    fileStream.Close();
                }
            }
            List<TagValue> tagValues = new List<TagValue>();
            tagValues = tag.TagValues.OrderBy(tv => tv.TimeStamp).Select(tv => tv).ToList<TagValue>();
            tag.TagValues = tagValues;

            return tag;
        }

        /// <summary>
        /// Создание тега из файлов и фильтрация через указанный промежуток минут
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="tagCSV"></param>
        /// <param name="minuteAvarage">Период минут усреднения</param>
        /// <returns></returns>
        public Tag GetTagFromCSV(List<string> fileNames, TagCSV tagCSV, int minuteAvarage, bool avgMode)
        {
            Tag tag = new Tag() { TagName = tagCSV.TagName, TagDescription = tagCSV.TagNameRus };

            foreach (string fileName in fileNames)
            {
                StreamReader fileStream = OpenFile(fileName);

                string timeStampStr;
                string valueStr;

                string fistLine;

                if (fileStream != null)
                {
                    fistLine = fileStream.ReadLine();
                    fistLine = Regex.Replace(fistLine, "[@,%\\.\"'\\\\]", string.Empty);
                    fistLine = fistLine.Replace("-", "_");
                    fistLine = fistLine.Replace("/", "_");

                    string[] headerLine = fistLine.Split(';');


                    //string[] headerLine = fileStream.ReadLine().Split(';');

                    if (headerLine[tagCSV.TimeStampColumn].Contains(tagCSV.TagNameRus) && headerLine[tagCSV.ValueColumn].Contains(tagCSV.TagNameRus))
                    {
                        NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

                        while (fileStream.Peek() > 0)
                        {
                            string[] dataLine = fileStream.ReadLine().Split(';');

                            if (tagCSV.TimeStampColumn < dataLine.Length - 1 && tagCSV.ValueColumn <= dataLine.Length - 1)
                            {
                                timeStampStr = dataLine[tagCSV.TimeStampColumn];
                                valueStr = dataLine[tagCSV.ValueColumn];

                                if (!string.IsNullOrEmpty(timeStampStr) && !string.IsNullOrEmpty(valueStr))
                                {
                                    //if (decimal.TryParse(valueStr, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal d))
                                    if (decimal.TryParse(valueStr.Replace(',','.').Trim(), NumberStyles.Float, nfi, out decimal d))
                                    {
                                        TagValue tagValue = new TagValue();
                                        tagValue.ValueFloat = d;
                                        tagValue.TimeStamp = Convert.ToDateTime(timeStampStr.Trim());
                                        tag.TagValues.Add(tagValue);
                                    }

                                    //tagValue.ValueString = valueStr.Trim();
                                    //TagValue tagValue = new TagValue();
                                   //tagValue.ValueFloat = decimal.Parse(valueStr, NumberStyles.Float, nfi);
                                     
                                    //tagValue.ValueFloat = Convert.ToDecimal(valueStr.Replace('.', ','));
                                    //tagValue.TimeStamp = Convert.ToDateTime(timeStampStr.Trim());
                                    //tag.TagValues.Add(tagValue);
                                }

                            }

                        }
                    }
                    fileStream.Close();
                }
            }
            List<TagValue> tagValues = new List<TagValue>();

            if (avgMode)
            {
                var groups = tag.TagValues.OrderBy(k => k.TimeStamp).GroupBy(x =>
                {
                    var stamp = x.TimeStamp;
                    stamp = stamp.AddMinutes(-(stamp.Minute % minuteAvarage)); //instead minuteAvarage was 5
                    stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
                    return stamp;
                })
            .Select(g => new TagValue { TimeStamp = g.Key, ValueFloat = g.Average(s => s.ValueFloat) }).ToList<TagValue>();
                tag.TagValues = groups;
            }
            else
            {
                var groups = tag.TagValues.OrderBy(k => k.TimeStamp).GroupBy(x =>
                {
                    var stamp = x.TimeStamp;
                    stamp = stamp.AddMinutes(-(stamp.Minute % minuteAvarage)); //instead minuteAvarage was 5
                    stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
                    return stamp;
                })
                .Select(g => new TagValue { TimeStamp = g.Key, ValueFloat = g.First().ValueFloat }).ToList<TagValue>();
                tag.TagValues = groups;
            }


            //.Select(g => new TagValue { TimeStamp = g.Key, ValueFloat = g.Average(s =>Convert.ToDecimal(s.ValueString.Replace('.',','))) }).ToList<TagValue>();
            //            .Select(g => new TagValue { TimeStamp = g.Key, ValueString = g.OrderBy(s=>s.TimeStamp).FirstOrDefault(d=>string.IsNullOrEmpty(d.ValueString)) }).ToList<TagValue>();

            //if (zeroOffset)
            //{
            //    int minSecond = tag.TagValues.Min(a => a.TimeStamp.Second);
            //    tagValues = tag.TagValues.OrderBy(a => a.TimeStamp).Distinct().First(s=>s.TimeStamp.Year)
            //    tagValues = tag.TagValues.Where(tv => ((tv.TimeStamp.Minute % minuteAvarage == 0) && (tv.TimeStamp.Second- minSecond) == 0) || (tv.TimeStamp.Minute == 0 && (tv.TimeStamp.Second- minSecond) == 0)).OrderBy(tv => tv.TimeStamp).Distinct().Select(tv => tv).ToList<TagValue>();
            //    tag.TagValues = tagValues;
            //}
            //else
            //{
            //    tagValues = tag.TagValues.Where(tv => ((tv.TimeStamp.Minute % minuteAvarage == 0) && tv.TimeStamp.Second == 0) || (tv.TimeStamp.Minute == 0 && tv.TimeStamp.Second == 0)).OrderBy(tv => tv.TimeStamp).Select(tv => tv).ToList<TagValue>();
            //    tag.TagValues = tagValues;
            //}
            return tag;
        }


        public List<Tag> GetTagFromCSV(List<string> fileNames, List<TagCSV> tagsCSV)
        {
            List<Tag> tags = new List<Tag>();

            foreach (TagCSV tagCSV in tagsCSV)
            {
                //Tag tag = GetTagFromCSV(fileNames, tagCSV);
                Tag tag = GetTagFromCSV(fileNames, tagCSV);
                tags.Add(tag);
            }

            return tags;
        }

        // Используется для склеивания и записи всех подряд данных
        public void SaveToFileCSV (List<TagCSV> tagsCSV, List<string> listFiles)
        {
            Tag tag;
            foreach (TagCSV tagCSV in tagsCSV)
            {
                tag = GetTagFromCSV(listFiles, tagCSV);

                if (tag!=null && tag.TagValues.Count>0)
                {
                    WriteTagToCSV(Path.GetDirectoryName(listFiles[0]) + "\\", tag);
                }
            }
        }

        //используется для записи прореженных данных
        public void SaveToFileCSV(List<TagCSV> tagsCSV, List<string> listFiles,int minute, bool avgMode)
        {
            Tag tag;
            foreach (TagCSV tagCSV in tagsCSV)
            {
                //tag = GetTagFromCSV(listFiles, tagCSV);
                tag = GetTagFromCSV(listFiles, tagCSV, minute, avgMode);

                if (tag != null && tag.TagValues.Count > 0)
                {
                    WriteTagToCSV(Path.GetDirectoryName(listFiles[0]) + "\\", tag);
                }
            }
        }


        public void WriteTagToCSV (string filepath, Tag tag)
        {
            var csv = new StringBuilder();
            //string firstString = "[Tags]";
            //string secondStr = "Tagname;Description;DataType";
            ////ZSU_002_vesy_lk_14_VNK_1400;vesy_lk_14_VNK_1400;SingleFloat
            //string thirdString = string.Format("{0};{1};{2}", tag.TagName, tag.TagDescription, "SingleFloat");
            string fourthString = "[Data]";
            string fifth = "Tagname;Timestamp;Value";
            //csv.AppendLine(firstString);
            //csv.AppendLine(secondStr);
            //csv.AppendLine(thirdString);
            csv.AppendLine(fourthString);
            csv.AppendLine(fifth);

            string fullFileName;

            string strToCSV;
            for (int i = 0; i < tag.TagValues.Count; i++)
            {
                //ZSU_002_vesy_lk_14_VNK_1400;01.01.2017 0:01:00;1417.83333333333
                strToCSV = string.Format("{0};{1};{2}", tag.TagName, tag.TagValues[i].TimeStamp.ToString(), tag.TagValues[i].ValueString);
                csv.AppendLine(strToCSV);
            }

            try
            {
                fullFileName = filepath + tag.TagName + ".csv";
                File.WriteAllText(fullFileName, csv.ToString());
            }
            catch (Exception e)
            {
            }

        }

    }
}
