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
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, SubjectResponse>
    {
        private readonly IRepoSubject subjRepo;
        private readonly IMapper _mapper;

        public UpdateSubjectHandler(IRepoSubject SubjRepo, IMapper mapper)
        {
            subjRepo = SubjRepo;
            _mapper = mapper;
        }
        public Task<SubjectResponse> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            SubjectResponse response = null;
            Subject subject = subjRepo.GetById(request.ID);
            subject.Title = request.Title;
            subject.Description = request.Description;
            subject.Decision = request.Decision;
            response = _mapper.Map<SubjectResponse>(subjRepo.Update(subject));
            return Task.FromResult(response);
        }
    }
}
