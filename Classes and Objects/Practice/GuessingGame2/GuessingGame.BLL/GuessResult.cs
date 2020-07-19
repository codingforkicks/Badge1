using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.BLL
{
    //guess statuses
    public enum GuessResult
    {
        Invalid,
        Lower,
        Higher,
        Victory
    }
}
