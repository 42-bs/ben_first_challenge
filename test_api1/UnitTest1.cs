using Api1.Models;
using Microsoft.EntityFrameworkCore;

namespace test_api1
{
    public class UnitTest1
    {
        [Fact]
        public void Test_energyData_is_not_null_on_instantiate()
        {
            EnergyData energyData;
            
            energyData = new EnergyData();

            Assert.NotNull(energyData);
        }

        [Fact]
        public void EnergyDataDbContext_Should_Have_DbSet_CompanyEnergyData()
        {
            var options = new DbContextOptionsBuilder<EnergyDataDbContext>().UseInMemoryDatabase(databaseName: "dbTest").Options;

            using (var dbContext = new EnergyDataDbContext(options))
            {
                Assert.NotNull(dbContext);
                Assert.NotNull(dbContext.CompanyEnergyData);
                Assert.IsAssignableFrom<DbSet<EnergyData>>(dbContext.CompanyEnergyData);
            }
        }
    }
}