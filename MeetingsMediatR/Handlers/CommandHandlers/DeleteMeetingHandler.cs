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
    public class DeleteMeetingHandler : IRequestHandler<DeleteMeetingCommand, MeetingResponse>
    {
        private readonly IRepoMeeting meetRepo;
        private readonly IMapper _mapper;

        public DeleteMeetingHandler(IRepoMeeting meetRepo, IMapper mapper)
        {
            this.meetRepo = meetRepo;
            _mapper = mapper;
        }
        public Task<MeetingResponse> Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
