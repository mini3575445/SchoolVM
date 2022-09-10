using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Match.Models;

namespace Match.ViewModels
{
    public class VMFriend
    {
        public List<Friend> match { get; set; } 
        public List<Friend> wait { get; set; }
        public List<Friend> invite { get; set; }
        public List<Member> waitMember { get; set; }

    }
}