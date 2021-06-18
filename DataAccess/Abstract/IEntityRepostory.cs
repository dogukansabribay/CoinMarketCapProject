using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public  interface IEntityRepostory<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Bu yapı sayesinde kategori adına göre getir ,ürünün adına göre getir gibi ayrı ayrı metodlar yazmama gerek kalmayacak. Filter = null filtre vermeyede bilirsin demek zorunlu değil
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> filter); // for exp: bankacılık sisteminde bir şeyin detayına gitmek istersek neyin detayına gitmek istiyorsak basıp onun detayına gitmek için kullandığımız yapı.Tek bir kredinin detayına, Veya hesaplarım liste olarak geliyor ben o hesaba tıklayıp o hesabın detayına gidiyorum.
        T GetById(int id);
        void Add(T entity);
        void Add(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> filter);
    }
}
