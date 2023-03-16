using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ITypeRepository
    {
        List<BusinessObject.DataAccess.Type> GetAllTypes();
        BusinessObject.DataAccess.Type GetType(string Id);
    }
}
