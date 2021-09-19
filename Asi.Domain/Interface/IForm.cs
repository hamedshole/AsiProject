using Asi.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IForm
    {
        Task<List<FormTemplate>> GetFormTemplate(int formid);
        Task<List<FormTemplate>> GetMobileForm(int formid);
        Task<FormTemplate> AddFormTemplate(FormTemplate formTemplate);
        Task<SavedFormData> AddFormData(SavedFormData savedFormData);
        Task<CertificateControl> GetFormData(int id);
        Stream GetPdf(int formid);
    }
}
