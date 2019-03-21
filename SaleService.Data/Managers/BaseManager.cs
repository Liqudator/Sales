using Microsoft.EntityFrameworkCore;
using Midway.Common.Data.Exceptions;
using Sales.Managers;
using System.Linq;
using System.Collections.Generic;

namespace Sales.Data.Managers
{
    /// <summary>
    /// Базовый класс менеджера данных.
    /// </summary>
    /// <typeparam name="TDbContext">Контекст БД.</typeparam>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public abstract class BaseManager<TDbContext, TEntity> : IGenericManager<TEntity>
        where TDbContext: DbContext
        where TEntity: class
    {
        /// <summary>
        /// Контекст БД.
        /// </summary>
        public TDbContext Context { get; set; }

        /// <summary>
        /// Создать сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Созданная сущность.</returns>
        public TEntity Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return entity; 
        }

        /// <summary>
        /// Удалить сущность из БД.
        /// </summary>
        /// <param name="id">ИД сущности.</param>
        public void Delete(int id)
        {
            var entityToDelete = Get(id);

            if (entityToDelete != null)
            {
                Context.Set<TEntity>().Remove(entityToDelete);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Получить сущность из БД по его ИД.
        /// </summary>
        /// <param name="id">ИД сущности.</param>
        /// <returns>Найденная сущность.</returns>
        public TEntity Get(int id)
        {
            var result = Context.Set<TEntity>().Find(id);

            if(result == null)
            {
                throw new DataNotFoundException($"Нет записи с ИД: {id}.");
            }

            return result;
        }

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Изменить сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <param name="id">ИД сущности.</param>
        /// <returns>Измененная сущность.</returns>
        public TEntity Update(TEntity entity, int id)
        {
            var result = Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
            return result.Entity;
        }
    }
}
