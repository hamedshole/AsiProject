using Asi.Domain.Entities;
using Asi.Domain.Interface;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class TemplateRowMissMatchWordsRepository : IItemplateRowMissMatchWordsRepository
    {
        private readonly IAsiDbContext _context;

        public TemplateRowMissMatchWordsRepository(IAsiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FormTemplateRowMissMatchWord formTemplateRowMissMatch)
        {
            await _context.TemplateRowMissMatchWords.AddAsync(formTemplateRowMissMatch);
            // await _context.SaveChangesAsync();
        }
    }
}
