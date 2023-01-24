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
    public class DeleteEntityHandler : IRequestHandler<DeleteEntityCommand, EntityResponse>
    {
        private readonly IRepoEntity entRepo;
        private readonly IMapper _mapper;

        public DeleteEntityHandler(IRepoEntity EntRepo, IMapper mapper)
        {
            entRepo = EntRepo;
            _mapper = mapper;
        }
        public Task<EntityResponse> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
        {
            Entity entity = entRepo.Remove(entRepo.GetById(request.id));
            EntityResponse response = _mapper.Map<EntityResponse>(entity);
            return Task.FromResult(response);
        }
    }
}
