using ProductDesktop.Database;

namespace ProductDesktop.Validation
{
    public class DuplicateValidation
    {
        private readonly DatabaseContext _context;
        public DuplicateValidation(DatabaseContext context)
        {
            _context = context;
        }
        public string DuplicateUsername(string userName)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.Username == userName);
            
            if (user == null) {
                return userName; 
            }
            else
            {
                throw new Exception("The username is already taken.");
            }
        }
    }
}
