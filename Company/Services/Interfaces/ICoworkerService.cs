using Company.Models;

namespace Company.Services.Implementations
{
    public interface ICoworkerService
    {
        Coworker GetWorkerByEmail(string email);
        int GetCoworkerNumber();
        int AddPhoneToCoworker(PhoneDto phone);
    }
}