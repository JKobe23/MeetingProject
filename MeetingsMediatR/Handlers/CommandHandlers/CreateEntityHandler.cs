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
    public class CreateEntityHandler : IRequestHandler<CreateEntityCommand, EntityResponse>
    {
        private readonly IRepoEntity entRepo;
        private readonly IMapper _mapper;

        public CreateEntityHandler(IRepoEntity EntRepo, IMapper mapper)
        {
            entRepo = EntRepo;
            _mapper = mapper;
        }
        public Task<EntityResponse> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            EntityResponse response = new EntityResponse
            {
                Name = request.name,
                Location= request.location
            };
           
            Entity entity = _mapper.Map<Entity>(response);
            entRepo.Add(entity);
            response = _mapper.Map<EntityResponse>(entity);
            return Task.FromResult(response);
        }
    }
}
