using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocceVoloCounter
{
    class Player
    {
        string firstName;
        string lastName;
        string bocceClub;

        public Player(string firstName, string lastName, string bocceClub)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.bocceClub = bocceClub;
        }
    }
}
