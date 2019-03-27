using FluentScheduler;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Logs.Domain;
using Sales.Services;

namespace Sales.WebApi.Background
{
    /// <summary>
    /// Класс для регистрации фоновых задач по расписанию.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class JobRegistry : Registry, IInitializable
    {
        public ILogger logger { get; set; }
        public IOrderService OrderService { get; set; }

        public void Init()
        {
            PrepareJob();
            JobManager.Initialize(this);
        }

        private void PrepareJob()
        {
            Schedule(() =>
            {
                logger.Info("Удаление записи старше 1 года");
                OrderService.DeleteOrderOlderOneYear();
                logger.Info("Запись старше 1 года удален");
                OrderService.DeleteOrderHistoryOlderOneYear();
            }).ToRunEvery(10).Seconds();

            logger.Info("Регистрация и запуск задачи на ежедневное удаление заказов старше 1 года.");
        }
    }
}
