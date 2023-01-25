using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingsMediatR.Commands.Delete;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers.CommandHandlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, EmployeeResponse>
    {
        private readonly IRepoEmployee empRepo;
        private readonly IMapper _mapper;

        public DeleteEmployeeHandler(IRepoEmployee EmpRepo, IMapper mapper)
        {
            empRepo = EmpRepo;
            _mapper = mapper;
        }
        public Task<EmployeeResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = empRepo.Remove(empRepo.GetBySsn(request.ssn));
            EmployeeResponse response = _mapper.Map<EmployeeResponse>(employee);
            return Task.FromResult(response);
        }
    }
}
