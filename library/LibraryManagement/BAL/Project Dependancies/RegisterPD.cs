using AutoMapper;
using DAL.DataEntity;
using DAL.DBContextEntity;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BAL.Project_Dependancies
{
    public class RegisterPD
    {
       public static void RegisterDependancy(ref UnityContainer container)
        {
            
            container.RegisterType<LibraryDBContext>();
            container.RegisterType<IRepository,BookRepository>();
            container.RegisterType<ICategoryBookRepo,CategoryBookRepo>();
            //container.RegisterType<IRepository<Book>, BookRepository<Book>>();
            //container.RegisterType<ICategoryBookRepo<CategoryBook>, CategoryBookRepo<CategoryBook>>();
            container.RegisterType<IBookBAL, BookBAL>();
            container.RegisterType<ICategoryBookBAL, CategoryBookBAL>();
          //  container.RegisterType<IMapper,Mapper>();
            
        }
    }
}
