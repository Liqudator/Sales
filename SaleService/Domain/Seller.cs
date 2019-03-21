namespace Sales.Domain
{
    /// <summary>
    /// Модель продавца.
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Идентификатор продавца.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия продавца.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Имя продавца.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество продавца.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Город проживания.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Размер комиссии в процентах.
        /// </summary>
        public double Comission { get; set; }
    }
}
