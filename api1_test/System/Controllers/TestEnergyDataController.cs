using System.Threading.Tasks;
using Api1.Controllers;
using Api1.Models;
using api1_test.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api1_test.System.Controllers
{
	public class TestController
	{
		[Fact]
		public async Task cavalinho_ShouldReturn200Status()
		{
			/// Arrange
			var cavalinho = new Mock<EnergyDataController>();
			cavalinho.Setup(_ => _.GetCompany_Energy_Data()).ReturnsAsync(EnergyDataMockData.GetEnergyDatas());
			var sut = new EnergyDataController(cavalinho.Object);
	
			/// Act
			var result = (OkObjectResult)await sut.GetCompany_Energy_Data();
	
	
			// /// Assert
			result.StatusCode.Should().Be(200);
    	}
	}
}