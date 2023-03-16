using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TypeRepository : ITypeRepository
    {
        public List<BusinessObject.DataAccess.Type> GetAllTypes() => TypeManagement.Instance.GetAll();

        public BusinessObject.DataAccess.Type GetType(string Id) => TypeManagement.Instance.GetTypebyId(Id);
    }
}
