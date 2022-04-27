using Company.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Company.Services.Implementations
{
    public class CoworkerService : ICoworkerService
    {
        private readonly AppDbContext _context;

        public CoworkerService(AppDbContext context) => _context = context;

        public Coworker GetWorkerByEmail(string email) => _context.Coworkers.Where(e => e.Email == email).Include(p => p.Phones).Include(n => n.Notebooks).FirstOrDefault();

        public int GetCoworkerNumber() => _context.Coworkers.Count();

        public int AddPhoneToCoworker(PhoneDto phone)
        {
            if (phone is not null)
            {
                _context.Phones.Add(new Phone()
                {
                    Type = phone.Type,
                    Brand = phone.Brand,
                    CoworkerId = phone.CoworkerId,
                });

                return _context.SaveChanges();
            }
            else return 0;
        }

        public void UpdatePhoneToCoworker()
        {

        }
    }
}
