using System.Collections.Generic;
using System.Linq;
using TaskPlannerMetrum.Data.Converter.Contract;
using TaskPlannerMetrum.Data.VO;
using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Data.Converter.PersonConverter
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                DepartmentId= origin.DepartmentId,
                PermissionId= origin.PermissionId,
                PhoneNumber= origin.PhoneNumber,

            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                DepartmentId = origin.DepartmentId,
                PermissionId = origin.PermissionId,
                PhoneNumber = origin.PhoneNumber,
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {

            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
