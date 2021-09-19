using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class CertificateRepository : ICertificate
    {
        private readonly IAsiDbContext _dbConttext;

        public CertificateRepository(IAsiDbContext dbConttext)
        {
            _dbConttext = dbConttext;
        }

        async Task<List<Certificate>> ICertificate.GetAll()
        {
            List<Certificate> certificateDtos = await _dbConttext.Certificates
                 .Include(x => x.Province).ToListAsync();
            return certificateDtos;
        }

        async Task<Certificate> ICertificate.GetNextControl(int certificateId)
        {
            Certificate certificate = await _dbConttext.Certificates.Where(x => x.Id == certificateId).
                 Include(x => x.Province).
                 Include(x => x.RefferenceForm).
                 ThenInclude(x => x.Groups.Where(y => y.Template.IsCheckbox)).
                 ThenInclude(x => x.Template).
                 ThenInclude(x => x.QuestionHeaders).
                 Include(x => x.RefferenceForm).
                 ThenInclude(x => x.Groups.Where(y => y.Template.IsCheckbox)).
                 ThenInclude(x => x.Template).
                 ThenInclude(x => x.AnswerColumns).
                  Include(x => x.RefferenceForm).
                 ThenInclude(x => x.Groups.Where(y => y.Template.IsCheckbox)).
                 Include(x => x.RefferenceForm).
                 ThenInclude(x => x.Groups.Where(y => y.Template.IsCheckbox)).
                 ThenInclude(x => x.Answers.Where(y => y.FirstAnswer == "NotOk" ||
                   y.SecondAnswer == "NotOk" ||
                   y.ThirdAnswer == "NotOk")).ThenInclude(x => x.Template).ThenInclude(x => x.MissMatchWords).FirstOrDefaultAsync();
            return certificate;
        }

        PagedList<Certificate> ICertificate.GetUnSubmittedCertificates(PaginationFilter pagination)
        {
            try
            {

                PagedList<Certificate> controlFormQeues = _dbConttext.Certificates
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.Agancy)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.BranchPerson)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.CertificateController)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.MainController)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.TechnicalManager)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.Marketing)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.ControlForm)
                    .ThenInclude(x => x.Template)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.ControlForm)
                    .ThenInclude(x => x.Groups)
                    .ThenInclude(x => x.Template)
                    .ThenInclude(x => x.AnswerColumns)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.ControlForm)
                    .ThenInclude(x => x.Groups)
                    .ThenInclude(x => x.Template)
                    .ThenInclude(x => x.QuestionHeaders)
                    .Include(x => x.Controls)
                    .ThenInclude(x => x.ControlForm)
                    .ThenInclude(x => x.Groups)
                    .ThenInclude(x => x.Answers)
                 .Include(x => x.Province).
                 Include(x => x.CertificateType).
                 Include(x => x.ServiceType).
                 Include(x => x.Item).
                 Include(x => x.Department).
                Where(x => x.NeedToBeCompleted).ToPagedList(pagination);
                return controlFormQeues;
            }
            catch (Exception)
            {

                throw;
            }


        }

        async Task<int> ICertificate.LastControlRepeat(int certId)
        {
            int repeat = 0;
            CertificateControl _certLastControl = await _dbConttext.CertificateControls.Where(x => x.CertificateId == certId).OrderBy(x => x.Id).LastOrDefaultAsync();
            if (_certLastControl != null)
                repeat = _certLastControl.ControlTime;
            return repeat + 1;
        }

        async Task<int> ICertificate.LastId()
        {
            int i = 0;
            Certificate certificate = await _dbConttext.Certificates.OrderBy(x => x.Id).LastOrDefaultAsync();
            if (certificate != null)
                i = certificate.Id;
            return i + 1;
        }


        async Task ICertificate.AddCertificateQeue(Certificate certificate)

        {

            try
            {
                int controltime = certificate.Controls.OrderBy(x => x.ControlTime).Last().ControlTime;
                if (controltime == 1)
                {

                    certificate.NeedToBeCompleted = true;
                    await _dbConttext.Certificates.AddAsync(certificate);
                    await _dbConttext.SaveChangesAsync();
                }
                else
                {

                    for (int k = 0; k < certificate.Controls.Count; k++)
                    {
                        for (int i = 0; i < certificate.Controls.ElementAt(k).ControlForm.Groups.Count; i++)
                        {
                            for (int j = 0; j < certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.Count; j++)
                            {
                                _dbConttext.FormDataRows.Update(certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j));
                            }
                        }

                        for (int i = 0; i < certificate.Controls.ElementAt(k).ControlForm.Groups.Count; i++)
                        {
                            List<FormDataRow> formDatas = new List<FormDataRow>();
                            for (int j = 0; j < certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.Count; j++)
                            {

                                FormDataRow formDataRow = new FormDataRow()
                                {
                                    Order = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).Order,
                                    TemplateId = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).TemplateId,
                                    FifthAnswer = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).FifthAnswer,
                                    FirstAnswer = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).FirstAnswer,
                                    SecondAnswer = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).SecondAnswer,
                                    ThirdAnswer = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).ThirdAnswer,
                                    ForthAnswer = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).ForthAnswer,
                                    MissMatchWord = certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers.ElementAt(j).MissMatchWord,
                                };
                                formDatas.Add(formDataRow);

                            }
                            certificate.Controls.ElementAt(k).ControlForm.Groups.ElementAt(i).Answers = formDatas;
                        }
                    }
                    await _dbConttext.Certificates.AddAsync(certificate);
                    await _dbConttext.SaveChangesAsync();
                }


            }
            catch (Exception e)
            {
                string d = e.InnerException.Message;
                throw;
            }

        }

        async Task ICertificate.SubmitCertificate(Certificate certificate, int qeueId)
        {
            try
            {
                Certificate certificate1 = await _dbConttext.Certificates.FindAsync(certificate.Id);
                _dbConttext.Entry(certificate1).State = EntityState.Detached;
                //certificate = certificate1;
                if (certificate.Controls.ElementAt(0).ControlTime != 1)
                {
                    CertificateControl certificateControlDto = certificate.Controls.ElementAt(0);
                    certificateControlDto.CertificateId = certificate.Id;
                    List<FormDataGroup> formDataGroups = await _dbConttext.DataGroups.Where(x => x.SavedFormDataId == certificateControlDto.ControlFormId)
                        .Include(x => x.SavedFormData)
                        .ThenInclude(x => x.Groups).ThenInclude(x => x.Template)
                         .Include(x => x.SavedFormData)
                          .ThenInclude(x => x.Groups)
                        .ThenInclude(x => x.Answers).ToListAsync();
                    for (int i = 0; i < formDataGroups.Count; i++)
                    {
                        for (int j = 0; j < formDataGroups[i].Answers.Count; j++)
                        {
                            FormDataRow formDataRow = formDataGroups[i].Answers.ElementAt(j);
                            _dbConttext.FormDataRows.Update(formDataRow);
                        }
                    }
                    _dbConttext.Entry(certificate).State = EntityState.Detached;
                    for (int i = 0; i < certificate.Controls.Count; i++)
                    {
                        certificate.Controls.ElementAt(i).Submitted = true;
                    }
                    certificate.NeedToBeCompleted = false;
                    await _dbConttext.CertificateControls.AddAsync(certificate.Controls.ElementAt(0));
                    await _dbConttext.SaveChangesAsync();
                }

                else
                {
                    int refid = certificate.Controls.ElementAt(0).ControlFormId;
                    SavedFormData refferenceForm = await _dbConttext.SavedFormDatas.Where(x => x.Id == refid).Include(x => x.Groups).ThenInclude(x => x.Answers).FirstOrDefaultAsync();
                    SavedFormData savedForm = new SavedFormData();
                    List<FormDataGroup> formDataGroups = new List<FormDataGroup>();
                    for (int i = 0; i < refferenceForm.Groups.Count; i++)
                    {
                        List<FormDataRow> formDataRows = new List<FormDataRow>();
                        for (int j = 0; j < refferenceForm.Groups.ElementAt(i).Answers.Count; j++)
                        {
                            FormDataRow formDataRow = new FormDataRow()
                            {
                                Order = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).Order,
                                TemplateId = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).TemplateId,
                                FifthAnswer = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).FifthAnswer,
                                FirstAnswer = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).FirstAnswer,
                                SecondAnswer = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).SecondAnswer,
                                ThirdAnswer = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).ThirdAnswer,
                                ForthAnswer = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).ForthAnswer,
                                MissMatchWord = refferenceForm.Groups.ElementAt(i).Answers.ElementAt(j).MissMatchWord,
                            };
                            formDataRows.Add(formDataRow);
                        }
                        FormDataGroup formDataGroup = new FormDataGroup()
                        {
                            Answers = formDataRows,
                            Order = refferenceForm.Groups.ElementAt(i).Order,
                            TemplateId = refferenceForm.Groups.ElementAt(i).TemplateId,
                            Description = refferenceForm.Groups.ElementAt(i).Description
                        };
                        formDataGroups.Add(formDataGroup);
                    }

                    savedForm.TemplateId = refferenceForm.TemplateId;
                    certificate.RefferenceForm = savedForm;
                    certificate.NeedToBeCompleted = false;

                    _dbConttext.Certificates.Update(certificate);
                    await _dbConttext.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }

        public PagedList<Certificate> GetAll(PaginationFilter pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CertificateControl>> GetCertificateControls(int certificateId)
        {
            List<CertificateControl> certificateControls = await _dbConttext.CertificateControls.Where(x => x.CertificateId == certificateId && x.Submitted).Include(x => x.ControlForm).ThenInclude(x => x.Template)
                .Include(x => x.ControlForm).ThenInclude(x => x.Groups)
                 .ThenInclude(x => x.Template)
                 .ThenInclude(x => x.QuestionHeaders)
                 .Include(x => x.ControlForm).ThenInclude(x => x.Groups)
                 .ThenInclude(x => x.Template)
                 .ThenInclude(x => x.AnswerColumns)
                 .Include(x => x.ControlForm).ThenInclude(x => x.Groups)
                 .ThenInclude(x => x.Answers)
                 .ThenInclude(x => x.Template)
                 .ThenInclude(x => x.MissMatchWords)
                  .Include(x => x.MainController).ToListAsync();
            return certificateControls;


        }

        public async Task<List<CertificateControl>> GetCertificateQeueControls(int certificateId)
        {
            List<CertificateControl> certificateControls = await _dbConttext.CertificateControls.Where(x => x.CertificateId == certificateId && !x.Submitted).Include(x => x.ControlForm).ThenInclude(x => x.Template)
               .Include(x => x.ControlForm).ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Template)
                .ThenInclude(x => x.QuestionHeaders)
                .Include(x => x.ControlForm).ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Template)
                .ThenInclude(x => x.AnswerColumns)
                .Include(x => x.ControlForm).ThenInclude(x => x.Groups)
                .ThenInclude(x => x.Answers)
                .ThenInclude(x => x.Template)
                .ThenInclude(x => x.MissMatchWords)
                .Include(x => x.MainController)
                .ToListAsync();
            return certificateControls;
        }

        public async Task<int> UnCompleteCertificateCount()
        {
            return Task.Run(async () => await _dbConttext.Certificates.Where(x => x.NeedToBeCompleted == true).ToListAsync()).Result.Count;
        }
    }
}
