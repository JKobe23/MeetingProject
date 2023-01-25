using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingsMediatR.Commands.Update;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers.CommandHandlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IRepoEmployee empRepo;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IRepoEmployee EmpRepo, IMapper mapper)
        {
            empRepo = EmpRepo;
            _mapper = mapper;
        }
        public Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeResponse response = null;
            Employee employee = empRepo.GetById(request.ID);
            employee.EntityID = request.EntityID;
            employee.PositionID = request.PositionID;
            employee.Name = request.Name;
            response = _mapper.Map<EmployeeResponse>(empRepo.Update(employee));
            return Task.FromResult(response);
        }
    }
}
