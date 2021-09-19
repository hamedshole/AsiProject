using Asi.Client.Util.Interfaces;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using IV1Form = Asi.Client.V1.Interfaces.IForm;
using IV2Form = Asi.Client.V2.Interfaces.IForm;


namespace Asi.Client.Repositories
{
    internal class FormRepository : IV1Form, IV2Form
    {
        private readonly ICustomHttpClient _httpCLient;
        private readonly string _route;
        private readonly int _version;

        public FormRepository(ICustomHttpClient httpCLient, string route, int version = 1)
        {
            _version = version;
            _httpCLient = httpCLient;
            _route = route;
        }

        public List<FormDataModel> GetMobileForm(int formid)
        {
            _httpCLient.SetRoute(_route);
            return Task.Run(async () => await _httpCLient.Get<List<FormDataModel>>(string.Format("mobile/{0}", formid),version:_version)).Result;
        }

        public  List<FormTemplateModel> GetFormTemplate(int formid)
        {
            _httpCLient.SetRoute(_route);
            return Task.Run(async () => await _httpCLient.Get<List<FormTemplateModel>>(string.Format("form/{0}", formid), version: _version)).Result;

        }
    }
}
