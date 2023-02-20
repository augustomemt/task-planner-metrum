using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Repository.ActiviesScope;
using TaskPlannerMetrum.Repository.ActivityPlan;
using TaskPlannerMetrum.Repository.Generic;

namespace TaskPlannerMetrum.Business.Implementations
{
    public class ActivityPlanBusiness : IActivityPlanBusiness
    {
        private readonly IActivityPlanRepository _activiesRepository;

        public ActivityPlanBusiness(IRepository<Clients> repository, IActivityPlanRepository activiesRepository)
        {
            _activiesRepository= activiesRepository;
        }

        public bool Create(ActivityPlan activityPlan)
        {
            activityPlan.Status = '5';
            activityPlan.PlannerTeamID = 48;
            activityPlan.WorkspaceID = 1;

            return _activiesRepository.Create(activityPlan);

              
        }

        public dynamic GetExecutorPlan(string projectId)
        {
            return _activiesRepository.GetExecutorPlan(projectId);
        }
    }
}
