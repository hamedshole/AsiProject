using Asi.Model;

namespace Asi.Mobile.LocalData.Interface
{
    public interface ILocalData
    {
       
        IRepository<CompanyModel> Companies { get; }
        IRepository<LinkModel> Links { get; }
        IRepository<ItemModel> Items { get; }
        IRepository<CertificateModel> Certificates{ get; }

    }
}
