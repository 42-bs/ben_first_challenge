from srcs.energy_data_builder import EnergyDataBuilder

class TestClass:
	def test_default_id_return(self):
		databuilder = EnergyDataBuilder()
		id = databuilder.id()
		assert isinstance(id, int) == True

	def test_default_id_lesser_than_longmax(self):
		for _ in range(100):
			databuilder = EnergyDataBuilder(long_max=2)
			id = databuilder.id()
			assert id < 2
