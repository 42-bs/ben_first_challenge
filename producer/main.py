from srcs.energy_data_kafka_producer import EnergyDataKafkaProducer
import kafka
import kafka.errors
from kafka import KafkaConsumer, TopicPartition
import time

if __name__ == "__main__":
	localhost = False
	serverhost = 'localhost:9092' if localhost == True else 'kafka:9092'

	producer = EnergyDataKafkaProducer(server=serverhost)
	print(producer)
	# consumer = KafkaConsumer(bootstrap_servers=serverhost)
	# print(consumer)
	# consumer.assign([TopicPartition('random_energy_data', 2)])
	while (True):
		print("sending")
		producer.send_through_kafka()
		time.sleep(2)
		# msg = next(consumer)
		# print("receiving")
		# print (msg)

