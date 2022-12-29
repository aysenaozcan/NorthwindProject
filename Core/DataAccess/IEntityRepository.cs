using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess  //*** Core katmanı diğer katmanları referans almaz.
{
    public interface IEntityRepository<T> where T : class, IEntity, new() // where T : class,IEntity -->> generic constraint: generic kısıtlama, sadece class referans tipine sahip nesneler T değeri olarak yazılabılır. IEntity yazdığı içinde IEntity olabılır veyta IEntity yi implemente eden nesneler olabılır. I entity bir interface olduğu newlenemez fakat onu implemente eden classları newleyeceğiz. Sistemin veri tabanı nesnelerıyle calışan bır repository olması için yaptık bunları.

    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //Expression verebılmek için yanı lınq ile olusturulan fıltrelerı koyabılmek için gerekli syntax. Bu yapı kategoriye göre getir veya ürünün fiyatına göre getir gibi ayrı ayrı metotlar yazmaktan kurtaracak. Filter=null illa filtrelemek zorunda değilsinm demek istiyor yani bazı durumlarda tu data da getırılebılır.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);


    }
}
