from kafka import KafkaProducer
from .energy_data_builder import EnergyDataBuilder
from .energy_data import EnergyData
import json
import time

class EnergyDataKafkaProducer:
	"""
	A class to represent the producer. It only produces EnergyData as msg
	serialized as dict and uses a builder to specify how this EnergyData will be built.
	"""

	def __init__(self,
		server='kafka:9092',
		topic='random_energy_data',
		retry_limit=30):
		"""
		Constructs all the necessary attributes to connect to a kafka server and produces
		a msg to a topic with a EnergyData object.

		Args:
			server (str, optional): the address of the kafka server. Defaults to 'kafka:9092'.
			topic (str, optional): the target topic for the message. Defaults to 'random_energy_data'.
			retry_limit (int, optional): How many times it will try to reconnect if connection fail. Defaults to 30.

		the producer is a Kafka client that publishes records to the Kafka cluster.
		the builder is the class that will shape and construct the EnergyData information.
		"""
		self._server = server
		self._topic = topic
		self._retry_limit = retry_limit
		self._producer = self.connect_to_kafka()
		self._builder = EnergyDataBuilder()

	def connect_to_kafka(self):
		"""
		establishes connection to the target kafka server

		Raises:
			ConnectionError: in case of 'retry_limit' failures, this error is raised

		Returns:
			KafkaProducer: A Kafka client that publishes records to the Kafka cluster. 
		"""

		while (self._retry_limit > 0):
			try:
				producer = KafkaProducer(bootstrap_servers=self._server)
				return producer
			except:
				time.sleep(1)
				self._retry_limit -= 1
		raise ConnectionError

	def send_through_kafka(self):
		"""
		Serializes the message and send it through the KafkaProducer to the target topic

		Returns:
			FutureRecordMetadata: resolves to RecordMetadata
		"""

		message = json.dumps(EnergyData(self._builder).to_dict())
		return self._producer.send(self._topic, message.encode('utf-8'))
