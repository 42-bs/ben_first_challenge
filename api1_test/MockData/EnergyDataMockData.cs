using System.Collections.Generic;
using Api1.Models;
namespace api1_test.MockData
{
	public class EnergyDataMockData
	{
		public static List<EnergyData> GetEnergyDatas()
		{
			return new List<EnergyData> {
				new EnergyData {CompanyId=7826001880133985492,
					ConsumerUnity="txoanVmCLN",
					Value=9595885.43,
					Timestamp=DateTime.UnixEpoch.AddSeconds(1688561887.38128)}
			};
		}
	}
}