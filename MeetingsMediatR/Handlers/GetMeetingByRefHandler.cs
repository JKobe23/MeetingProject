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

namespace MeetingsMediatR.Handlers
{
    public class GetMeetingByRefHandler : IRequestHandler<GetMeetingByRefQuery, MeetingResponse>
    {
        private readonly IRepoMeeting meetingRepo;
        private readonly IMapper _mapper;

        public GetMeetingByRefHandler(IRepoMeeting meetingRepo, IMapper mapper)
        {
            this.meetingRepo = meetingRepo;
            _mapper = mapper;
        }
        public Task<MeetingResponse> Handle(GetMeetingByRefQuery request, CancellationToken cancellationToken)
        {
            MeetingResponse response = _mapper.Map<MeetingResponse>(meetingRepo.getByRefNumber(request.refNum));
            return Task.FromResult(response);
        }
    }
}
