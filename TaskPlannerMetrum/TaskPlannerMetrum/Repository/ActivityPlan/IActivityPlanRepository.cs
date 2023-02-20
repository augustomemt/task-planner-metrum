using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Repository.ActivityPlan
{
    public interface IActivityPlanRepository
    {
        public dynamic GetExecutorPlan(string projectId);

        public bool Create(TaskPlannerMetrum.Model.ActivityPlan activityPlan);
    }
}
