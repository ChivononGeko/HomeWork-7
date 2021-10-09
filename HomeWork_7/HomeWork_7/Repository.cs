using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork_7
{
    class Repository
    {
        /// <summary>
        /// Массив для хранения данных о записях
        /// </summary>
        private Field[] fields;
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;
        /// <summary>
        /// Переменная, аоказывающая количество записей
        /// </summary>
        int index;
        /// <summary>
        /// Массив для заголовок
        /// </summary>
        string[] titles;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Path"></param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[5];
            this.fields = new Field[2];
        }
        /// <summary>
        /// Метод для расширения массива
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.fields, this.fields.Length * 2);
            }
        }
        /// <summary>
        /// Метод, для добавления записей в массив
        /// </summary>
        /// <param name="field">Запись</param>
        public void Add(Field field)
        {
            this.Resize(index >= this.fields.Length);
            this.fields[index] = field;
            this.index++;
        }
        /// <summary>
        /// Поиск индекса записи по полю
        /// </summary>
        /// <param name="label"></param>
        public bool Remove(string label)
        {
            bool flag = false;
            for (int i = 0; i < this.index; i++)
            {
                if (this.fields[i].FirstName.Trim() == label)
                {
                    RemByIndex(i--);
                    flag = true;
                }

                else if (this.fields[i].LastName.Trim() == label)
                {
                    RemByIndex(i--);
                    flag = true;
                }

                else if (this.fields[i].Record.Trim() == label)
                {
                    RemByIndex(i--);
                    flag = true;
                }
                else if (int.TryParse(label, out int result)  && this.fields[i].Age == result)
                {
                    RemByIndex(i--);
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Удаления записи
        /// </summary>
        /// <param name="RemoveIndex">Индекс записи для удаления</param>
        public void RemByIndex(int RemoveIndex)
        {
            Field[] newfields = new Field[this.fields.Length - 1];
            index--;
            for (int i = 0; i < RemoveIndex; i++)
            {
                newfields[i] = this.fields[i];
            }
            for (int i = RemoveIndex; i < index; i++)
            {
                newfields[i] = this.fields[i + 1];
            }
            this.fields = newfields;
        }
        /// <summary>
        /// Редактирвоание
        /// </summary>
        /// <param name="label">Значение, по которому надо редактировать запись</param>
        public bool Edit(string label, Field field)
        {
            bool flag = false;
            for (int i = 0; i < this.index; i++)
            {
                if (this.fields[i].FirstName.Trim() == label)
                {
                    this.fields[i--] = field;
                    flag = true;
                }

                else if (this.fields[i].LastName.Trim() == label)
                {
                    this.fields[i--] = field;
                    flag = true;
                }

                else if (this.fields[i].Record.Trim() == label)
                {
                    this.fields[i--] = field;
                    flag = true;
                }
                else if (int.TryParse(label, out int result)  && this.fields[i].Age == result)
                {
                    this.fields[i--] = field;
                    flag = true;
                }
            }
            return flag;
        }
        public void Sort(string select)
        {
            Field temp;
            bool flag = true;

            switch (select)
            {
                case "1":
                    while (flag)
                    {
                        flag = false;
                        for (int i = 0; i < this.index - 1; ++i)
                            if (this.fields[i].FirstName.CompareTo(this.fields[i + 1].FirstName) > 0)
                            {
                                temp = this.fields[i];
                                this.fields[i] = this.fields[i + 1];
                                this.fields[i + 1] = temp;
                                flag = true;
                            }
                    }
                    break;
                case "2":
                    while (flag)
                    {
                        flag = false;
                        for (int i = 0; i < this.index - 1; ++i)
                            if (this.fields[i].LastName.CompareTo(this.fields[i + 1].LastName) > 0)
                            {
                                temp = this.fields[i];
                                this.fields[i] = this.fields[i + 1];
                                this.fields[i + 1] = temp;
                                flag = true;
                            }
                    }

                    break;
                case "3":
                    for (int i = 0; i < this.index - 1; i++)
                    {
                        for (int j = i + 1; j < this.index; j++)
                        {
                            if (this.fields[i].Age > this.fields[j].Age)
                            {
                                temp = this.fields[i];
                                this.fields[i] = this.fields[j];
                                this.fields[j] = temp;
                            }
                        };
                    }
                    break;
                default:
                    Console.WriteLine("Такой команды нет...");
                    break;

            }
        }
        /// <summary>
        /// Вывод по диапозону дат
        /// </summary>
        /// <param name="a">1я дата</param>
        /// <param name="b">2я дата</param>
        public void PrintSort(DateTime a,DateTime b)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (this.fields[i].Date >= a && this.fields[i].Date<=b)
                {
                    Console.WriteLine(fields[i].Print());
                }
            }       

        }
        /// <summary>
        /// Печать в консоль
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{this.titles[0],10}|{this.titles[1],10}|{this.titles[2],8}|{this.titles[3],8}|{this.titles[4],17}");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.fields[i].Print());
            }
        }
        /// <summary>
        /// Загрузка из файла
        /// </summary>
        public void Load()
        {
            using(StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split('|');
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('|');
                    Add(new Field(args[0], args[1], int.Parse(args[2]), args[3]));
                }
            }
        }
        /// <summary>
        /// Загрузка в файл
        /// </summary>
        public void UnLoad()
        {
            using (StreamWriter sw = new StreamWriter(this.path))
            {
                sw.WriteLine($"{this.titles[0],10}|{this.titles[1],10}|{this.titles[2],8}|{this.titles[3],8}|{this.titles[4],17}");
                for (int i = 0; i < this.index; i++)
                { 
                    sw.WriteLine(this.fields[i].Print());
                }              
            }
        }
    }
}
