using Asi.Client.Util.Interfaces;
using Asi.Model;
using System;
using System.Threading.Tasks;
using IV1Report = Asi.Client.V1.Interfaces.IReport;
using IV2Report = Asi.Client.V2.Interfaces.IReport;


namespace Asi.Client.Repositories
{
    internal class ReportRepository : IV1Report,IV2Report
    {
        private readonly ICustomHttpClient _httpClient;
        private readonly string _route;

        public ReportRepository(ICustomHttpClient httpClient,string route)
        {
            _httpClient = httpClient;
            _route = route;
        }

        public ControlFormReportModel CertificateControlReport(int controlId)
        {
            throw new NotImplementedException();
        }

        public ControlFormReportModel CertificateMainReport(int certificateId)
        {
            _httpClient.SetRoute(_route);
            ControlFormReportModel controlFormReport = Task.Run(async () => await _httpClient.Get<ControlFormReportModel>(string.Format("certificatereport/{0}", certificateId.ToString()))).Result;
            return controlFormReport;
        }

        public MissMatchReportModel CertificateMissMatchReport(int certificateId)
        {
            _httpClient.SetRoute(_route);
            MissMatchReportModel missMatchReportModel = Task.Run(async () => await _httpClient.Get<MissMatchReportModel>(string.Format("missmatch/{0}", certificateId.ToString()))).Result;
            return missMatchReportModel;
        }


    }
}
