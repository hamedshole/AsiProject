using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormTemplateRepository
    {
        Task<FormTemplate> Add(FormTemplate formTemplate);
        Task<FormTemplate> Get(int formId);
    }
}