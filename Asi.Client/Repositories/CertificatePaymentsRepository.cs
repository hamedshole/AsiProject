using Asi.Client.Util.Interfaces;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IV1CertificatePayment = Asi.Client.V1.Interfaces.ICertificatePayment;
using IV2CertificatePayment = Asi.Client.V2.Interfaces.ICertificatePayment;


namespace Asi.Client.Repositories
{
    internal class CertificatePaymentsRepository : IV1CertificatePayment, IV2CertificatePayment
    {
        private readonly ICustomHttpClient _httpClient;
        private readonly string _route;
        private readonly int _version;

        public CertificatePaymentsRepository(ICustomHttpClient httpClient, string route,int version=1)
        {
            this._version = version;
            _httpClient = httpClient;
            _route = route;
        }

        public void Add(PaymentModel payments)
        {
            _httpClient.SetRoute(_route);
            _httpClient.Post(payments,version:_version);
        }

        public void Delete(int paymentsId)
        {
            _httpClient.SetRoute(_route);
            _httpClient.Delete(paymentsId, version: _version);
        }

        public List<PaymentModel> GetAll(int certId)
        {
            _httpClient.SetRoute(_route);
            return Task.Run(async () => await _httpClient.Get<List<PaymentModel>>(certId.ToString(), version: _version)).Result;
        }

       
    }
}
