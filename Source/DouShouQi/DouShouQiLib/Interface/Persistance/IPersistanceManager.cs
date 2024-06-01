using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IPersistanceManager
    {
        void SaveData(Joueur joueur1);
        void LoadData();
    }
}
