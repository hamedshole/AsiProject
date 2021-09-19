using Asi.Model;
using System.Collections.Generic;

namespace Asi.Client.V2.Interfaces
{
    public interface IForm
    {
        List<FormDataModel> GetMobileForm(int itemId);
        List<FormTemplateModel> GetFormTemplate(int formid);
    }
}
