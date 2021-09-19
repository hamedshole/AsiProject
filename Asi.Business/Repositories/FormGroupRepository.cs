using Asi.Domain.Entities;
using Asi.Domain.Interface;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class FormGroupRepository : IFormGroup
    {
        private readonly IAsiDbContext _context;

        public FormGroupRepository(IAsiDbContext context)
        {
            _context = context;
        }

        public async Task AddFormDataGroup(SavedFormData savedFormData, FormDataGroup formDataGroup)
        {
            formDataGroup.SavedFormData = savedFormData;
            await _context.DataGroups.AddAsync(formDataGroup);
        }

        public async Task AddFormTemplateAnswerColumn(FormTemplate formTemplate, FormTemplateAnswerColumn formTemplateAnswerColumn)
        {
            await _context.AnswerColumns.AddAsync(formTemplateAnswerColumn);
        }

        public async Task AddFormTemplateAnswerColumn(FormTemplateGroup formTemplateGroup, string answerColumn)
        {
            await _context.AnswerColumns.AddAsync(new FormTemplateAnswerColumn { Group = formTemplateGroup, Title = answerColumn });
        }

        public async Task AddFormTemplateGroup(FormTemplate formTemplate, FormTemplateGroup formTemplateGroup)
        {
            formTemplateGroup.Form = formTemplate;
            await _context.FormTemplateGroups.AddAsync(formTemplateGroup);
        }



        public async Task AddFormTemplateQuestionHeader(FormTemplateGroup formTemplateGroup, string questionHeader)
        {
            await _context.QuestionHeaders.AddAsync(new FormTemplateQuestionHeader { Group = formTemplateGroup, Title = questionHeader });
        }
    }
}
