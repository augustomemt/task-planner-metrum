using System.Collections.Generic;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.ModelViews;

namespace TaskPlannerMetrum.Repository.ActivityPlan
{
    public interface IActivityPlanRepository
    {
        public dynamic GetExecutorPlan(string projectId);

        public bool Create(TaskPlannerMetrum.Model.ActivityPlan activityPlan);

        public List<vActivityPlan> FindAllTaskByProject(string projectId);
    }
}
