using System.Linq;
using TaskPlannerMetrum.Repository.ActiviesScope;

namespace TaskPlannerMetrum.Business.Implementations
{
    public class ActivesScopeBusinessImplementation : IActiviesScopeBusiness
    {
        private readonly IActiviesRepository _activiesRepository;

        public ActivesScopeBusinessImplementation(IActiviesRepository activiesRepository)
        {
            _activiesRepository = activiesRepository;
        }
        public dynamic GetActivesScopeByProject(string projectId)
        {
           return _activiesRepository.GetActiviesScopeByProject(projectId).Select(a => new { a.ID, a.Description});
        }
    }
}
