using Asi.Client.Util.Interfaces;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IV1CertificateControl = Asi.Client.V1.Interfaces.ICertificateControl;
using IV2CertificateControl = Asi.Client.V2.Interfaces.ICertificateControl;


namespace Asi.Client.Repositories
{
    internal class CertificateControlRepository : IV1CertificateControl,IV2CertificateControl
    {
        private readonly ICustomHttpClient _httpClient;
        private readonly string _route;
        private readonly int _version;

        public CertificateControlRepository(ICustomHttpClient httpClient, string route,int version=1)
        {
            this._version=version;
            _httpClient = httpClient;
            _route = route;
        }

        public void Add(CertificateControlModel payments)
        {
            _httpClient.SetRoute(_route);
            _httpClient.Post(payments, version: _version);
        }

        public void Delete(int paymentsId)
        {
            _httpClient.SetRoute(_route);
            _httpClient.Delete(paymentsId, version: _version);
        }

        public List<CertificateControlModel> GetAll(int certId)
        {
            _httpClient.SetRoute(_route);
            return Task.Run(async () => await _httpClient.Get<List<CertificateControlModel>>(certId.ToString(), version: _version)).Result;

        }

    }
}
