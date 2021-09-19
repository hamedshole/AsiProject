using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using IForm = Asi.Application.Interface.IForm;



namespace Asi.Application.Repositories
{
    internal class FormRepository : IForm
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public FormRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }


        public async Task<List<FormTemplateModel>> GetItemForms(int formid)
        {
            List<FormTemplate> formTemplate = await _dbBusinessUnit.Forms.GetFormTemplate(formid);
            return _mapper.Map<List<FormTemplateModel>>(formTemplate);
        }

        public async Task<List<FormDataModel>> GetMobileForm(int formid)
        {
            List<FormTemplate> formTemplate = await _dbBusinessUnit.Forms.GetFormTemplate(formid);
            return _mapper.Map<List<FormDataModel>>(formTemplate);
        }
    }
}
