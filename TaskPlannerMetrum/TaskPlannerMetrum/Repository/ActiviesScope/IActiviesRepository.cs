using System.Collections.Generic;
using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Repository.ActiviesScope
{
    public interface IActiviesRepository
    {
        public List<ActiviesScopeList> GetActiviesScopeByProject(string ProectID);
    }
}
