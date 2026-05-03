using AutoMapper;
using KairoApi.Db.UnitOfWork;
using MediatR;

namespace KairoApi.Business.Task.Command
{
    public class DeleteTaskCommand  : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        public readonly IKairoApiUnitOfWork _uow;
        public readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IKairoApiUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var data = await _uow.TaskRepository.GetByIdAsync(request.Id) ?? throw new Exception("Data not found");
            await _uow.TaskRepository.RemoveByIdAsync(data.id);
        }
    }
}