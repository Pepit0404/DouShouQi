using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {

        bool Manger(PieceType meurtrier, PieceType victime);
        bool PouvoirBouger(Case caseActu, Case caseAdja);

    }

    public class regleOrigin : IRegles
    {

        public bool Manger(PieceType meurtrier, PieceType victime)

        {
            if (meurtrier == PieceType.souris && victime == PieceType.elephant)
            {
                return true;
            }
            if (meurtrier == PieceType.elephant && victime == PieceType.souris)
            {
                return false;
            }
            if ((int)meurtrier >= (int)victime)
            {
                return true;
            }
            return false;
        }
        public bool PouvoirBouger(Case caseActu, Case caseAdja)
        {
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }
            if (!caseAdja.Onthis.HasValue)
            {
                if (caseActu.Onthis.Value.Type != PieceType.souris && caseAdja.Type == CaseType.Eau)
                {
                    return false;
                }
            }
            else
            {
                if (!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type) || (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre))
                {
                    return false;
                }


            }
            return true;
        }


    }

    public class regleVariente : IRegles
    {
        public bool Manger(PieceType meurtrier, PieceType victime)
        {
            if (meurtrier == PieceType.souris && victime == PieceType.elephant)
            {
                return true;
            }
            if ((int)meurtrier >= (int)victime)
            {
                return true;
            }
            return false;
        }
        public bool PouvoirBouger(Case caseActu, Case caseAdja)
        {
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }
            if (!caseAdja.Onthis.HasValue)
            {
                if ((caseActu.Onthis.Value.Type != PieceType.souris && caseActu.Onthis.Value.Type != PieceType.chien) && caseAdja.Type == CaseType.Eau)
                {
                    return false;
                }

            }
            else
            {
                if ((caseActu.Onthis.Value.Type != PieceType.souris && caseActu.Onthis.Value.Type != PieceType.chien) && caseAdja.Type == CaseType.Eau)
                {
                    return false;
                }
                if (!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type) || (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre))
                {
                    return false;
                }

            }
            return true;
        }
    }
}

  
