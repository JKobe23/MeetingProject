using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers.CommandHandlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IRepoEmployee empRepo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IRepoEmployee EmpRepo, IMapper mapper)
        {
            empRepo = EmpRepo;
            _mapper = mapper;
        }
        public Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            
            EmployeeResponse response = new EmployeeResponse
            {
                SSN = request.SSN,
                Name= request.Name,
                PositionID= request.PositionID,
                EntityID= request.EntityID,
                
            };
            if (empRepo.GetBySsn(request.SSN) != null)
            {
                response = null;
            }
            Employee employee = _mapper.Map<Employee>(response);

            try
            {
                empRepo.Add(employee);

                response = _mapper.Map<EmployeeResponse>(employee);
                
            } catch(Exception ex)
            {
                response = null;
            }
            return Task.FromResult(response);
        }
    }
}
