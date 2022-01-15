using ContellectTask_MahamedMamdouh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContellectTask_MahamedMamdouh.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactDBContext db;

        public ContactsRepository(ContactDBContext _db){ db = _db;}

        public Boolean Add(Contacts entity)
        {
          
            try
            {
                db.Contacts.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Boolean Delete(int id)
        {
       
            try
            {
                db.Contacts.Remove(Find(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Contacts Find(int id) => db.Contacts.SingleOrDefault(x => x.ContactId == id);
      

        public List<Contacts> List()=> db.Contacts.ToList();

        public ContactModel List(int currentPage)
        {
            int maxRows = 5;
            ContactModel ContactModel = new ContactModel();

            ContactModel.LContacts = db.Contacts.Skip((currentPage - 1) * maxRows).Take(maxRows).ToList();

            ContactModel.PageCount = (int)Math.Ceiling((double)((decimal)this.db.Contacts.Count() / Convert.ToDecimal(maxRows)));
            ContactModel.CurrentPageIndex = currentPage;

            return ContactModel;
        }

        public ContactModel Search(Contacts entity)
        {
            ContactModel ContactModel = new ContactModel();

            ContactModel.LContacts = db.Contacts.Where(x => (!String.IsNullOrEmpty(entity.Name) ?(x.Name.Contains(entity.Name)) : true)).Where(y =>(!String.IsNullOrEmpty(entity.Address)) ?(y.Address.Contains(entity.Address)) : true)
                .Where(y => (!String.IsNullOrEmpty(entity.Notes)) ? (y.Address.Contains(entity.Notes)) : true).ToList();

           

            return ContactModel;
        }

        public Boolean Update(Contacts entity)
        {
            try
            {
                db.Contacts.Update(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
