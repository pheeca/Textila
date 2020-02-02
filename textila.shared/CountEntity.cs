using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textila.Shared
{
    public class CountEntity
    {
        public int CountId { get; set; }
        public int CountName { get; set; }
        public int SingleDouble { get; set; }
        public int Blend { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string BlendName { get; set; }

    }
}
