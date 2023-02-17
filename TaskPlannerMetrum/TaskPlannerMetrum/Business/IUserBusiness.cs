using System.Collections.Generic;
using TaskPlannerMetrum.Data.VO;

namespace TaskPlannerMetrum.Business
{
    public interface IUserBusiness
    {
        UserVO Create(UserVO person);
        UserVO FindByID(int id);
        List<UserVO> FindAll();
        UserVO Update(UserVO person);
        void Delete(int id);
        
    }
}
