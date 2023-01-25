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
    public class UpdateEntityHandler : IRequestHandler<UpdateEntityCommand, EntityResponse>
    {
        private readonly IRepoEntity entRepo;
        private readonly IMapper _mapper;

        public UpdateEntityHandler(IRepoEntity EntRepo, IMapper mapper)
        {
            entRepo = EntRepo;
            _mapper = mapper;
        }
        public Task<EntityResponse> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
        {
            EntityResponse response = null;
            Entity entity = _mapper.Map<Entity>(request);

            entity = entRepo.Update(entity);

            response = _mapper.Map<EntityResponse>(entity);

            return Task.FromResult(response);
        }
    }
}
