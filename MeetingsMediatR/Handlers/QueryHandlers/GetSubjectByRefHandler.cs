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
    public class GetSubjectByRefHandler : IRequestHandler<GetSubjectByRefQuery, SubjectResponse>
    {

        private readonly IMapper _mapper;
        private readonly IRepoSubject subjRepo;

        public GetSubjectByRefHandler(IMapper mapper, IRepoSubject SubjRepo)
        {
            _mapper = mapper;
            subjRepo = SubjRepo;
        }
        public Task<SubjectResponse> Handle(GetSubjectByRefQuery request, CancellationToken cancellationToken)
        {
            SubjectResponse response = _mapper.Map<SubjectResponse>(subjRepo.getByRefNumber(request.refnum));
            return Task.FromResult(response);
        }
    }
}
