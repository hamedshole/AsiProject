using Asi.Domain.Entities;
using Asi.Domain.Interface;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class FormRowRepository : IFormRow
    {
        private readonly IAsiDbContext _context;

        public FormRowRepository(IAsiDbContext context)
        {
            _context = context;
        }

        public async Task AddFormDataRow(FormDataGroup formDataGroup, FormDataRow formDataRow)
        {
            formDataRow.Group = formDataGroup;
            await _context.FormDataRows.AddAsync(formDataRow);
        }

        public async Task AddFormTemplateFormMissMatchRows(FormTemplateRow formTemplateGroup, string missmatchword)
        {
            await _context.TemplateRowMissMatchWords.AddAsync(new FormTemplateRowMissMatchWord { Row = formTemplateGroup, Text = missmatchword });
        }

        public async Task AddFormTemplateRow(FormTemplateGroup formTemplateGroup, FormTemplateRow formTemplateRow)
        {
            formTemplateRow.TemplateGroup = formTemplateGroup;
            await _context.FormTemplateRows.AddAsync(formTemplateRow);
        }
    }
}
