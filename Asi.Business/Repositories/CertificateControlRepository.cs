using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class CertificateControlRepository : IControl
    {

        private readonly IAsiDbContext _dbcontext;

        public CertificateControlRepository(IAsiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        async Task IRepository<CertificateControl>.CreateAsync(CertificateControl entity)
        {
            await _dbcontext.CertificateControls.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        async Task IRepository<CertificateControl>.DeleteAsync(int id)
        {
            CertificateControl certificateControlDto = await _dbcontext.CertificateControls.FindAsync(id);
            certificateControlDto.Delete();
            _dbcontext.Entry(certificateControlDto).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        async Task<CertificateControl> IRepository<CertificateControl>.GetAsync(Expression<Func<CertificateControl, bool>> expression)
        {
            CertificateControl certificateControlDto = await _dbcontext.CertificateControls.
                Include(x => x.Agancy).
                Include(x => x.MainController).
                Include(x => x.TechnicalManager).
                Include(x => x.Marketing).
                Include(x => x.CertificateController).
                Include(x => x.BranchPerson).
                Include(x => x.ControlForm)
                            .ThenInclude(x => x.Groups).
                            ThenInclude(x => x.Template).
                            ThenInclude(x => x.AnswerColumns).
                Include(x => x.Agancy).
                Include(x => x.BranchPerson).
                Include(x => x.ControlForm)
                            .ThenInclude(x => x.Groups).
                            ThenInclude(x => x.Template).
                            ThenInclude(x => x.QuestionHeaders).
                            FirstOrDefaultAsync();
            return certificateControlDto;
            ;
        }

        PagedList<CertificateControl> IRepository<CertificateControl>.PagedList(PaginationFilter pagination, Expression<Func<CertificateControl, bool>> expression)
        {
            throw new NotImplementedException();
        }

        async Task<List<CertificateControl>> IRepository<CertificateControl>.ListAsync(Expression<Func<CertificateControl, bool>> expression)
        {
            List<CertificateControl> certificateControlDto = await _dbcontext.CertificateControls.
                Include(x => x.Agancy).
                Include(x => x.MainController).
                Include(x => x.TechnicalManager).
                Include(x => x.Marketing).
                Include(x => x.CertificateController).
                Include(x => x.BranchPerson).
                Include(x => x.ControlForm)
                            .ThenInclude(x => x.Groups).
                            ThenInclude(x => x.Template).
                            ThenInclude(x => x.AnswerColumns).
                Include(x => x.Agancy).
                Include(x => x.BranchPerson).
                Include(x => x.ControlForm)
                            .ThenInclude(x => x.Groups).
                            ThenInclude(x => x.Template).
                            ThenInclude(x => x.QuestionHeaders).Where(expression).
                            ToListAsync();
            return certificateControlDto;
        }


        Task IRepository<CertificateControl>.UpdateAsync(CertificateControl entity)
        {
            throw new NotImplementedException();
        }

    }
}
