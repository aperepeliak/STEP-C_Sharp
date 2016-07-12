using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class Worker : IWorker
    {
        public void Work(House obj)
        {
            IPart workSection = FindWhatToDo(obj);
            if (workSection == null)
            {
                obj.houseIsBuilt = true;
                Console.WriteLine("Has nothing to do");
            }
            else
            {
                DoYourWork(workSection);
                Console.WriteLine("Working the whole day");
            }
        }

        private IPart FindWhatToDo(House obj)
        {
            for (int i = 0; i < obj.parts.Count; i++)
            {
                if (obj.parts[i].isBuilt == false)
                    return obj.parts[i];
            }
            return null;
        }

        private void DoYourWork(IPart section)
        {
            section.buildingStatus++;
            if (section.buildingStatus == section.requiredTime)
            {
                section.isBuilt = true;
            }
        }
    }
}
