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
    public class GetPositionByIdHandler : IRequestHandler<GetPositionByIdQuery, PositionResponse>
    {
        private readonly IRepoPosition positionRepo;
        private readonly IMapper _mapper;
        public GetPositionByIdHandler(IRepoPosition PositionRepo, IMapper mapper)
        {
            positionRepo= PositionRepo;
            _mapper= mapper;
        }
        public Task<PositionResponse> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            PositionResponse response = _mapper.Map<PositionResponse>(positionRepo.GetById(request.id));
            return Task.FromResult(response);
        }
    }
}
