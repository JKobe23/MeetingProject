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
    public class CreatePositionHandler : IRequestHandler<CreatePositionCommand, PositionResponse>
    {
        private readonly IRepoPosition posRepo;
        private readonly IMapper _mapper;

        public CreatePositionHandler(IRepoPosition PosRepo, IMapper mapper)
        {
            posRepo = PosRepo;
            _mapper = mapper;
        }
        public Task<PositionResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            PositionResponse response = new PositionResponse
            {
                Title = request.title,
                Level = request.level,
            };

            Position position = _mapper.Map<Position>(response);
            posRepo.Add(position);
            response = _mapper.Map<PositionResponse>(position);
            return Task.FromResult(response);
        }
    }
}
