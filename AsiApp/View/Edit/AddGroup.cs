using Asi.Model;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AsiApp.View.Edit
{
    public partial class AddGroup : DevExpress.XtraEditors.XtraForm
    {
        List<FormTemplateRowModel> rows;
        AddMissMatchWords addMissMatchWords;
        public AddGroup()
        {
            rows = new List<FormTemplateRowModel>();
            InitializeComponent();
           
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridControl1.DataSource = rows;

        }
        public AddGroup(FormTemplateGroupModel formTemplateGroup)
        {
            rows = new List<FormTemplateRowModel>();
            InitializeComponent();
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            LoadData(formTemplateGroup);
        }

        private void LoadData(FormTemplateGroupModel formTemplateGroup)
        {
            ValidateQuestionHeaders(formTemplateGroup.QuestionHeaders);
            ValidateAnswerColumns(formTemplateGroup.AnswerColumns);
            this.TextboxTitle.Text = formTemplateGroup.Title;
            this.TextboxSubtitle.Text = formTemplateGroup.Subtitle;
            this.CheckboxHasNote.Checked = formTemplateGroup.HasNote;
            this.CheckboxIsChecklist.Checked = formTemplateGroup.IsCheckBox;
            this.CheckboxSubtitle.Checked = formTemplateGroup.HasSubtitle;
           
            this.gridControl1.DataSource = formTemplateGroup.Questions;
            if (formTemplateGroup.IsCheckBox)
            {
                this.colMissMatchWords.Visible = this.CheckboxIsChecklist.Checked;
                this.colMissMatchWords.VisibleIndex = this.gridView1.VisibleColumns.Count + 1;
            }
        }

        private void ValidateAnswerColumns(List<string> answerColumns)
        {
           
            this.ListboxAnswerHeader.Items.AddRange(answerColumns.ToArray());
            for (int i = 0; i < answerColumns.Count; i++)
            {
                this.ButtonAnswerAdd.Enabled = true;
                this.ButtonAnswerRemove.Enabled = true;
                GridColumn column = new GridColumn();
                column.Caption = answerColumns[i];
                column.Visible = true;
                this.gridView1.Columns.Add(column);
            }
            if (ListboxAnswerHeader.Items.Count == 0)
                this.ButtonAnswerRemove.Enabled = false;
            if (ListboxAnswerHeader.Items.Count == 5)
                this.ButtonAnswerAdd.Enabled = false;
        }

        private void ValidateQuestionHeaders(List<string> questionHeaders)
        {
            this.ListboxQuestionHeader.Items.AddRange(questionHeaders.ToArray());
            if (questionHeaders.Count == 1)
            {
                ButtonQuestionRemove.Enabled = true;
                this.ConfigQustionHeader(1,questionHeaders[0], "FirstQuestion");
            }
            else if (questionHeaders.Count == 2)
            {
                ButtonQuestionRemove.Enabled = true;
                this.ConfigQustionHeader(1,questionHeaders[0], "FirstQuestion");
                this.ConfigQustionHeader(2,questionHeaders[1], "SecondQuestion");
            }
            else if (questionHeaders.Count == 3)
            {
                ButtonQuestionRemove.Enabled = true;
                this.ConfigQustionHeader(1,questionHeaders[0], "FirstQuestion");
                this.ConfigQustionHeader(2,questionHeaders[1], "SecondQuestion");
                this.ConfigQustionHeader(3,questionHeaders[2], "ThirdQuestion");
            }
            else if (questionHeaders.Count == 4)
            {
                ButtonQuestionAdd.Enabled = false;
                this.ConfigQustionHeader(1,questionHeaders[0], "FirstQuestion");
                this.ConfigQustionHeader(2,questionHeaders[1], "SecondQuestion");
                this.ConfigQustionHeader(3,questionHeaders[2], "ThirdQuestion");
                this.ConfigQustionHeader(4,questionHeaders[3], "ForthQuestion");
            }
        }

        private void CheckboxSubtitle_CheckedChanged(object sender, EventArgs e)
        {
            TextboxSubtitle.Visible = CheckboxSubtitle.Checked;
        }

        private void ConfigQustionHeader(int order,string columncaption, string columnname)
        {
            GridColumn firstclolumn = this.gridView1.Columns.Where(column => column.FieldName == columnname).FirstOrDefault();
            firstclolumn.VisibleIndex = order;
            firstclolumn.Caption = columncaption;
            firstclolumn.Visible = true;
           
        }

        private void ButtonQuestionAdd_Click(object sender, EventArgs e)
        {
            string questiontitle = this.TextboxQuestionTitle.Text;
            this.ListboxQuestionHeader.Items.Add(questiontitle);

            if (this.ListboxQuestionHeader.Items.Count == 1)
            {
                this.ConfigQustionHeader(1,questiontitle, "FirstQuestion");
                ButtonQuestionRemove.Enabled = true;
            }
            if (this.ListboxQuestionHeader.Items.Count == 2)
            {
                this.ConfigQustionHeader(2,questiontitle, "SecondQuestion");
            }
            if (this.ListboxQuestionHeader.Items.Count == 3)
            {
                this.ConfigQustionHeader(3,questiontitle, "ThirdQuestion");
            }
            if (this.ListboxQuestionHeader.Items.Count == 4)
            {
                this.ConfigQustionHeader(4,questiontitle, "ForthQuestion");
                ButtonQuestionAdd.Enabled = false;
            }
        }

        private void ButtonQuestionRemove_Click(object sender, EventArgs e)
        {
            int listcount = this.ListboxQuestionHeader.Items.Count;
            this.ListboxQuestionHeader.Items.RemoveAt(listcount - 1);

            if (listcount == 1)
            {
                this.gridView1.Columns.Where(c => c.FieldName == "FirstQuestion").FirstOrDefault().Visible = false;
                this.ButtonQuestionRemove.Enabled = false;
                this.ButtonQuestionAdd.Enabled = true;
            }

            if (listcount == 2)
            {
                this.gridView1.Columns.Where(c => c.FieldName == "SecondQuestion").FirstOrDefault().Visible = false;
                this.ButtonQuestionRemove.Enabled = true;
                this.ButtonQuestionAdd.Enabled = true;
            }

            if (listcount == 3)
            {
                this.gridView1.Columns.Where(c => c.FieldName == "ThirdQuestion").FirstOrDefault().Visible = false;
                this.ButtonQuestionRemove.Enabled = true;
                this.ButtonQuestionAdd.Enabled = true;
            }

            if (listcount == 4)
            {
                this.gridView1.Columns.Where(c => c.FieldName == "ForthQuestion").FirstOrDefault().Visible = false;
                this.ButtonQuestionRemove.Enabled = true;
                this.ButtonQuestionAdd.Enabled = true;
            }

        }

        private void ButtonAnswerAdd_Click(object sender, EventArgs e)
        {
            string answerTitle = this.TextboxAnswerTitle.Text;
            this.ListboxAnswerHeader.Items.Add(answerTitle);
            GridColumn column = new GridColumn();
            column.Caption = answerTitle;
            column.Visible = true;
            this.gridView1.Columns.Add(column);
            this.ButtonAnswerRemove.Enabled = true;
            this.ButtonAnswerAdd.Enabled = true;
            if (ListboxAnswerHeader.Items.Count == 0)
                this.ButtonAnswerRemove.Enabled = false;
            if (ListboxAnswerHeader.Items.Count == 5)
                this.ButtonAnswerAdd.Enabled = false;
        }

        private void ButtonAnswerRemove_Click(object sender, EventArgs e)
        {
            this.ListboxAnswerHeader.Items.RemoveAt(this.ListboxAnswerHeader.Items.Count - 1);
            this.gridView1.Columns.RemoveAt(this.gridView1.Columns.Count - 1);
            this.ButtonAnswerRemove.Enabled = true;
            if (ListboxAnswerHeader.Items.Count == 4)
                this.ButtonAnswerRemove.Enabled = true;
            if (ListboxAnswerHeader.Items.Count == 0)
                this.ButtonAnswerRemove.Enabled = false;
        }

        private void TextboxSubtitle_EditValueChanged(object sender, EventArgs e)
        {
            this.gridView1.Columns.Where(x => x.FieldName == "Id").FirstOrDefault().Caption = TextboxSubtitle.Text;
        }

        public FormTemplateGroupModel GetGroup()
        {
            FormTemplateGroupModel group = new FormTemplateGroupModel
            {
                HasSubtitle = this.CheckboxSubtitle.Checked,
                IsCheckBox = this.CheckboxIsChecklist.Checked,
                HasNote = this.CheckboxHasNote.Checked,
                QuestionHeaders = this.ListboxQuestionHeader.Items.Cast<string>().ToList(),
                AnswerColumns = this.ListboxAnswerHeader.Items.Cast<string>().ToList(),
                Subtitle = this.TextboxSubtitle.Text,
                Title = this.TextboxTitle.Text
            };
            List<FormTemplateRowModel> formTemplateRows = new List<FormTemplateRowModel>();
            for (int i = 0; i < this.gridView1.DataRowCount; i++)
            {
                formTemplateRows.Add(this.gridView1.GetRow(i) as FormTemplateRowModel);
            }
            group.Questions = formTemplateRows;
            return group;
        }

        private void CheckboxIsChecklist_CheckedChanged(object sender, EventArgs e)
        {
            this.colMissMatchWords.Visible = this.CheckboxIsChecklist.Checked;
            this.colMissMatchWords.VisibleIndex = this.gridView1.VisibleColumns.Count+1;
            this.CheckboxHasNote.Visible = this.CheckboxIsChecklist.Checked;
        }

        private void CheckboxHasNote_CheckedChanged(object sender, EventArgs e)
        {
            string note = "یادداشت";
            string noteans = "مقدار یادداشت";
            if (CheckboxHasNote.Checked)
            {
                this.colForthQuestion.Visible = true;
                this.colForthQuestion.Caption = note;
                if (this.ListboxQuestionHeader.Items.Count == 0)
                    this.ListboxQuestionHeader.Items.Add(note);
                else
                    this.ListboxQuestionHeader.Items.Insert(this.ListboxQuestionHeader.Items.Count - 1, note);
                if (this.ListboxAnswerHeader.Items.Count == 0)
                    this.ListboxAnswerHeader.Items.Add(noteans);
                else
                    this.ListboxAnswerHeader.Items.Insert(this.ListboxQuestionHeader.Items.Count - 1, noteans);
                int noteindex = this.colForthQuestion.VisibleIndex;
                GridColumn column = new GridColumn();
                column.Caption = noteans;
                column.Visible = true;
                column.VisibleIndex = noteindex + 1;
                gridView1.Columns.Add(column);
            }
            else
            {
                this.ListboxQuestionHeader.Items.Remove(note);
                this.ListboxAnswerHeader.Items.Remove(noteans);
                this.gridView1.Columns.Where(x => x.Caption == noteans).FirstOrDefault().Dispose();
                this.colForthQuestion.Visible = false;
            }


        }

        private void gridView1_ClipboardRowPasting(object sender, DevExpress.XtraGrid.Views.Grid.ClipboardRowPastingEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string ss = Clipboard.GetText(TextDataFormat.UnicodeText);

            string[] rowseprator = { "\r\n", "\t\t" };
            string[] columnseprator = { "\t" };
            string[] rows = ss.Split(rowseprator, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rows.Count(); i++)
            {
                FormTemplateRowModel row = new FormTemplateRowModel();
                if (rows[i].Contains(columnseprator[0]))
                {
                    string[] columns = rows[i].Split(columnseprator, System.StringSplitOptions.RemoveEmptyEntries);
                    
                    if (columns.Count() == 1)
                    {
                        row = new FormTemplateRowModel
                        {
                            FirstQuestion = columns[0],
                            MissMatchWords = new List<string> { "جمله1","جمله2","جمله3","جمله4"}

                        };
                    }
                    if (columns.Count() == 2)
                    {
                        row = new FormTemplateRowModel
                        {
                            FirstQuestion = columns[0],
                            SecondQuestion = columns[1],
                            MissMatchWords = new List<string> { "جمله1", "جمله2", "جمله3", "جمله4" }
                        };
                    }
                    if (columns.Count() == 3)
                    {
                        row = new FormTemplateRowModel
                        {
                            FirstQuestion = columns[0],
                            SecondQuestion = columns[1],
                            ThirdQuestion = columns[2],
                            MissMatchWords = new List<string> { "جمله1", "جمله2", "جمله3", "جمله4" }
                        };
                    }
                    if (columns.Count() == 4)
                    {
                        row = new FormTemplateRowModel
                        {
                            FirstQuestion = columns[0],
                            SecondQuestion = columns[1],
                            ThirdQuestion = columns[2],
                            ForthQuestion = columns[3],
                            MissMatchWords = new List<string> { "جمله1", "جمله2", "جمله3", "جمله4" }
                        };
                    }
                }
                else
                {
                    if(this.CheckboxIsChecklist.Checked)
                        row = new FormTemplateRowModel { FirstQuestion = rows[i],MissMatchWords= new List<string> { "جمله1", "جمله2", "جمله3", "جمله4" } };
                   else
                        row = new FormTemplateRowModel { FirstQuestion = rows[i] };
                }
                this.rows.Add(row);

                this.gridControl1.DataSource = this.rows;
                this.gridControl1.RefreshDataSource();


            }
            //  this.gridControl1.DataSource = this.rows;
            //this.gridControl1.RefreshDataSource();
        }

      

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            List<string> awords = addMissMatchWords.GetMissMatchWords();
            (this.gridView1.GetFocusedRow() as FormTemplateRowModel).MissMatchWords = awords;
            addMissMatchWords.Close();
           
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            addMissMatchWords = new AddMissMatchWords((this.gridView1.GetFocusedRow() as FormTemplateRowModel).MissMatchWords);
            int f = e.Button.Index;
            addMissMatchWords.Show();
            addMissMatchWords.simpleButton1.Click += SimpleButton1_Click;
        }
    }
}
