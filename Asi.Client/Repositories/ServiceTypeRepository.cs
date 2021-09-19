using Asi.Client.Util.Interfaces;
using Asi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IV1ServiceType = Asi.Client.V1.Interfaces.IServiceType;
using IV2ServiceType = Asi.Client.V2.Interfaces.IServiceType;


namespace Asi.Client.Repositories
{
    internal class ServiceTypeRepository : Repository<ServiceTypeModel>, IV1ServiceType,IV2ServiceType
    {
        private readonly int _apiVersion;
        public ServiceTypeRepository(ICustomHttpClient httpClient, string route,int version) : base(httpClient, route,version)
        {
            this._apiVersion = version;
        }

        public async Task<List<ServiceTypeModel>> GetDepartmnetServiceTypes(int departmentid)
        {
            try
            {
                _httpClient.SetRoute(_route);
                return await _httpClient.Get<List<ServiceTypeModel>>(string.Format("department/{0}", departmentid), version: _apiVersion);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
