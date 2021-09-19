using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IItemplateRowMissMatchWordsRepository
    {
        Task AddAsync(FormTemplateRowMissMatchWord formTemplateRowMissMatch);
    }
}