using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormTemplateQuestionHeaderRepository
    {
        Task AddAsync(FormTemplateQuestionHeader formTemplateQuestionHeader);
    }
}