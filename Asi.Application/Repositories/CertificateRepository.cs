using Asi.Application.Util;
using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICertificate = Asi.Application.Interface.ICertificate;

namespace Asi.Application.Repositories
{
    internal class CertificateRepository : ICertificate
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public CertificateRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }

        async Task<PagedList<CertificateModel>> ICertificate.GetAll(int page, int pagesize)
        {
            PagedList<Certificate> certificates = _dbBusinessUnit.Certificates.GetAll(new PaginationFilter(page, pagesize));
            return await Task.Run(() => _mapper.Map<PagedList<CertificateModel>>(certificates));
        }

        async Task<List<CertificateModel>> ICertificate.GetAll()
        {
            List<Certificate> certificates = await _dbBusinessUnit.Certificates.GetAll();
            return _mapper.Map<PagedList<CertificateModel>>(certificates);
        }

        async Task<RequestCertificateModel> ICertificate.GetMissmatchForm(int certificateId)
        {
            Certificate certificate = await _dbBusinessUnit.Certificates.GetNextControl(certificateId);
            RequestCertificateModel controlFormSend = _mapper.Map<RequestCertificateModel>(certificate);
            controlFormSend.FormDatas = new List<RequestCertificateControlModel>();
            // controlFormSend.FormDatas.Add(_mapper.Map<CertificateControlModel>(certificate.RefferenceForm))
            int repeat = await _dbBusinessUnit.Certificates.LastControlRepeat(certificate.Id);
            controlFormSend.ControlTime = repeat;
            controlFormSend.ControlTimeText = StaticMethods.GetControlTime(repeat);
            return controlFormSend;
        }

        async Task<List<CertificateControlModel>> ICertificate.GetControls(int qeueId)
        {
            try
            {
                List<CertificateControl> certificateControls = await _dbBusinessUnit.Certificates.GetCertificateControls(qeueId);
                List<CertificateControlModel> formDatas = _mapper.Map<List<CertificateControlModel>>(certificateControls);
                return formDatas;
            }
            catch (System.Exception e)
            {

                throw ;
            }


        }

        async Task<PagedList<CertificateModel>> ICertificate.GetUnsubmittedForms(int pageNumber, int pageSize)
        {
            PagedList<Certificate> certificateQeues = _dbBusinessUnit.Certificates.GetUnSubmittedCertificates(new PaginationFilter(pageNumber, pageSize));
            PagedList<CertificateModel> certificates = _mapper.Map<PagedList<CertificateModel>>(certificateQeues);
            // PagedList<RequestCertificateModel> controlFormSends = _mapper.Map<PagedList<RequestCertificateModel>>(certificateQeues);
            return certificates;
        }

        async Task<int> ICertificate.LastControlRepeat(int certificateId)
        {
            return await _dbBusinessUnit.Certificates.LastControlRepeat(certificateId);
        }

        async Task<int> ICertificate.LastId()
        {
            return await _dbBusinessUnit.Certificates.LastId();
        }

        async Task ICertificate.SendRequest(RequestCertificateModel controlFormSend)
        {
            try
            {
                CertificateControl c = _mapper.Map<RequestCertificateControlModel, CertificateControl>(controlFormSend.FormDatas.ElementAt(0));
                Certificate certificateQeue = _mapper.Map<Certificate>(controlFormSend);
                await _dbBusinessUnit.Certificates.AddCertificateQeue(certificateQeue);
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        async Task ICertificate.SubmitCertificate(CertificateModel certificate)
        {
            //CertificateControl x = _mapper.Map<CertificateControl>(certificate.Controls.ElementAt());
            Certificate certificatedto = _mapper.Map<CertificateModel, Certificate>(certificate);
            await _dbBusinessUnit.Certificates.SubmitCertificate(certificatedto, 0);
        }

        public async Task<List<CertificateControlModel>> GetQeueControls(int qeueId)
        {
            try
            {
                List<CertificateControl> certificateControls = await _dbBusinessUnit.Certificates.GetCertificateQeueControls(qeueId);
                List<CertificateControlModel> formDatas = _mapper.Map<List<CertificateControlModel>>(certificateControls);
                return formDatas;
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        public async Task<int> UnCompleteCertificatesCount()
        {
            return await _dbBusinessUnit.Certificates.UnCompleteCertificateCount();
        }
    }
}
