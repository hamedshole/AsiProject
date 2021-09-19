using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormTemplateGroupRepository
    {
        Task<FormTemplateGroup> AddAsync(FormTemplate form, FormTemplateGroup formTemplateGroup);
    }
}