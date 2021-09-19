using System.Threading.Tasks;

namespace Asi.Client.Util.Interfaces
{
    public interface ICustomHttpClient
    {
        Task Delete(int id, string uri=null,int version=1);
        Task<Tout> Get<Tout>(string uri = null, int version = 1) where Tout : class, new();
        Task<int> Get(string uri = null, int version = 1);
        Task<TOut> Post<TIn, TOut>(TIn model, string uri = null, int version = 1) where TOut : new();
        Task Post<TIn>(TIn model, string uri = null, int version = 1);
        Task Put<TIn>(TIn model, string uri = null, int version = 1);
        void SetRoute(string route);
    }
}
