using System.Collections.Generic;
using TaskPlannerMetrum.Data.VO;

namespace TaskPlannerMetrum.Business
{
    public interface IUserBusiness
    {
        UserVO Create(UserVO person);
        UserVO FindByID(long id);
        List<UserVO> FindAll();
        UserVO Update(UserVO person);
        void Delete(long id);
    }
}
