using AutoMapper;
using KairoApi.Db.UnitOfWork;
using KairoApi.Dto;
using MediatR;

namespace KairoApi.Business.Task.Query
{
    public class GetTaskByIdQuery : IRequest<TaskReponse>
    {
        public int Id { get; set; }

    }
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskReponse?>
    {
        readonly IKairoApiUnitOfWork _uow;
        readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(
            IKairoApiUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TaskReponse?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.TaskRepository.GetByIdAsync(request.Id);
            var status = await _uow.StatusRepository.GetByIdAsync(data.StatusDaoId.Value);

            if (data == null)
                return null;

            var result = _mapper.Map<TaskReponse>(data);
            var resultStatus = _mapper.Map<StatusResponse>(status);
            result.Status = resultStatus;

            return result;
        }

    }
}