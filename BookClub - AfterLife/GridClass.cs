using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub___AfterLife
{
    internal class GridClassBook
    {
        public GridClassBook(int count, string bname, string bauthor, string bpic)
        {
            this.count = count;
            this.bname = bname;
            this.bauthor = bauthor;
            this.bpic = bpic;
        }
        public int count { get; set; }
        public string bname { get; set; }
        public string bauthor { get; set; }
        public string bpic { get; set; }
    }
}
