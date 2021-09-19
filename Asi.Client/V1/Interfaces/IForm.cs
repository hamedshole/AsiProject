using Asi.Model;
using System.Collections.Generic;

namespace Asi.Client.V1.Interfaces
{
    public interface IForm
    {
        List<FormDataModel> GetMobileForm(int formid);
    }
}
