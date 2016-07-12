using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance
{
    interface IPart
    {
        bool isBuilt { set; get; }          // Проверка завершенности строительства элемента
        int requiredTime { get; }           // Количество итераций для завершения элемента
        int buildingStatus { get; set; }    // Степень готовности элемента
    }
}
