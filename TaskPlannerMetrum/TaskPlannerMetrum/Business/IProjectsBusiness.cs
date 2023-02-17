using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Business
{
    public interface IProjectsBusiness
    {
        Projects Create(Projects projects);
        //UserVO FindByID(long id);
        dynamic FindAll();
        dynamic FindPlannerManager();
       // dynamic FindAllProjects();

        
    }
}
