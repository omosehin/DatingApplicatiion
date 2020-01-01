using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApplication.Models
{
    public class Like
    {
        /*
            By making LikerId and LikeeId ,is impossible for a user to 
            like another more than once
         */
        public int LikerId { get; set; } //a user that likes another user
        public int LikeeId { get; set; } // a user being liked by another user
        public User Liker { get; set; }
        public User Likee { get; set; }
    }
}
