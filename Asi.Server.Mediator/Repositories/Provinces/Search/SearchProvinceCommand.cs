using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Provinces.Search
{
    public class SearchProvinceCommand:IRequest<List<ProvinceModel>>
    {
        public string Title { get; private set; }

        public SearchProvinceCommand(string title)
        {
            Title = title;
        }
    }
}
