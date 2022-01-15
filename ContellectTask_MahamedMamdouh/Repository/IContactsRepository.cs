using ContellectTask_MahamedMamdouh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContellectTask_MahamedMamdouh.Repository
{
    public interface IContactsRepository
    {
        List<Contacts> List();
        ContactModel List(int currentPage);
        Contacts Find(int id);
        Boolean Add(Contacts entity);
        Boolean Update(Contacts entity);
        Boolean Delete(int id);
        ContactModel Search(Contacts entity);

    }
}
