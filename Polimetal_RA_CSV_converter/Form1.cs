using PolimetalRA_BL;
using PolimetalRA_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polimetal_RA_CSV_converter
{
    //final release 22/08/2018
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл CSV|*.CSV";
            openFileDialog.Multiselect = true;

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Файл не выбран!", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            checkedLstFiles.Items.Clear();

            foreach (string item in openFileDialog.FileNames)
            {
                ReportFile reportFile = new ReportFile() { ReportFileName = Path.GetFileName(item), ReportFullPath = Path.GetFullPath(item), ReportPath = Path.GetDirectoryName(item) };
                checkedLstFiles.Items.Add(reportFile);
            }

        }

        private void btnChooseTags_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл CSV|*.CSV";

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Файл не выбран!", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            txtFileName.Clear();
            txtFileName.Text = openFileDialog.FileName;

            chеckLstTags.Items.Clear();

            List<TagCSV> lstTagsCSV;

            CSVClass polimetalTags = new CSVClass();

            lstTagsCSV = polimetalTags.GetListTagFromCSV(openFileDialog.FileName);

            chеckLstTags.Items.AddRange(lstTagsCSV.ToArray<TagCSV>());

        }

        private void btnTagsSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chеckLstTags.Items.Count; i++)
                chеckLstTags.SetItemChecked(i, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chеckLstTags.Items.Count; i++)
                chеckLstTags.SetItemChecked(i, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedLstFiles.Items.Count; i++)
                checkedLstFiles.SetItemChecked(i, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedLstFiles.Items.Count; i++)
                checkedLstFiles.SetItemChecked(i, false);
        }

        private void btnCreateCSV_Click(object sender, EventArgs e)
        {
            if (chеckLstTags.CheckedItems.Count == 0)
            {
                MessageBox.Show("Отсутствуют выбранные теги", "Сообщение об ошибке", MessageBoxButtons.OK);
                return;
            }

            if (checkedLstFiles.CheckedItems.Count == 0)
            {
                MessageBox.Show("Отсутствуют выбранные отчеты", "Сообщение об ошибке", MessageBoxButtons.OK);
                return;
            }

            List<TagCSV> lstTagsCSV = new List<TagCSV>();
            foreach (TagCSV item in chеckLstTags.CheckedItems)
            {
                lstTagsCSV.Add((TagCSV)item);
            }

            List<string> listFiles = new List<string>();
            foreach (ReportFile item in checkedLstFiles.CheckedItems)
            {
                listFiles.Add(item.ReportFullPath);
            }

            List<ReportFile> listReportFile = new List<ReportFile>();
            foreach (ReportFile item in checkedLstFiles.CheckedItems)
            {
                listReportFile.Add(item);
            }

            CSVClass csvClass = new CSVClass();
            csvClass.SaveToFileCSV(lstTagsCSV, listFiles);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (chеckLstTags.CheckedItems.Count == 0)
            {
                MessageBox.Show("Отсутствуют выбранные теги", "Сообщение об ошибке", MessageBoxButtons.OK);
                return;
            }

            if (checkedLstFiles.CheckedItems.Count == 0)
            {
                MessageBox.Show("Отсутствуют выбранные отчеты", "Сообщение об ошибке", MessageBoxButtons.OK);
                return;
            }

            List<TagCSV> lstTagsCSV = new List<TagCSV>();
            foreach (TagCSV item in chеckLstTags.CheckedItems)
            {
                lstTagsCSV.Add((TagCSV)item);
            }

            List<string> listFiles = new List<string>();
            foreach (ReportFile item in checkedLstFiles.CheckedItems)
            {
                listFiles.Add(item.ReportFullPath);
            }

            List<ReportFile> listReportFile = new List<ReportFile>();
            foreach (ReportFile item in checkedLstFiles.CheckedItems)
            {
                listReportFile.Add(item);
            }

            CSVClass csvClass = new CSVClass();
            csvClass.SaveToFileCSV(lstTagsCSV, listFiles,(int)numericUpDown1.Value, chckAvgMode.Checked);

        }
    }
}
