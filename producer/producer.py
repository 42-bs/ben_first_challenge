from kafka import KafkaProducer
import json
import randomDataGenerator
import time

TOPIC_NAME = 'random_energy_data'
KAFKA_SERVER = 'localhost:9092'

#producer = KafkaProducer(bootstrap_servers=KAFKA_SERVER, key_serializer=str.encode, value_serializer=lambda v: json.dumps(v).encode('utf-8'))

start = time.time()


while(True):
    id, infos = randomDataGenerator.generate_random_data()

    compania = json.dumps(infos)
    #producer.send(TOPIC_NAME, key=str(id), value=compania)
    time.sleep(1)
    print(infos)


