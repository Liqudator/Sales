using System.Collections.Generic;

namespace Sales.Managers
{
    /// <summary>
    /// Интерфейс менеджера сущности для работы с БД.
    /// </summary>
    public interface IGenericManager<TEntity>
    {
        /// <summary>
        /// Создать в БД новую сущность.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Созданная сущность.</returns>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Получить запись по его ИД.
        /// </summary>
        /// <param name="id">ИД записи.</param>
        /// <returns>Полученная сущность.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Получить все сущности из БД.
        /// </summary>
        /// <returns>Все сущности.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Изменить в БД информацию о сущности.
        /// </summary>
        /// <param name="entity">Экземпляр сущности.</param>
        /// <param name="id">ИД сущности.</param>
        /// <returns>Измененная сущность.</returns>
        TEntity Update(TEntity entity, int id);

        /// <summary>
        /// Удалить из БД сущность по его ИД.
        /// </summary>
        /// <param name="id">ИД удаляемой сущности.</param>
        void Delete(int id);
    }
}
