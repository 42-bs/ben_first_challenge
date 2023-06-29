from kafka import KafkaProducer
from .energydata_builder import EnergyData, EnergyDataBuilder
import time

class EnergyDataKafkaProducer:
	def __init__(self,
		server='kafka:9092',
		topic='random_energy_data',
		retry_limit=30):
		self._server = server
		self._topic = topic
		self._retry_limit = retry_limit
		self._producer = self.connect_to_kafka()
		self._builder = EnergyDataBuilder()

	def connect_to_kafka(self):
		while (self._retry_limit > 0):
			try:
				producer = KafkaProducer(bootstrap_servers=self._server)
				return producer
			except:
				print('tentando conexão')
				time.sleep(1)
				self._retry_limit -= 1
		raise ConnectionError

	def send_through_kafka(self):
		return self._producer.send(self._topic, EnergyData(self._builder))
