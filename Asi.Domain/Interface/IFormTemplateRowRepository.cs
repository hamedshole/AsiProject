using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormTemplateRowRepository
    {
        Task<FormTemplateRow> AddAsync(FormTemplateGroup group, FormTemplateRow formTemplateRow);
    }
}