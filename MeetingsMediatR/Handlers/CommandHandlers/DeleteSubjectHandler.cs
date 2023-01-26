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
    public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectCommand, SubjectResponse>
    {
        private readonly IRepoSubject subjRepo;
        private readonly IMapper _mapper;

        public DeleteSubjectHandler(IRepoSubject SubjRepo, IMapper mapper)
        {
            subjRepo = SubjRepo;
            _mapper = mapper;
        }
        public Task<SubjectResponse> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject subject = subjRepo.Remove(subjRepo.getByRefNumber(request.refnum));
            SubjectResponse response = _mapper.Map<SubjectResponse>(subject);
            return Task.FromResult(response);
        }
    }
}
