from kafka import KafkaProducer
import json
import randomDataGenerator
import time

TOPIC_NAME = 'items'
KAFKA_SERVER = 'localhost:9092'

producer = KafkaProducer(bootstrap_servers=KAFKA_SERVER, key_serializer=str.encode, value_serializer=lambda v: json.dumps(v).encode('utf-8'))

while(True):
    id, infos = randomDataGenerator.generate_random_data()

    compania = json.dumps(infos)
    producer.send(TOPIC_NAME, key=str(id), value=compania)
    time.sleep(0.1)


