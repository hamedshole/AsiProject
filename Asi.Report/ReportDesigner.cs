using Asi.Model;
using Asi.Report.Properties;
using Net.Report.Model;
using Newtonsoft.Json;
using Stimulsoft.Base;
using Stimulsoft.Base.Json.Linq;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace Asi.Shared.Report
{
    public class ReportDesigner
    {
        Random random;
        public ReportDesigner()
        {
            random = new Random();
        }
        private enum GroupType
        {
            QuestionWithoutSubtitle = 0,
            FourColumnQuestionWithSubtitle = 1,
            FiveColumnQuestionWithSubtitle = 2,
            OneColumnCheckboxWithTwoQuestion = 3,
            OneColumnCheckboxWithThreeQuestion = 4,
            ThreeColumnCheckboxWithTwoQuestion = 5,
            ThreeColumnCheckboxWithThreeQuestion = 6,
            ThreeColumnCheckboxWithFourQuestion = 7,
            OneQuestionOneAnswer = 8,
            OneColumnCheckboxWithThreeQuestionAndNote
        }
        private GroupType GetGroupType(FormDataGroupModel group)
        {
            GroupType x = GroupType.QuestionWithoutSubtitle;
            if (!group.IsCheckBox && group.AnswerColumns.Count == 4 && group.HasSubtitle)
                x = GroupType.FourColumnQuestionWithSubtitle;
            else if (!group.IsCheckBox && group.AnswerColumns.Count == 5 && group.HasSubtitle)
                x = GroupType.FiveColumnQuestionWithSubtitle;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 1 && group.QuestionHeaders.Count == 2)
                x = GroupType.OneColumnCheckboxWithTwoQuestion;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 1 && group.QuestionHeaders.Count == 3)
                x = GroupType.OneColumnCheckboxWithThreeQuestion;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 3 && group.QuestionHeaders.Count == 2)
                x = GroupType.ThreeColumnCheckboxWithTwoQuestion;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 3 && group.QuestionHeaders.Count == 3)
                x = GroupType.ThreeColumnCheckboxWithThreeQuestion;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 3 && group.QuestionHeaders.Count == 4)
                x = GroupType.ThreeColumnCheckboxWithFourQuestion;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 2 && group.HasNote && group.QuestionHeaders.Count == 4)
                x = GroupType.OneColumnCheckboxWithThreeQuestionAndNote;
            else if (group.IsCheckBox && group.AnswerColumns.Count == 1 && group.QuestionHeaders.Count == 1)
                x = GroupType.OneQuestionOneAnswer;

            return x;
        }
        public void GenerateMissMatchReportReport(MissMatchReportModel missMatchReport)
        {
            StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";
            StiReport report = new StiReport();
            PersianCalendar persianCalendar = new PersianCalendar();
            report.Load(Resources.missmatchreport);
            report.Dictionary.Variables.Add("itemname", missMatchReport.Item);
            report.Dictionary.Variables["formcode"].Value = missMatchReport.FormCode;
            //report.Dictionary.Variables["reviewdateyear"].ValueObject = persianCalendar.GetYear(missMatchReport.ReviewDate);
            //report.Dictionary.Variables["reviewdatemounth"].ValueObject = persianCalendar.GetMonth(missMatchReport.ReviewDate);
            //report.Dictionary.Variables["reviewdateday"].ValueObject = persianCalendar.GetDayOfMonth(missMatchReport.ReviewDate);
            report.Dictionary.Variables["controldateyear"].ValueObject = persianCalendar.GetYear(missMatchReport.ControlDate);
            report.Dictionary.Variables["controldatemounth"].ValueObject = persianCalendar.GetMonth(missMatchReport.ControlDate);
            report.Dictionary.Variables["controldateday"].ValueObject = persianCalendar.GetDayOfMonth(missMatchReport.ControlDate);
            report.Dictionary.Variables["filenumber"].Value = missMatchReport.FileNumber;
            //report.Dictionary.Variables["toolcode"].Value = missMatchReport.ToolCode;
            report.Dictionary.Variables["standardrefference"].Value = missMatchReport.ControlRefference;
            report.Dictionary.Variables["employername"].Value = missMatchReport.CompanyName;
            report.Dictionary.Variables["employeraddress"].Value = missMatchReport.CompanyAddress;
            report.DataSources.Clear();
            DataTable data1 = CreateQuestionWithoutSubtitleTable(missMatchReport.Properties, "data1");
            report.RegData(data1);
            DataTable data2 = CreateMissMatchDataBand(missMatchReport.MissMatchWords);
            report.RegData(data2);
            report.Design();





            // FileStream s = new FileStream(@"E:\itemtmps\x.pdf", FileMode.Create);
            //  file.CopyTo(s);

            //    File.WriteAllBytes(@"E:\itemtmps\r.pdf",file.)
        }

        private DataTable CreateMissMatchDataBand(List<string> list)
        {
            DataTable dataTable = new DataTable("data2");
            dataTable.Columns.Add("word", typeof(string));
            for (int i = 0; i < list.Count; i++)
            {
                dataTable.Rows.Add(list[i]);
            }
            return dataTable;
        }

        public StiNetCoreActionResult GenerateCertificateReport(CertificateReportModel controlFormData)
        {
            StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";
            StiReport report = new StiReport();
            PersianCalendar persianCalendar = new PersianCalendar();
            report.Load(Resources.reporttemplate);
            if (controlFormData.Controls.Count == 1)
            {
                report.Dictionary.Variables.Add("customersignone", controlFormData.Controls[0].LinkSigniture);
                //  ms = new MemoryStream(Convert.FromBase64String(controlFormData.FirstControllerSigniture));
                report.Dictionary.Variables.Add("controllersignone", controlFormData.ControllerSigniture);
                report.Dictionary.Variables.Add("controllername", controlFormData.Controls[0].LinkSigniture);
                
                report.Dictionary.Variables.Add("firsttimeyear", persianCalendar.GetYear(controlFormData.Controls[0].Time));
                report.Dictionary.Variables.Add("firsttimemounth", persianCalendar.GetMonth(controlFormData.Controls[0].Time));
                report.Dictionary.Variables.Add("firsttimeday", persianCalendar.GetDayOfMonth(controlFormData.Controls[0].Time));
                
            }
            report.Dictionary.Variables.Add("itemtitle", controlFormData.ItemName);
            //  MemoryStream ms = new MemoryStream(Convert.FromBase64String(controlFormData.FirstCustomerSigniture));
            report.Dictionary.Variables["formcode"].Value = controlFormData.FormCode;
            report.Dictionary.Variables["reviewdateyear"].ValueObject = persianCalendar.GetYear(controlFormData.ReviewDate);
            report.Dictionary.Variables["reviewdatemounth"].ValueObject = persianCalendar.GetMonth(controlFormData.ReviewDate);
            report.Dictionary.Variables["reviewdateday"].ValueObject = persianCalendar.GetDayOfMonth(controlFormData.ReviewDate);
            report.Dictionary.Variables["controldateyear"].ValueObject = persianCalendar.GetYear(controlFormData.ControlDate);
            report.Dictionary.Variables["controldatemounth"].ValueObject = persianCalendar.GetMonth(controlFormData.ControlDate);
            report.Dictionary.Variables["controldateday"].ValueObject = persianCalendar.GetDayOfMonth(controlFormData.ControlDate);
            report.Dictionary.Variables["filenumber"].Value = controlFormData.FileNumber;
            report.Dictionary.Variables["toolcode"].Value = controlFormData.ToolCode;
            report.Dictionary.Variables["standardrefference"].Value = controlFormData.StandardRefference;
            report.Dictionary.Variables["employername"].Value = controlFormData.EmployerName;
            report.Dictionary.Variables["employeraddress"].Value = controlFormData.EmployerAddress;
            report.DataSources.Clear();

            for (int i = 0; i < controlFormData.Groups.Count; i++)
            {
                FormDataGroupModel dataGroup = controlFormData.Groups[i];
                if (this.GetGroupType(dataGroup) == GroupType.QuestionWithoutSubtitle)
                {
                    CreateQuestionWithoutSubtitle();
                    AddQuestionWithoutSubtitle(ref report, dataGroup, "question", string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.FourColumnQuestionWithSubtitle)
                {
                    CreateFourQuestion();
                    AddFourQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.FiveColumnQuestionWithSubtitle)
                {
                    CreateFiveQuestion();
                    AddFiveQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneColumnCheckboxWithTwoQuestion)
                {
                    CreateOneColumnChecklistWithTwoQuestion();
                    AddOneColumnChecklistWithTwoQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneColumnCheckboxWithThreeQuestion)
                {
                    CreateOneColumnChecklistWithThreeQuestion();
                    AddOneColumnChecklistWithThreeQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneColumnCheckboxWithThreeQuestionAndNote)
                {
                    CreateOneColumnChecklistWithThreeQuestionAndNote();
                    AddOneColumnChecklistWithThreeQuestionAndNote(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.ThreeColumnCheckboxWithThreeQuestion)
                {
                    CreateThreeColumnChecklistWithThreeQuestion();
                    AddThreeColumnChecklistWithThreeQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneQuestionOneAnswer)
                {
                    CreateOneQuestionOneAnswer();
                    AddOneColumnChecklistWithOneQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }

            }


            try
            {
                // MemoryStream f = new MemoryStream();
                // report.ExportDocument(StiExportFormat.Pdf, @"x.pdf");

                // report.Show();
                //report.Compile();
                // report.Render();
                // report.Design();
                //  report.Compile();
                // report.Compile();
                // report.Render();
                report.Dictionary.Synchronize();
                report.Render();
              
               return StiNetCoreReportResponse.PrintAsPdf(report);
                // report.Show();
                //report.Design();

                //    DataTable v = new DataTable();
                //   report.Compile();
                //      report.RegData("d", v);
                //      report.Dictionary.Synchronize();
                //      report.RegReportDataSources();
                //  report.Save(@"E:\itemtmps\h.mrt");
                //   report.Render();


            }
            catch (Exception e)
            {

                throw e;
            }

            // FileStream s = new FileStream(@"E:\itemtmps\x.pdf", FileMode.Create);
            //  file.CopyTo(s);

            //    File.WriteAllBytes(@"E:\itemtmps\r.pdf",file.)
        }
        public StiNetCoreActionResult GenerateControlReport(ControlFormReportModel controlFormData)
        {
            StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";
            StiReport report = new StiReport();
            PersianCalendar persianCalendar = new PersianCalendar();
            report.Load(Resources.reporttemplate);

            report.Dictionary.Variables.Add("itemtitle", controlFormData.ItemName);
          //  report.Dictionary.Variables.Add("firsttimeyear", persianCalendar.GetYear(controlFormData.FirstTime));
         //   report.Dictionary.Variables.Add("firsttimemounth", persianCalendar.GetMonth(controlFormData.FirstTime));
          //  report.Dictionary.Variables.Add("firsttimeday", persianCalendar.GetDayOfMonth(controlFormData.FirstTime));
            report.Dictionary.Variables["formcode"].Value = controlFormData.FormCode;
            report.Dictionary.Variables["reviewdateyear"].ValueObject = persianCalendar.GetYear(controlFormData.ReviewDate);
            report.Dictionary.Variables["reviewdatemounth"].ValueObject = persianCalendar.GetMonth(controlFormData.ReviewDate);
            report.Dictionary.Variables["reviewdateday"].ValueObject = persianCalendar.GetDayOfMonth(controlFormData.ReviewDate);
            report.Dictionary.Variables["controldateyear"].ValueObject = persianCalendar.GetYear(controlFormData.ControlDate);
            report.Dictionary.Variables["controldatemounth"].ValueObject = persianCalendar.GetMonth(controlFormData.ControlDate);
            report.Dictionary.Variables["controldateday"].ValueObject = persianCalendar.GetDayOfMonth(controlFormData.ControlDate);
            report.Dictionary.Variables["filenumber"].Value = controlFormData.FileNumber;
            report.Dictionary.Variables["toolcode"].Value = controlFormData.ToolCode;
            report.Dictionary.Variables["standardrefference"].Value = controlFormData.StandardRefference;
            report.Dictionary.Variables["employername"].Value = controlFormData.EmployerName;
            report.Dictionary.Variables["employeraddress"].Value = controlFormData.EmployerAddress;
            report.DataSources.Clear();

            for (int i = 0; i < controlFormData.Groups.Count; i++)
            {
                FormDataGroupModel dataGroup = controlFormData.Groups[i];
                if (this.GetGroupType(dataGroup) == GroupType.QuestionWithoutSubtitle)
                {
                    CreateQuestionWithoutSubtitle();
                    AddQuestionWithoutSubtitle(ref report, dataGroup, "question", string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.FourColumnQuestionWithSubtitle)
                {
                    CreateFourQuestion();
                    AddFourQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.FiveColumnQuestionWithSubtitle)
                {
                    CreateFiveQuestion();
                    AddFiveQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneColumnCheckboxWithTwoQuestion)
                {
                    CreateOneColumnChecklistWithTwoQuestion();
                    AddOneColumnChecklistWithTwoQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneColumnCheckboxWithThreeQuestion)
                {
                    CreateOneColumnChecklistWithThreeQuestion();
                    AddOneColumnChecklistWithThreeQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneColumnCheckboxWithThreeQuestionAndNote)
                {
                    CreateOneColumnChecklistWithThreeQuestionAndNote();
                    AddOneColumnChecklistWithThreeQuestionAndNote(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.ThreeColumnCheckboxWithThreeQuestion)
                {
                    CreateThreeColumnChecklistWithThreeQuestion();
                    AddThreeColumnChecklistWithThreeQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }
                else if (this.GetGroupType(dataGroup) == GroupType.OneQuestionOneAnswer)
                {
                    CreateOneQuestionOneAnswer();
                    AddOneColumnChecklistWithOneQuestion(ref report, dataGroup, string.Format("question{0}", i), string.Format("{0}{0}", i));
                }

            }


            try
            {
               
                report.Dictionary.Synchronize();
                report.Render();

                return StiNetCoreReportResponse.PrintAsPdf(report);
                


            }
            catch (Exception e)
            {

                throw e;
            }

            
        }
        private void AddOneColumnChecklistWithOneQuestion(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            string name = "onecolumnchecklistwithonequestion";
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(System.IO.File.ReadAllText(@"E:\itemtmps\onecolumnchecklistwithonequestion.cfc"));
            CreateOneColumnChecklistWithOneQuestion(report, group.Title, components[0], i);
            CreateOneColumnChecklistWithOneQuestionQuestionHeader(report, group, components[1], i);
            CreateOneColumnChecklistWithOneQuestionQuestionDataband(report, group.Questions, components[2], datasourcename, i);
        }

        private void CreateOneColumnChecklistWithOneQuestionQuestionDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateOneColumnChecklistWithOneQuestionQuestionQuestionTable(questions, datasourcename);
            //report.RegData()
            report.RegData(table);
        }

        private DataTable CreateOneColumnChecklistWithOneQuestionQuestionQuestionTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.FirstAnswer);
            }
            return table;
        }

        private void CreateOneColumnChecklistWithOneQuestionQuestionHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Text = group.QuestionHeaders[0];
            headerBand.Components.AddRange(stiComponents);
        }

        private void CreateOneColumnChecklistWithOneQuestion(StiReport report, string title, ComponentModel component, string i)
        {
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(component.ComponentChilds));
            (stiComponents[0] as StiText).Text = title;
            StiHeaderBand header = new StiHeaderBand();
            header.LoadFromJsonObject(JObject.Parse(component.Component));
            header.Name += i.ToString();
            header.Components.Clear();
            report.Pages[0].Components.Add(header);
            foreach (StiComponent item in stiComponents)
            {
                item.Name += random.Next(1, 1000000) + i.ToString();
            }
            header.Components.AddRange(stiComponents);
        }

        private void CreateOneQuestionOneAnswer()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(@"E:\reportcomponentsnew.mrt");
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[6] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"E:\itemtmps\onecolumnchecklistwithonequestion.cfc", s);
        }

        private void CreateThreeColumnChecklistWithThreeQuestion()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(Resources.reportcomponentsnew);
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[4] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"ThreeColumnChecklistWithThreeQuestion.cfc", s);
        }


        private void AddThreeColumnChecklistWithThreeQuestion(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            string name = "ThreeColumnChecklistWithThreeQuestion";
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(System.IO.File.ReadAllText(@"" + name + ".cfc"));
            CreateThreeColumnGroupHeader(report, group.AnswerColumns, group.Title, components[0], i);
            CreateThreeColumnChecklistWithThreeQuestionHeader(report, group, components[1], i);
            CreateThreeColumnChecklistWithThreeQuestionDataband(report, group.Questions, components[2], datasourcename, i);
            CreateOneColumnChecklistWithThreeQuestionAndNoteDataband(report, group.Questions, components[2], datasourcename, i);
        }
        private void AddOneColumnChecklistWithThreeQuestionAndNote(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(Encoding.Default.GetString(Resources.reportcomponentsnew));
            CreateGroupHeader(report, group.Title, components[0], i);
            CreateOneColumnChecklistWithThreeQuestionAndNoteHeader(report, group, components[1], i);
            CreateOneColumnChecklistWithThreeQuestionAndNoteDataband(report, group.Questions, components[2], datasourcename, i);
        }
        private void AddOneColumnChecklistWithThreeQuestion(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            string name = "OneColumnChecklistWithThreeQuestion";
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(System.IO.File.ReadAllText(@"" + name + ".cfc"));
            CreateGroupHeader(report, group.Title, components[0], i);
            CreateOneColumnChecklistWithThreeQuestionHeader(report, group, components[1], i);
            CreateOneColumnChecklistWithThreeQuestionDataband(report, group.Questions, components[2], datasourcename, i);
        }
        private void AddOneColumnChecklistWithTwoQuestion(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            string name = "threecolumnquestionwithsubtitle";
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(System.IO.File.ReadAllText(@"E:\itemtmps\OneColumnChecklistWithTwoQuestion.cfc"));
            CreateGroupHeader(report, group.Title, components[0], i);
            CreateOneColumnChecklistWithTwoQuestionHeader(report, group, components[1], i);
            CreateOneColumnChecklistWithTwoQuestionDataband(report, group.Questions, components[2], datasourcename, i);
        }
        private void CreateOneColumnChecklistWithThreeQuestionAndNote()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(Resources.reportcomponentsnew);
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[5] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"E:\itemtmps\OneColumnChecklistWithThreeQuestionAndNote.cfc", s);
        }
        private void CreateOneColumnChecklistWithThreeQuestion()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(Resources.reportcomponentsnew);
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[3] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"OneColumnChecklistWithThreeQuestion.cfc", s);
        }
        private void CreateOneColumnChecklistWithTwoQuestion()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(Resources.reportcomponentsnew);
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[2] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"E:\itemtmps\OneColumnChecklistWithTwoQuestion.cfc", s);
        }

        private void CreateFiveQuestion()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(Resources.reportcomponentsnew);
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[1] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"fivequestion.cfc", s);
        }

        private void AddFiveQuestion(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            string name = "threecolumnquestionwithsubtitle";
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(System.IO.File.ReadAllText(@"" + name + ".cfc"));
            CreateGroupHeader(report, group.Title, components[0], i);
            CreateFiveQuestionColumnHeader(report, group, components[1], i);
            CreateFiveQuestionDataband(report, group.Questions, components[2], datasourcename, i);
        }
        private void AddFourQuestion(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            string name = "threecolumnquestionwithsubtitle";
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(System.IO.File.ReadAllText(@"" + name + ".cfc"));
            CreateGroupHeader(report, group.Title, components[0], i);
            CreateFourQuestionColumnHeader(report, group, components[1], i);
            CreateFourQuestionDataband(report, group.Questions, components[2], datasourcename, i);
        }
        private void CreateFiveQuestionDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateFiveQuestionTable(questions, datasourcename);
            report.RegData(datasourcename, table);
        }
        private void CreateThreeColumnChecklistWithThreeQuestionDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateThreeColumnChecklistWiththreeQuestionTable(questions, datasourcename);
            report.RegData(datasourcename, table);
        }
        private void CreateOneColumnChecklistWithThreeQuestionAndNoteDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateOneColumnChecklistWiththreeQuestionAndNoteTable(questions, datasourcename);
            report.RegData(datasourcename, table);
        }
        private void CreateOneColumnChecklistWithThreeQuestionDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateOneColumnChecklistWiththreeQuestionTable(questions, datasourcename);
            report.RegData(datasourcename, table);
        }
        private void CreateOneColumnChecklistWithTwoQuestionDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateOneColumnChecklistWithTwoQuestionTable(questions, datasourcename);
            report.RegData(datasourcename, table);
        }
        private void CreateFourQuestionDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel componentModel, string datasourcename, string i)
        {
            CreateDataband(report, questions, componentModel, datasourcename, i);
            DataTable table = CreateFourQuestionTable(questions, datasourcename);
            report.RegData(datasourcename, table);
        }
        private DataTable CreateFourQuestionTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            table.Columns.Add("SecondAnswer", typeof(string));
            table.Columns.Add("ThirdAnswer", typeof(string));
            table.Columns.Add("ForthAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.FirstAnswer,
                    question.SecondAnswer,
                    question.ThirdAnswer,
                    question.ForthAnswer);
            }
            return table;
        }
        private DataTable CreateThreeColumnChecklistWiththreeQuestionTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("SecondQuestion", typeof(string));
            table.Columns.Add("ThirdQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            table.Columns.Add("SecondAnswer", typeof(string));
            table.Columns.Add("ThirdAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.SecondQuestion,
                    question.ThirdQuestion,
                    question.FirstAnswer,
                    question.SecondAnswer,
                    question.ThirdAnswer);
            }
            return table;
        }
        private DataTable CreateOneColumnChecklistWiththreeQuestionAndNoteTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("SecondQuestion", typeof(string));
            table.Columns.Add("ThirdQuestion", typeof(string));
            table.Columns.Add("ForthQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            table.Columns.Add("SecondAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.SecondQuestion,
                    question.ThirdQuestion,
                    question.ForthQuestion,
                    question.FirstAnswer,
                    question.SecondAnswer);
            }
            return table;
        }
        private DataTable CreateOneColumnChecklistWiththreeQuestionTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("SecondQuestion", typeof(string));
            table.Columns.Add("ThirdQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.SecondQuestion,
                    question.ThirdQuestion,
                    question.FirstAnswer);
            }
            return table;
        }
        private DataTable CreateOneColumnChecklistWithTwoQuestionTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("SecondQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.SecondQuestion,
                    question.FirstAnswer);
            }
            return table;
        }
        private DataTable CreateFiveQuestionTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable table = new DataTable(datasourcename);
            table.Columns.Add("FirstQuestion", typeof(string));
            table.Columns.Add("FirstAnswer", typeof(string));
            table.Columns.Add("SecondAnswer", typeof(string));
            table.Columns.Add("ThirdAnswer", typeof(string));
            table.Columns.Add("ForthAnswer", typeof(string));
            table.Columns.Add("FifthAnswer", typeof(string));
            for (int i = 0; i < questions.Count; i++)
            {
                FormDataRowModel question = questions[i];
                table.Rows.Add(question.FirstQuestion,
                    question.FirstAnswer,
                    question.SecondAnswer,
                    question.ThirdAnswer,
                    question.ForthAnswer,
                    question.FifthAnswer);
            }
            return table;
        }
        private void CreateThreeColumnChecklistWithThreeQuestionHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Text = group.QuestionHeaders[0];
            (stiComponents[1] as StiText).Text = group.QuestionHeaders[1];
            (stiComponents[2] as StiText).Text = group.QuestionHeaders[2];
            headerBand.Components.AddRange(stiComponents);
        }
        private void CreateOneColumnChecklistWithThreeQuestionAndNoteHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Text = group.QuestionHeaders[0];
            (stiComponents[1] as StiText).Text = group.QuestionHeaders[1];
            (stiComponents[2] as StiText).Text = group.QuestionHeaders[2];
            (stiComponents[3] as StiText).Text = group.QuestionHeaders[3];
            (stiComponents[4] as StiText).Text = group.AnswerColumns[1];
            headerBand.Components.AddRange(stiComponents);
        }
        private void CreateOneColumnChecklistWithThreeQuestionHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Name = random.Next(1, 1000000) + counter;
            (stiComponents[1] as StiText).Name = random.Next(1, 1000000) + counter;
            (stiComponents[2] as StiText).Name = random.Next(1, 1000000) + counter;
            (stiComponents[3] as StiText).Name = random.Next(1, 1000000) + counter;
            (stiComponents[0] as StiText).Text = group.QuestionHeaders[0];
            (stiComponents[2] as StiText).Text = group.AnswerColumns[0];
            (stiComponents[3] as StiText).Text = group.QuestionHeaders[1];
            (stiComponents[1] as StiText).Text = group.QuestionHeaders[2];
            headerBand.Components.AddRange(stiComponents);
        }
        private void CreateOneColumnChecklistWithTwoQuestionHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Text = group.QuestionHeaders[0];
            (stiComponents[2] as StiText).Text = group.QuestionHeaders[1];
            (stiComponents[1] as StiText).Text = group.AnswerColumns[0];
            headerBand.Components.AddRange(stiComponents);
        }
        private void CreateFiveQuestionColumnHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Text = group.Subtitle;
            (stiComponents[1] as StiText).Text = group.QuestionHeaders[0];
            (stiComponents[2] as StiText).Text = group.QuestionHeaders[1];
            (stiComponents[3] as StiText).Text = group.QuestionHeaders[2];
            (stiComponents[4] as StiText).Text = group.QuestionHeaders[3];
            (stiComponents[5] as StiText).Text = group.QuestionHeaders[4];
            headerBand.Components.AddRange(stiComponents);
        }
        private void CreateFourQuestionColumnHeader(StiReport report, FormDataGroupModel group, ComponentModel componentModel, string counter)
        {
            StiColumnHeaderBand headerBand = new StiColumnHeaderBand();
            headerBand.LoadFromJsonObject(JObject.Parse(componentModel.Component));
            headerBand.Components.Clear();
            headerBand.Name += random.Next(1, 1000000) + counter.ToString();
            report.Pages[0].Components.Add(headerBand);
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(componentModel.ComponentChilds));
            (stiComponents[0] as StiText).Text = group.Subtitle;
            (stiComponents[1] as StiText).Text = group.QuestionHeaders[0];
            (stiComponents[2] as StiText).Text = group.QuestionHeaders[1];
            (stiComponents[3] as StiText).Text = group.QuestionHeaders[2];
            (stiComponents[4] as StiText).Text = group.QuestionHeaders[3];
            headerBand.Components.AddRange(stiComponents);
        }
        private void CreateFourQuestion()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(Resources.reportcomponentsnew);
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[0] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component2 = new ComponentModel();
            component2.Component = (panel.Components[1] as StiColumnHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component2.ComponentChilds = (panel.Components[1] as StiColumnHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[2] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[2] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component2);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"E:\itemtmps\fourquestion.cfc", s);
        }

        public void AddQuestionWithoutSubtitle(ref StiReport report, FormDataGroupModel group, string datasourcename, string i)
        {
            List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(File.ReadAllText(@"E:\itemtmps\questiongroupwithoutcolumn.cfc"));
            //List<ComponentModel> components = JsonConvert.DeserializeObject<List<ComponentModel>>(Encoding.Default.GetString(Resources.questiongroupwithoutcolumn));
            CreateGroupHeader(report, group.Title, components[0], i);
            CreateDataband(report, group.Questions, components[1], datasourcename, i);

        }
        private void CreateGroupHeader(StiReport report, string title, ComponentModel component, string i)
        {
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(component.ComponentChilds));
            (stiComponents[0] as StiText).Text = title;
            (stiComponents[0] as StiText).Name = (stiComponents[0] as StiText).Name + random.Next(1, 1000000) + i;
            StiHeaderBand header = new StiHeaderBand();
            header.LoadFromJsonObject(JObject.Parse(component.Component));
            header.Name += i.ToString();
            header.Components.Clear();
            report.Pages[0].Components.Add(header);
            foreach (StiComponent item in stiComponents)
            {
                item.Name += random.Next(1, 1000000) + i.ToString();
            }
            header.Components.AddRange(stiComponents);



        }
        private void CreateThreeColumnGroupHeader(StiReport report, List<string> columns, string title, ComponentModel component, string i)
        {
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            stiComponents.LoadFromJsonObject(JObject.Parse(component.ComponentChilds));
            (stiComponents[0] as StiText).Text = title;
            (stiComponents[1] as StiText).Text = columns[0];
            (stiComponents[2] as StiText).Text = columns[1];
            (stiComponents[3] as StiText).Text = columns[2];
            StiHeaderBand header = new StiHeaderBand();
            header.LoadFromJsonObject(JObject.Parse(component.Component));
            header.Name += random.Next(1, 1000000) + i.ToString();
            header.Components.Clear();
            report.Pages[0].Components.Add(header);
            foreach (StiComponent item in stiComponents)
            {
                item.Name += i.ToString();
            }
            header.Components.AddRange(stiComponents);



        }
        private void CreateDataband(StiReport report, List<FormDataRowModel> questions, ComponentModel component, string datasourcename, string i)
        {
            DataTable dataTable = CreateQuestionWithoutSubtitleTable(questions, datasourcename);
            report.DataStore.RegData(dataTable);
            report.RegData(dataTable);
            StiDataBand dataBand = new StiDataBand();
            dataBand.LoadFromJsonObject(JObject.Parse(component.Component));
            dataBand.DataSourceName = datasourcename;
            dataBand.Name += random.Next(1, 1000000).ToString() + i;
            StiComponentsCollection stiComponents = new StiComponentsCollection();
            string com = component.ComponentChilds.Replace("hamed", datasourcename);
            stiComponents.LoadFromJsonObject(JObject.Parse(com));
            foreach (StiText item in stiComponents)
            {
                item.Name += random.Next(1, 1000000) + i.ToString();
            }
            report.Pages[0].Components.Add(dataBand);
            dataBand.Components.Clear();
            dataBand.Components.AddRange(stiComponents);


        }

        private void Item_GetValue(object sender, Stimulsoft.Report.Events.StiGetValueEventArgs e)
        {
            string s = e.Value;
            e.Value = "{" + s + "}";
        }

        private DataTable CreateQuestionWithoutSubtitleTable(List<FormDataRowModel> questions, string datasourcename)
        {
            DataTable dataTable = new DataTable(datasourcename);
            dataTable.Columns.Add("firstquestion", typeof(string));
            dataTable.Columns.Add("firstanswer", typeof(string));
            dataTable.Columns.Add("secondquestion", typeof(string));
            dataTable.Columns.Add("secondanswer", typeof(string));
            if (questions.Count % 2 == 0)
            {
                for (int i = 0; i < questions.Count - 3; i += 2)
                {
                    dataTable.Rows.Add(questions[i].FirstQuestion, questions[i].FirstAnswer, questions[i + 1].FirstQuestion, questions[i + 1].FirstAnswer);
                }
                dataTable.Rows.Add(questions[questions.Count - 2].FirstQuestion, questions[questions.Count - 2].FirstAnswer, questions[questions.Count - 1].FirstQuestion, questions[questions.Count - 1].FirstAnswer);
            }
            else
            {
                for (int i = 0; i < questions.Count - 2; i += 2)
                {
                    dataTable.Rows.Add(questions[i].FirstQuestion, questions[i].FirstAnswer, questions[i + 1].FirstQuestion, questions[i + 1].FirstAnswer);
                }
                dataTable.Rows.Add(questions[questions.Count - 1].FirstQuestion, questions[questions.Count - 1].FirstAnswer, "", "");
            }


            return dataTable;

        }
        private void CreateQuestionWithoutSubtitle()
        {
            StiReport tmpReport = new StiReport();
            tmpReport.Load(@"E:\reportcomponentsnew.mrt");
            //tmpReport.Design();
            List<ComponentModel> components = new List<ComponentModel>();
            StiPanel panel = tmpReport.Pages[0].Components[7] as StiPanel;
            ComponentModel component1 = new ComponentModel();
            component1.Component = (panel.Components[0] as StiHeaderBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component1.ComponentChilds = (panel.Components[0] as StiHeaderBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            ComponentModel component3 = new ComponentModel();
            component3.Component = (panel.Components[1] as StiDataBand).SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            component3.ComponentChilds = (panel.Components[1] as StiDataBand).Components.SaveToJsonObject(StiJsonSaveMode.Document).ToString();
            components.Add(component1);
            components.Add(component3);
            string s = JsonConvert.SerializeObject(components);
            System.IO.File.WriteAllText(@"E:\itemtmps\questiongroupwithoutcolumn.cfc", s);
        }
    }
}
