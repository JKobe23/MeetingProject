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
    public class CreateSubjectHandler : IRequestHandler<CreateSubjectCommand, SubjectResponse>
    {
        private readonly IRepoSubject subjRepo;
        private readonly IMapper _mapper;

        public CreateSubjectHandler(IRepoSubject SubjRepo, IMapper mapper)
        {
            subjRepo = SubjRepo;
            _mapper = mapper;
        }
        public Task<SubjectResponse> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            SubjectResponse response = new SubjectResponse
            {
                RefNumber= request.RefNumber,
                Title= request.Title,
                Description= request.Description,
                Decision= request.Decision,
            };
            if (subjRepo.getByRefNumber(request.RefNumber) != null)
            {
                response = null;
            }
            Subject subject = _mapper.Map<Subject>(response);
            try
            {
                subjRepo.Add(subject);
                response = _mapper.Map<SubjectResponse>(subject);
            } catch(Exception ex)
            {
                response = null;
            }
            return Task.FromResult(response);
        }
    }
}
