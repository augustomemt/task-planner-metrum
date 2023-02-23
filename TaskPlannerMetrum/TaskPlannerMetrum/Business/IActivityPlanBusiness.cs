using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Business
{
    public interface IActivityPlanBusiness
    {
        public dynamic GetExecutorPlan(string projectId);

        public bool Create(ActivityPlan activityPlan);

        public dynamic TasksByProject(string projectId);
    }
}
