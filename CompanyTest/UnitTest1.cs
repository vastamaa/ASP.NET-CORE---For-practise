using Company.Models;
using Company.Services.Implementations;
using System.Linq;
using Xunit;

namespace CompanyTest
{
    public class UnitTest1
    {
        private AppDbContext context;
        private ICoworkerService coworkerService;

        public UnitTest1()
        {
            this.context = new AppDbContext();
            this.coworkerService = new CoworkerService(context);
        }

        [Fact]
        public void Test1() => Assert.Equal(3, coworkerService.GetCoworkerNumber());

        [Fact]
        public void Test2()
        {
            Coworker result = coworkerService.GetWorkerByEmail("avidhentailover69@gmail.com");
            Assert.Equal("Almási Milán", result.Name);
            Assert.Equal(1, result.Notebooks.Count);
        }

        [Fact]
        public void Test3()
        {
            Coworker result = coworkerService.GetWorkerByEmail("vasko-szedlart@kkszki.hu");
            Phone phone = result.Phones.Where(p => p.Brand == "Samsung").FirstOrDefault();
            Assert.Equal(3, result.Phones.Count);
            Assert.NotNull(phone);
        }

        [Fact]
        public void Test4()
        {
            coworkerService.AddPhoneToCoworker(new PhoneDto()
            {
                Brand = "XingXang",
                Type = "Milchi",
                CoworkerId = 1
            });

            Coworker coworker = coworkerService.GetWorkerByEmail("valami.janos@teszt.hu");
            Assert.NotNull(coworker.Phones.Where(p => p.Brand == "XingXang").FirstOrDefault());
        }
    }
}
