using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class ReportRepository : IReport
    {
        private readonly IAsiDbContext _dbContext;

        public ReportRepository(IAsiDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        async Task<Certificate> IReport.GetCertificateMissMatchReport(int certificateId)
        {
            Certificate certificate = await _dbContext.Certificates.Where(x => x.Id == certificateId).
                Include(x => x.Province).
                 Include(x => x.Controls).ThenInclude(x => x.ControlForm).ThenInclude(x => x.Template).
                 Include(x => x.Controls.Where(y => y.ControlTime == 1)).
                            ThenInclude(x => x.ControlForm).
                            ThenInclude(x => x.Groups.Where(y => y.Template.IsCheckbox)).
                            ThenInclude(x => x.Answers).ThenInclude(x => x.Template).
                               Include(x => x.Controls.Where(y => y.ControlTime == 1)).
                            ThenInclude(x => x.ControlForm).
                            ThenInclude(x => x.Groups.Where(y => y.Template.IsCheckbox)).
                            ThenInclude(x => x.Template).
            FirstOrDefaultAsync();
            //MissMatchReportModel missMatchReport = _mapper.Map<MissMatchReportModel>(certificate);

            // missMatchReport.MissMatchWords = this.GetMissMatchWords(certificate);
            return certificate;
        }
        private List<string> GetMissMatchWords(Certificate d)
        {
            List<string> words = new List<string>();
            var l = d.Controls.ElementAt(0).ControlForm.Groups.Where(x => x.Template.IsCheckbox).ToList();
            var rl = new List<FormDataRow>();
            for (int i = 0; i < l.Count; i++)
            {
                List<FormDataRow> dr = l[i].Answers.Where(x => x.FifthAnswer == "Not Ok"
                  || x.FirstAnswer == "Not Ok"
                  || x.SecondAnswer == "Not Ok"
                  || x.ThirdAnswer == "Not Ok"
                  || x.ForthAnswer == "Not Ok").ToList();
                rl.AddRange(dr);
            }
            ///////////////////////words = rl.Select(x => x.Template.MissMatchWords.Select(x=>x.Text).ToList());
            //for (int i = 0; i < d.Controls.ElementAt(0).FormData.Groups.Count; i++)
            //{
            //    if (d.Controls.ElementAt(0).FormData.Groups.ElementAt(i).Template.IsCheckbox)
            //    {
            //        for (int j = 0; i < d.Controls.ElementAt(0).FormData.Groups.ElementAt(i).Answers.Count; i++)
            //        {
            //            FormDataRowDto formDataRow = d.Controls.ElementAt(0).FormData.Groups.ElementAt(i).Answers.ElementAt(j);
            //            if (formDataRow.FifthAnswer== "Not Ok" || formDataRow.FirstAnswer== "Not Ok" ||formDataRow.SecondAnswer== "Not Ok"||formDataRow.ThirdAnswer== "Not Ok"
            //                || formDataRow.ForthAnswer== "Not Ok")
            //            {
            //                words.Add(formDataRow.Template.MissMatchWord);
            //            }

            //        }
            //    }


            //}
            int c = words.Count;
            return words;
        }

        async Task<Certificate> IReport.GetCertificateReport(int certificateId)
        {
            try
            {
                Certificate certificate = await _dbContext.Certificates
                    .Include(x => x.RefferenceForm)
                    .ThenInclude(x => x.Template).
                    Include(x => x.Province).
                Include(x => x.RefferenceForm)
                .ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Answers)
                .Include(x => x.RefferenceForm)
                .ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Template)
                .ThenInclude(x => x.AnswerColumns)
                .Include(x => x.RefferenceForm)
                .ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Answers)
                .Include(x => x.RefferenceForm)
                .ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Answers).
                ThenInclude(x => x.Template)
                .Include(x => x.RefferenceForm)
                .ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Template)
                .ThenInclude(x => x.QuestionHeaders)
                .Include(x => x.Controls)
                .ThenInclude(x => x.MainController)
                .FirstOrDefaultAsync();


                //  ControlFormReportModel res = _mapper.Map<ControlFormReportModel>(certificate);
                //ReportDesigner r = new ReportDesigner();

                //    Stream b = r.GenerateReport(res);
                // File.WriteAllText(@"E:\r.txt", JsonConvert.SerializeObject(res));
                // return b;
                return certificate;
            }
            catch (System.Exception e)
            {

                throw;
            }

        }
    }
}
