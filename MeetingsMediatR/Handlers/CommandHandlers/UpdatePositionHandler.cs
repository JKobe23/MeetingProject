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
    public class UpdatePositionHandler : IRequestHandler<UpdatePositionCommand, PositionResponse>
    {
        private readonly IRepoPosition posRepo;
        private readonly IMapper _mapper;

        public UpdatePositionHandler(IRepoPosition PosRepo, IMapper mapper)
        {
            posRepo = PosRepo;
            _mapper = mapper;
        }
        public Task<PositionResponse> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            PositionResponse response = null;
            Position position = _mapper.Map<Position>(request);
            position = posRepo.Update(position);
            response = _mapper.Map<PositionResponse>(position);

            return Task.FromResult(response);
        }
    }
}
