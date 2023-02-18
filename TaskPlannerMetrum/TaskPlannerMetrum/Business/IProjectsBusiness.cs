using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.DTO;

namespace TaskPlannerMetrum.Business
{
    public interface IProjectsBusiness
    {
        Projects Create(ProjectDTO projects);
        //UserVO FindByID(long id);
        dynamic FindAll();
        dynamic FindPlannerManager();
       // dynamic FindAllProjects();

        
    }
}
