using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21cardtrick
{
    class Player
    {
        private bool hasSelectedCard = false;
        public Player()
        {

        }


        public int indicateColumn(int column1, int column2, int column3)
        {
            int choice = 0;
            //string choice = "";
            if (column1 == 1)
            {
                choice = 1;
                //choice = "1 was selected";
            }
            if (column2 == 1)
            {
                choice = 2;
                //choice = "2 was selected";
            }
            if (column3 == 1)
            {
                choice = 3;
                //choice = "3 was selected";
            }
            return choice;
        }

        public bool pickCard()
        {

            hasSelectedCard = true;
            return hasSelectedCard;
        }
    }
}
