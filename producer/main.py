from srcs.energy_data_kafka_producer import EnergyDataKafkaProducer
import kafka
import kafka.errors
from kafka import KafkaConsumer, TopicPartition
import time
import os

if __name__ == "__main__":
	serverhost = os.getenv("KAFKA_HOST")
	print(serverhost)
	producer = EnergyDataKafkaProducer(server=serverhost, retry_limit=50)
	while (True):
		print("sending")
		producer.send_through_kafka()
		time.sleep(2)
