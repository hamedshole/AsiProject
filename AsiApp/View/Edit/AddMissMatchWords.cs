using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsiApp.View.Edit
{
    public partial class AddMissMatchWords : DevExpress.XtraEditors.XtraForm
    {
        public AddMissMatchWords(List<string> missmatchwords)
        {
            InitializeComponent();
            if(missmatchwords!=null)
            {
                missmatchwords.ForEach(x => this.listBoxControl1.Items.Add(x));
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public List<string> GetMissMatchWords()
        {
            List<string> words = new List<string>();
            for (int i = 0; i < listBoxControl1.Items.Count; i++)
            {
                words.Add(this.listBoxControl1.Items[i].ToString());
            }
            return words;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.listBoxControl1.Items.Add(this.richTextBox1.Text);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.listBoxControl1.Items.RemoveAt(this.listBoxControl1.Items.Count - 1);
        }

       
    }
}