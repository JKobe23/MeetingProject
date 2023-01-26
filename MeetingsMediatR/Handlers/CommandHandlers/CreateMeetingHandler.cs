using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers.CommandHandlers
{
    public class CreateMeetingHandler : IRequestHandler<CreateMeetingCommand, MeetingResponse>
    {
        private readonly IRepoMeeting meetRepo;
        private readonly IMapper _mapper;

        public CreateMeetingHandler(IRepoMeeting MeetRepo, IMapper mapper)
        {
            meetRepo = MeetRepo;
            _mapper = mapper;
        }
        public Task<MeetingResponse> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
          
            MeetingResponse response = null;
            

            if(meetRepo.getByRefNumber(request.RefNumber) == null)
            {
                try
                {
                    Meeting meeting = _mapper.Map<Meeting>(request);

                    meeting.Employees = meetRepo.retreiveEmployees(request.EmployeeIDs);
                    meeting.Subjects = meetRepo.retreiveSubjects(request.SubjectIDs);
                    meetRepo.Add(meeting);

                    response = _mapper.Map<MeetingResponse>(meeting);

                }
                catch (Exception ex)
                {
                    response = null;
                }
            }
            
            return Task.FromResult(response);
        }
    }
}
