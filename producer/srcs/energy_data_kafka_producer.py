from kafka import KafkaProducer
from .energy_data_builder import EnergyDataBuilder
from .energy_data import EnergyData
import json
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
				time.sleep(1)
				self._retry_limit -= 1
		raise ConnectionError

	def send_through_kafka(self):
		message = json.dumps(EnergyData(self._builder).to_dict())
		return self._producer.send(self._topic, message.encode('utf-8'))
