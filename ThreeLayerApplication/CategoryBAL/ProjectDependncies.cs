using CategoryDAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;


namespace CategoryBAL
{
    public class ProjectDependncies
    {
        public static void RegisterService(ref UnityContainer container)
        {
            container.RegisterType<ProductDbContext, ProductDbContext>();
            container.RegisterType<ICategoryBL, CategoryBL>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();

        }
    }
}
