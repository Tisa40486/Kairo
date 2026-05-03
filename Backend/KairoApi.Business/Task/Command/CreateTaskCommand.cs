using AutoMapper;
using KairoApi.Db.UnitOfWork;
using KairoApi.Dto;
using KairoApi.Model;
using MediatR;

namespace KairoApi.Business.Task.Command
{
    public class CreateTaskCommand : TaskInput, IRequest
    {
    }
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
    {
        public readonly IKairoApiUnitOfWork _uow;
        public readonly IMapper _mapper;
        public CreateTaskCommandHandler(IKairoApiUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
       
        public async System.Threading.Tasks.Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            if (request.Id is null)
            {
                var data = _mapper.Map<TaskDao>(request);

                await _uow.TaskRepository.AddAndSaveAsync(data);
            }
            else
            {
                var data = await _uow.TaskRepository.GetByIdAsync(request.Id.Value) ?? throw new Exception("Id not found");

                _mapper.Map<TaskInput, TaskDao>(request, data);

                await _uow.TaskRepository.UpdateAsync(data);
            }
        }
    }
}