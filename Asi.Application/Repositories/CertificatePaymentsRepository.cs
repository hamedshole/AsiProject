using Asi.Application.Interface;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Asi.Application.Repositories
{
    internal class CertificatePaymentsRepository : ICertificatePayment
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public CertificatePaymentsRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }

        public async Task Add(PaymentModel payments)
        {
            Payment payment = _mapper.Map<Payment>(payments);
            await _dbBusinessUnit.Payments.CreateAsync(payment);
        }

        public async Task Delete(int paymentsId)
        {
            await _dbBusinessUnit.Payments.DeleteAsync(paymentsId);
        }

        public async Task<List<PaymentModel>> GetAll(int certId)
        {
            List<Payment> payments = await _dbBusinessUnit.Payments.ListAsync(x => x.CertificateId == certId && x.IsDeleted == false);
            return _mapper.Map<List<PaymentModel>>(payments);
        }


    }
}
