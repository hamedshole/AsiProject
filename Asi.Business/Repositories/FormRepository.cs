using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class FormRepository : IForm
    {

        private readonly IAsiDbContext _dbContext;

        public FormRepository(IAsiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<SavedFormData> AddFormData(SavedFormData savedFormData)
        {
            throw new NotImplementedException();
        }

        public async Task<FormTemplate> AddFormTemplate(FormTemplate formTemplate)
        {
            try
            {
                await _dbContext.FormTemplates.AddAsync(formTemplate);
                //   await _dbContext.SaveChangesAsync();
                return formTemplate;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        async Task<CertificateControl> IForm.GetFormData(int id)
        {
            CertificateControl controlDataDto = await _dbContext.CertificateControls.Where(x => x.Id == id)
                .Include(x => x.ControlForm).
                ThenInclude(x => x.Groups).ThenInclude(x => x.Answers).
                Include(x => x.ControlForm)
                .ThenInclude(x => x.Groups).ThenInclude(x => x.Template).ThenInclude(x => x.AnswerColumns).
                FirstOrDefaultAsync();
            Certificate certificateDto = await _dbContext.Certificates.Where(x => x.Id == controlDataDto.CertificateId).
                FirstOrDefaultAsync();
            return controlDataDto;
        }

        async Task<List<FormTemplate>> IForm.GetFormTemplate(int itemid)
        {
            try
            {
                List<FormTemplate> formTemplates = await _dbContext.FormTemplates
               .Include(x => x.CertificateType)
               .Include(x => x.Groups).ThenInclude(x => x.Questions).ThenInclude(x => x.MissMatchWords)
               .Include(x => x.Groups).ThenInclude(x => x.QuestionHeaders)
               .Include(x => x.Groups).ThenInclude(x => x.AnswerColumns)
               .Where(x => x.IsDeleted == false && x.ItemId == itemid).ToListAsync();
                formTemplates.ForEach(x => SetOrder(x));

                return formTemplates;
            }
            catch (Exception e)
            {

                throw;
            }

            // FormTemplate formTemplateDto = await this._dbContext.FormTemplates.
            //     Include(x => x.Groups).
            //     ThenInclude(x => x.AnswerColumns).
            //     Include(x => x.Groups).ThenInclude(x => x.Questions).
            //       Include(x => x.Groups).ThenInclude(x => x.QuestionHeaders).
            //     Where(x => x.Id == formid).FirstOrDefaultAsync();
            // return formTemplateDto;
            //// return _mapper.Map<FormTemplateModel>(formTemplateDto);
        }

        private void SetOrder(FormTemplate x)
        {
            for (int i = 0; i < x.Groups.Count; i++)
            {
                x.Groups.ElementAt(i).AnswerColumns = x.Groups.ElementAt(i).AnswerColumns.OrderBy(ac => ac.Order).ToList();
                x.Groups.ElementAt(i).QuestionHeaders = x.Groups.ElementAt(i).QuestionHeaders.OrderBy(ac => ac.Order).ToList();
                x.Groups.ElementAt(i).Questions = x.Groups.ElementAt(i).Questions.OrderBy(ac => ac.Order).ToList();
            }
            x.Groups = x.Groups.OrderBy(g => g.Order).ToList();
        }

        async Task<List<FormTemplate>> IForm.GetMobileForm(int itemid)
        {
            try
            {
                List<FormTemplate> itemFormTemplate = await _dbContext.FormTemplates.
                Include(x => x.Groups).ThenInclude(x => x.Questions.OrderBy(y => y.Order)).
                Include(x => x.Groups).ThenInclude(x => x.AnswerColumns).
                Include(x => x.Groups).ThenInclude(x => x.QuestionHeaders)
                .Where(x => x.ItemId == itemid).ToListAsync();



                //foreach (var items in x.Groups)
                //{
                //    foreach (var dd in items.Questions)
                //    {
                //        dd.FirstAnswer = "12";
                //        dd.SecondAnswer = "OK";
                //    }
                //}
                return itemFormTemplate;
            }
            catch (Exception)
            {

                throw;
            }

        }

        Stream IForm.GetPdf(int formid)
        {

            //   FormDataModel d =Task.Run(async()=>await (this as IForm).GetMobileForm(formid)).Result;
            //ControlFormReportModel g = new ControlFormReportModel();

            //FormDataModel f = JsonConvert.DeserializeObject<FormDataModel>(File.ReadAllText(@"E:\MobileForm.txt"));
            //g.Groups = f.Groups;
            //g.ControlDate = DateTime.Now;
            //g.ReviewDate = DateTime.Now;
            //g.StandardRefference = "ASI";
            //g.ToolCode = "1";
            //g.FormCode = "1";
            //g.FileNumber = "11";
            //g.EmployerName = "شعله";
            //g.EmployerAddress = "تبریز";
            //ReportDesigner x = new ReportDesigner();
            //  Stream fr = x.GenerateReport(g);
            return new MemoryStream();
        }



    }
}