using System;

namespace Sales.Domain
{
    /// <summary>
    /// Модель заказа.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание заказа.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Сумма заказа.
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// Дата-время заказа.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Идентификатор покупателя.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Идентификатор продавца.
        /// </summary>
        public int SellerId { get; set; }
    }
}
