using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_4._2_events
{
    class Cloud
    {
        public int counter = 0;
        public void ScaredBug()
        {
            //BugsGoHome();
            counter = 3;
        }

        public List<Bug> bugs;
        public void CreateBug()
        {
            bugs.Add(new Bug(this));
        }

        public void MoveBugs()
        {
            for (int i = 0; i < bugs.Count; i++)
            {
                bugs[i].Move();
            }
            Console.WriteLine("Жуки шевелятся");
        }
        private void BugsGoHome()
        {
            for (int i = 0; i < bugs.Count; i++)
            {
                bugs[i].GoHome();
            }
            Console.WriteLine("Жуки в страхе бегут домой");
        }
        public void Show()
        {
            for (int i = 0; i < bugs.Count; i++)
            {
                Console.WriteLine("Жук № {0} x = {1}; y = {2}", i, bugs[i].x, bugs[i].y);
            }
        }

        public void NextStep ()
        {
            if (counter !=0)
            {
                BugsGoHome();
                counter--;
            }
            else
            {
                MoveBugs();
            }
        }

        public Cloud ()
        {
            bugs = new List<Bug>();
        }

    }
}
