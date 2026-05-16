using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolCLI_V2
{
    public class Hos
    {
        public string Name { get;private set; }
        public string Title { get;private set; }
        public string Category { get;private set; }
        public string Blurb { get;private set; }
        public double HP { get;private set; }
        public double HPPerLevel { get;private set; }

        public Hos(string sor)
        {             
            string[] temp = sor.Split(';');
            Name = temp[0];
            Title = temp[1];
            Category = temp[2];
            Blurb = temp[3];
            HP = double.Parse(temp[4]);
            HPPerLevel = double.Parse(temp[5]);
        }

        public double HpErtek(int szint)
        {
            if (szint < 1 || szint > 18)
            {
                return -1;
            }

            return HP + (szint - 1) * HPPerLevel;
        }
    }
}
