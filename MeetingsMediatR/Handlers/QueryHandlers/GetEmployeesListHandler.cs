using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingInfrastructure;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers.QueryHandlers
{
    public class GetEmployeesListHandler : IRequestHandler<GetEmployeesListQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IRepoEmployee empRepo;
        private readonly IMapper _mapper;

        public GetEmployeesListHandler(IRepoEmployee EmpRepo, IMapper mapper)
        {
            empRepo = EmpRepo;
            _mapper = mapper;
        }
        public Task<IEnumerable<EmployeeResponse>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<EmployeeResponse> response = _mapper.Map<IEnumerable<EmployeeResponse>>(empRepo.listAllEmployees());
            return Task.FromResult(response);
        }
    }
}
