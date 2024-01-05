using Layer.Architecture.Domain.Entities;
using System.Collections.Generic;

namespace Layer.Architecture.Infra.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        IList<TEntity> Select();

        TEntity Select(int id);
    }
}
