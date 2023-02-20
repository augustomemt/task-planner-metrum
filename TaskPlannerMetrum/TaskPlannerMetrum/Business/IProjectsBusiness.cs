using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.DTO;

namespace TaskPlannerMetrum.Business
{
    public interface IProjectsBusiness
    {
        bool Create(ProjectDTO projects);
        //UserVO FindByID(long id);
        dynamic FindAll();
        dynamic FindPlannerManager();
       // dynamic FindAllProjects();

        
    }
}
