using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System;
using System.Threading.Tasks;
using IReport = Asi.Application.Interface.IReport;


namespace Asi.Application.Repositories
{
    internal class ReportRepository : IReport
    {
        private readonly IDbBusinessUnit _dbBusinessUint;
        private readonly IMapper _mapper;

        public ReportRepository(IDbBusinessUnit dbBusinessUint, IMapper mapper)
        {
            _dbBusinessUint = dbBusinessUint;
            _mapper = mapper;
        }

        public ControlFormReportModel CertificateControlReport(int controlId)
        {
            throw new NotImplementedException();
        }

        public async Task<ControlFormReportModel> CertificateMainReport(int certificateId)
        {
            Certificate certificate = await _dbBusinessUint.Report.GetCertificateReport(certificateId);
            ControlFormReportModel controlFormReportModel = _mapper.Map<ControlFormReportModel>(certificate);
        //    System.IO.File.WriteAllText(@"E:\reportmodel.txt", JsonConvert.SerializeObject(controlFormReportModel));
            return controlFormReportModel;
            //ReportDesigner reportDesigner = new ReportDesigner();
            //  return reportDesigner.GenerateControlReport(controlFormReportModel);
        }

        public async Task<MissMatchReportModel> CertificateMissMatchReport(int certificateId)
        {
            Certificate certificate = await _dbBusinessUint.Report.GetCertificateMissMatchReport(certificateId);
            MissMatchReportModel controlFormReportModel = _mapper.Map<MissMatchReportModel>(certificate);
           // System.IO.File.WriteAllText(@"E:\reportmodel.txt", JsonConvert.SerializeObject(controlFormReportModel));
            return controlFormReportModel;
            // ReportDesigner reportDesigner = new ReportDesigner();
            // return reportDesigner.GenerateControlReport(controlFormReportModel);
        }

        Task<ControlFormReportModel> IReport.CertificateControlReport(int controlId)
        {
            throw new NotImplementedException();
        }
    }
}
