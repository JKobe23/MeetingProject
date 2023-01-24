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
    public class DeletePositionHandler : IRequestHandler<DeletePositionCommand, PositionResponse>
    {
        private readonly IRepoPosition posRepo;
        private readonly IMapper _mapper;

        public DeletePositionHandler(IRepoPosition PosRepo, IMapper mapper)
        {
            posRepo = PosRepo;
            _mapper = mapper;
        }
        public Task<PositionResponse> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            Position position = posRepo.Remove(posRepo.GetById(request.id));
            PositionResponse response = _mapper.Map<PositionResponse>(position);
            return Task.FromResult(response);
        }
    }
}
