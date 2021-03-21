using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStreetMapLib
{
    /* todo: 
     * Классы для абстрактной бибилотеки
     * DataGetter (подключается к узлу MapSite; загружает данные MapData в виде строки, признак данных - DataType)
     * Deserialiser (получает данные от Connector, десериализует последовательность координат в тип "Коллекция")
     * Recipient (отправляет данные, представленные коллекцией в основную программу)
     * 
     * Классы для основной программы
     * LibraryLoader - загрузчик библиотек
     * 
     */

    public class Main_OSM
    {
        public void GetMap()
        {
            // тестовая 
            Console.WriteLine("It's work!");
        }
    }
}
