using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        //Generate constructor:Ben CategoryManager olarak veri erişim katmanına (dal) bağımlıyım ama biraz zayıf bir bağımlılığım var çünkü ben Interface  (referans) üzerinden bağımlıyım. Kurallara uyduğu sürece dal katmanında istediğn gibi takılabılırsın.
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {   //iş kodlarını buraya yazarız.
            return _categoryDal.GetAll();   
        }

        //Select*from Categories where CategoryId= hangi idyse
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId==categoryId);
        }
    }
}
