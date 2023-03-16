using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TypeManagement
    {
        private static TypeManagement instance = null;
        private static readonly object instanceLock = new object();
        private TypeManagement() { }
        public static TypeManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TypeManagement();
                    }
                }
                return instance;
            }
        }

        public List<BusinessObject.DataAccess.Type> GetAll()
        {
            List<BusinessObject.DataAccess.Type> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Types.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public BusinessObject.DataAccess.Type GetTypebyId(string id)
        {
            BusinessObject.DataAccess.Type obj = null;

            try
            {
                var c = new Hotel_ManagementsContext();
                obj = c.Types.SingleOrDefault(c => c.TypeId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
    }
}
