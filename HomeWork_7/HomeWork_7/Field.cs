using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_7
{
    class Field
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Запись
        /// </summary>
        public string Record { get; set; }
        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Конструктор, позволяющий присвоить значение соответствующим полям работника
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        public Field(string FirstName, string LastName, int Age, string Record)
        {
            this.FirstName = FirstName; 
            this.LastName = LastName;   
            this.Age = Age;
            this.Record = Record;
            this.Date = DateTime.Now;       
        }

        /// <summary>
        /// Организация вывода информации
        /// </summary>
        /// <returns>Строковое представление информации</returns>
        public string Print()
        {
            return $"{FirstName,10}|{LastName,10}|{Age,8}|{Record,8}|{Date,17}";
        }
    }
}
