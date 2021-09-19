using Asi.Domain.Common;
using Asi.Client.Util.Interfaces;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IV1Certificate = Asi.Client.V1.Interfaces.ICertificate;
using IV2Certificate = Asi.Client.V2.Interfaces.ICertificate;

namespace Asi.Client.Repositories
{
    internal class CertificateRepository : IV1Certificate, IV2Certificate
    {
        private readonly int _version;
        private readonly ICustomHttpClient _httpCLient;
        private readonly string _route;

        public CertificateRepository(ICustomHttpClient httpCLient, string route,int version=1)
        {
            this._version = version;
            _httpCLient = httpCLient;
            _route = route;
        }



        public PagedList<CertificateModel> GetAll(int page, int pagesize)
        {
            _httpCLient.SetRoute(_route);
            var x = Task.Run(async () => await _httpCLient.Get<PagedList<CertificateModel>>(version:_version)).Result;
            return x;
        }
        public List<CertificateModel> GetAll()
        {
            _httpCLient.SetRoute(_route);
            var x = Task.Run(async () => await _httpCLient.Get<List<CertificateModel>>(version: _version)).Result;
            return x;
        }

        public List<CertificateControlModel> GetControls(int qeueId)
        {
            _httpCLient.SetRoute(_route);
            var x = Task.Run(async () => await _httpCLient.Get<List<CertificateControlModel>>(string.Format("controls/{0}", qeueId), version: _version)).Result;
            return x;
        }

        public RequestCertificateModel GetMissmatchForm(int certificateId)
        {
            _httpCLient.SetRoute(_route);
            var x = Task.Run(async () => await _httpCLient.Get<RequestCertificateModel>(string.Format("nextcontrol/{0}", certificateId), version: _version)).Result;
            return x; ;
        }

        public List<FormDataModel> GetQeueControls(int qeueId)
        {
            _httpCLient.SetRoute(_route);
            var x = Task.Run(async () => await _httpCLient.Get<List<FormDataModel>>(string.Format("unsubmitted/controls/{0}", qeueId), version: _version)).Result;
            return x; 
        }

        public PagedList<CertificateModel> GetUnsubmittedForms(int pageNumber, int pageSize)
        {
            _httpCLient.SetRoute(_route);

            return _httpCLient.Get<PagedList<CertificateModel>>(string.Format("unsubmitted?PageNumber=1&PageSize=20", pageNumber, pageSize), version: _version).Result;
        }

        public int LastControlRepeat(int certificateId)
        {
            _httpCLient.SetRoute(_route);
            return Task.Run(async () => await this._httpCLient.Get(string.Format("certificateLastControl/{0}", certificateId), version: _version)).Result;
        }

        public int LastId()
        {
            _httpCLient.SetRoute(_route);
            return Task.Run(async () => await this._httpCLient.Get("lastid")).Result;
        }

        public void SendRequest(RequestCertificateModel controlFormSend)
        {
            _httpCLient.SetRoute(_route);
            _httpCLient.Post(controlFormSend, "request");
        }

        public void SubmitCertificate(CertificateModel certificate)
        {
            _httpCLient.SetRoute(_route);
            _httpCLient.Post(certificate);
        }

        public int UnCompleteCount()
        {
            _httpCLient.SetRoute(_route);
            int x = Task.Run(async () => await _httpCLient.Get("uncompleteCertificatesCount", version: _version)).Result;
            return x;
        }

        List<CertificateControlModel> IV1Certificate.GetQeueControls(int qeueId)
        {
            _httpCLient.SetRoute(_route);
            var x = Task.Run(async () => await _httpCLient.Get<List<CertificateControlModel>>(string.Format("unsubmitted/controls/{0}", qeueId), version: _version)).Result;
            return x;
        }

        PagedList<RequestCertificateModel> IV2Certificate.GetUnsubmittedForms(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}
