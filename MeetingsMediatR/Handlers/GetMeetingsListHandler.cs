using AutoMapper;
using MediatR;
using MeetingCore;
using MeetingInfrastructure;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMediatR.Handlers
{
    public class GetMeetingsListHandler : IRequestHandler<GetMeetingsListQuery, IEnumerable<MeetingResponse>>
    {
        private readonly IRepoMeeting meetingRepo;
        private readonly IMapper _mapper;

        public GetMeetingsListHandler(IRepoMeeting meetingRepo, IMapper mapper)
        {
            this.meetingRepo = meetingRepo;
            _mapper = mapper;
        }
        public Task<IEnumerable<MeetingResponse>> Handle(GetMeetingsListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<MeetingResponse> response = _mapper.Map<IEnumerable<MeetingResponse>>(meetingRepo.listAllMeetings());
            return Task.FromResult(response);
        }
    }
}
