namespace Sales.Domain
{
    /// <summary>
    /// Модель покупателя.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Идентификатор покупателя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия покупателя.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Имя покупателя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество покупателя.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Город проживания.
        /// </summary>
        public string City { get; set; }
    }
}
