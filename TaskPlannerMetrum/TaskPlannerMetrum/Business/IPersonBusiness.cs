using System.Collections.Generic;
using TaskPlannerMetrum.Data.VO;

namespace TaskPlannerMetrum.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
