using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface IForm
    {
        Task<List<FormTemplateModel>> GetItemForms(int formid);
        Task<List<FormDataModel>> GetMobileForm(int formid);
    }
}
