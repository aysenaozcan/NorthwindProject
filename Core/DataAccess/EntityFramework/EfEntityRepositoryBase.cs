using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>

        //Programcıyı yönlendiren, "TEntity" için yazılmış kurallar;
        //Bu bir referans tipi olacak ve veritabanı tablosu olacak, IEntity yazılmasın diye de new() yazarız çünkü IEntity newlenemez.
        //TContext, bir DbContext inherit alan bir class olmalıdır.
        where TEntity : class, IEntity, new()    
        where TContext : DbContext, new()   
    {
        //Veritabanındakı tablolar ile entity katmanımdakı classları ılıskılendırmem gerekıyoır. 
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            //using içine yazdığımız nesneler usingdeki gorevini tamamlayınca anında garbage colllector sayesınde bellekten atılır.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirmek için yazdık.
                addedEntity.State = EntityState.Added; //eklenecek bir nesne olduğunu ifade eder.
                context.SaveChanges();  //Ekleme işlemini yapar.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //ternary operatörü
                return filter == null
                    ? context.Set<TEntity>().ToList()  //null ise bu çalışır bu demek ki; db setteki producta yerleş ve oradaki tüm datayı liste çevir. 
                    : context.Set<TEntity>().Where(filter).ToList();// null değilse bu çalışor. Yani verileri filtreleyıp vermesını i stıyoruz.


            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
