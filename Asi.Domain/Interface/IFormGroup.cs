using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IFormGroup
    {
        Task AddFormTemplateGroup(FormTemplate formTemplate, FormTemplateGroup formTemplateGroup);
        Task AddFormDataGroup(SavedFormData savedFormData, FormDataGroup formDataGroup);
        Task AddFormTemplateQuestionHeader(FormTemplateGroup formTemplateGroup, string questionHeader);
        Task AddFormTemplateAnswerColumn(FormTemplateGroup formTemplateGroup, string answerColumn);
    }
}
