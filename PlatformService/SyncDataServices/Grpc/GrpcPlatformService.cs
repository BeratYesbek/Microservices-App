using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using PlatformService.Data;

namespace PlatformService.SyncDataServices.Grpc
{
    public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;
        public GrpcPlatformService(IPlatformRepo repo,IMapper mapper)
        {
         _mapper = mapper;
         _repo = repo;   
        }

        public override Task<PlatformResponse> GetAllPlatforms(GetAllRequest request,ServerCallContext  context)
        {
            var response = new PlatformResponse();
            var platforms = _repo.GetAllPlatforms();

            foreach(var plat in platforms)
            {
                response.Platform.Add(_mapper.Map<GrpcPlatformModel>(plat));
            }

            return Task.FromResult(response);
        }

    }
}