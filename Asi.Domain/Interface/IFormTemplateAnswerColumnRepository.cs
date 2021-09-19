using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormTemplateAnswerColumnRepository
    {
        Task AddAsync(FormTemplateAnswerColumn formTemplateAnswerColumn);
    }
}