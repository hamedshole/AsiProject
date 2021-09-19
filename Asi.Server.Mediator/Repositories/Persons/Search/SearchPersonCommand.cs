using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Persons.Search
{
    public class SearchPersonCommand:IRequest<List<PersonModel>>
    {
        public string Title { get; private set; }

        public SearchPersonCommand(string title)
        {
            Title = title;
        }
    }
}
