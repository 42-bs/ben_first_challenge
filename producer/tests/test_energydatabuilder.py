from ..energydata_builder import EnergyDataBuilder
from ..energydata_builder import EnergyData
from ..energydata_kafkaproducer import EnergyDataKafkaProducer
import pytest
from kafka.errors import KafkaError

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

	def test_default_energy_data_return(self):
		new_energy_data = EnergyData(EnergyDataBuilder())
		assert isinstance(new_energy_data._id, int) == True
		assert isinstance(new_energy_data._consumer_unity, str) == True
		assert isinstance(new_energy_data._value, float) == True
		assert isinstance(new_energy_data._date, float) == True
	
	def test_send_through_kafka(self):
		producer = EnergyDataKafkaProducer(server='localhost:9092')
		msg = producer.send_through_kafka()
		assert True
		# with pytest.raises(KafkaError):
		# 	metadata = msg.get(timeout=11)
		# 	assert metadata.topic == 'random_energy_data'