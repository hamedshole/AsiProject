using Asi.Mobile.LocalData.Interface;
using Asi.Model;

namespace Asi.Mobile.LocalData
{
    internal class LocalData : ILocalData
    {
        private  IRepository<CompanyModel> _companies;
        private  IRepository<LinkModel> _links;
        private  IRepository<ItemModel> _items;
        private  IRepository<CertificateModel> _certificates;

        public LocalData()
        {
        }

        public IRepository<CompanyModel> Companies => _companies ?? (_companies = new Repository<CompanyModel>("companies"));

        public IRepository<LinkModel> Links => _links ?? (_links = new Repository<LinkModel>("links"));

        public IRepository<ItemModel> Items => _items ?? (_items = new Repository<ItemModel>("items"));

        public IRepository<CertificateModel> Certificates => _certificates ?? (_certificates = new Repository<CertificateModel>("certificates"));
    }
}
