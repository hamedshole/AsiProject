﻿using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.SearchPaged
{
    public class SearchPagedDepartmentCommandHandler : IRequestHandler<SearchPagedPersonCommand, PagedList<PersonModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedDepartmentCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<PersonModel>> Handle(SearchPagedPersonCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Persons.Search(new PersonModel { Fullname = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
