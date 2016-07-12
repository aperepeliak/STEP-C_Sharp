using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class Team
    {
        public List<IWorker> workers;

        public Team()
        {
            workers = new List<IWorker>();
            workers.Add(new Worker());
            workers.Add(new Worker());
            workers.Add(new Worker());
            workers.Add(new Worker());
            workers.Add(new TeamLeader());
        }

        public Team(int numWorkers, int numTeamLeads)
        {
            workers = new List<IWorker>();
            for (int i = 0; i < numWorkers; i++)
            {
                workers.Add(new Worker());
            }
            for (int i = 0; i < numTeamLeads; i++)
            {
                workers.Add(new TeamLeader());
            }
        }
    }
}
