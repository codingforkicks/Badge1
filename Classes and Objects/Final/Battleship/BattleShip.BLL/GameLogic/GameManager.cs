using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//starts game logic
namespace BattleShip.BLL.GameLogic
{
    public class GameManager
    {
        private int _whoStarts;

        private void DetermineWhoStarts()
        {
            Random num = new Random();
            _whoStarts = num.Next(1, 2);
        }

        public void Start()
        {
            DetermineWhoStarts();
        }

        public void Start(int num)
        {
            _whoStarts = num;
        }
    }
}
