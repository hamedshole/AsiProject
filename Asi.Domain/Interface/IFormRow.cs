using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormRow
    {
        Task AddFormDataRow(FormDataGroup formDataGroup, FormDataRow formDataRow);
        Task AddFormTemplateRow(FormTemplateGroup formTemplateGroup, FormTemplateRow formTemplateRow);
        Task AddFormTemplateFormMissMatchRows(FormTemplateRow formTemplateGroup, string missmatchword);
    }
}
