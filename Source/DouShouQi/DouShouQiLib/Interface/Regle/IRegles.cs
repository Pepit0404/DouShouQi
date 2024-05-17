using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DouShouQiLib
{
    public interface IRegles
    {

        void initPlateau(Game game);
        bool Manger(PieceType meurtrier, PieceType victime);
        bool PouvoirBouger(Case caseActu, Case caseAdja, Plateau plateau);

        List<Case> CoupPossible(Case caseActu, Game game);

        bool EstFini(Game game);
    }
}

  
