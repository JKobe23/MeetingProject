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
    public class GetEntityByIdHandler : IRequestHandler<GetEntityByIdQuery, EntityResponse>
    {

        private readonly IMapper _mapper;
        private readonly IRepoEntity entRepo;

        public GetEntityByIdHandler(IMapper mapper, IRepoEntity EntRepo)
        {
            _mapper = mapper;
            entRepo = EntRepo;
        }
        public Task<EntityResponse> Handle(GetEntityByIdQuery request, CancellationToken cancellationToken)
        {
            EntityResponse response = _mapper.Map<EntityResponse>(entRepo.GetById(request.id));
            return Task.FromResult(response);
        }
    }
}
