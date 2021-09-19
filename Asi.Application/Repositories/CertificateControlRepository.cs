using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICertificateControl = Asi.Application.Interface.ICertificateControl;


namespace Asi.Application.Repositories
{
    internal class CertificateControlRepository : ICertificateControl
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public CertificateControlRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }

        public async Task Add(CertificateControlModel payments)
        {
            CertificateControl certificateControl = _mapper.Map<CertificateControl>(payments);
            await _dbBusinessUnit.Controls.UpdateAsync(certificateControl);
        }

        public async Task Delete(int paymentsId)
        {
            await _dbBusinessUnit.Controls.DeleteAsync(paymentsId);
        }

        public async Task<List<CertificateControlModel>> GetAll(int certId)
        {
            List<CertificateControl> certificateControls = await _dbBusinessUnit.Controls.ListAsync(x => x.CertificateId == certId);
            return _mapper.Map<List<CertificateControlModel>>(certificateControls);
        }

    }
}
