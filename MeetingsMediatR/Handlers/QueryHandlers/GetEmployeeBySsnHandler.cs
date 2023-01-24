using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers.QueryHandlers
{
    public class GetEmployeeBySsnHandler : IRequestHandler<GetEmployeeBySsnQuery, EmployeeResponse>
    {
        private readonly IRepoEmployee empRepo;
        private readonly IMapper _mapper;

        public GetEmployeeBySsnHandler(IRepoEmployee EmpRepo, IMapper mapper)
        {
            empRepo = EmpRepo;
            _mapper = mapper;
        }
        public Task<EmployeeResponse> Handle(GetEmployeeBySsnQuery request, CancellationToken cancellationToken)
        {
            EmployeeResponse response = _mapper.Map<EmployeeResponse>(empRepo.GetBySsn(request.ssn));
            return Task.FromResult(response);
        }
    }
}
