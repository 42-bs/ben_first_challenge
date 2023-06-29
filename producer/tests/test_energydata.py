from srcs.energy_data import EnergyData
from srcs.energy_data_builder import EnergyDataBuilder

class TestClass:
    def test_default_energy_data_return(self):
        new_energy_data = EnergyData(EnergyDataBuilder())
        assert isinstance(new_energy_data._id, int) == True
        assert isinstance(new_energy_data._consumer_unity, str) == True
        assert isinstance(new_energy_data._value, float) == True
        assert isinstance(new_energy_data._date, float) == True