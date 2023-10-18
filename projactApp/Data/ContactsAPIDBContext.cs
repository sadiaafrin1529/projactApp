using Microsoft.EntityFrameworkCore;

namespace projactApp.Data
{
    public class ContactsAPIDBContext :DbContext
    {
        public ContactsAPIDBContext (DbContextOptions options) :base(options)
        {

        }
    }
    
}
