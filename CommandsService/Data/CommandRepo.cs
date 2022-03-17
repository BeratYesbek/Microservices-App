using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _appDbContext;
        public CommandRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            command.PlatformId = platformId;
            _appDbContext.Commands.Add(command);
            
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _appDbContext.Platforms.Add(plat);
        }

        public bool ExternalPlatformExits(int externalPlatformId)
        {
            return _appDbContext.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _appDbContext.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _appDbContext.Commands
            .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _appDbContext.Commands.Where(c => c.PlatformId == platformId)
            .OrderBy(c => c.platform.Name);
        }

        public bool PlaformExits(int platformId)
        {
            return _appDbContext.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }
    }
}