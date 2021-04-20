using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace Курсова
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Word Doucment|*.docx|Word 97 - 2003 Document|*.doc" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    object readOnly = true;
                    object visible = true;
                    object save = false;
                    object fileName = ofd.FileName;
                    object missing = Type.Missing;
                    object newTemplate = false;
                    object docType = 0;
                    Microsoft.Office.Interop.Word._Document oDoc = null;
                    Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                    oDoc = oWord.Documents.Open(
                            ref fileName, ref missing, ref readOnly, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref visible,
                            ref missing, ref missing, ref missing, ref missing);
                    oDoc.ActiveWindow.Selection.WholeStory();
                    oDoc.ActiveWindow.Selection.Copy();
                    IDataObject data = Clipboard.GetDataObject();
                    rtfData.Rtf = data.GetData(DataFormats.Rtf).ToString();
                    oWord.Quit(ref missing, ref missing, ref missing);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           var  App = new Microsoft.Office.Interop.Word.Application();
           var Doc = new Microsoft.Office.Interop.Word.Document();
           Doc = App.Documents.Add();
           App.Visible = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
