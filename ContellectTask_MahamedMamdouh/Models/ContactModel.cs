using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContellectTask_MahamedMamdouh.Models
{
    public class ContactModel
    {

        public List<Contacts> LContacts { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }

    }
}
