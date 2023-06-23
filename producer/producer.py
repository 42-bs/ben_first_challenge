from kafka import KafkaProducer
import json
import randomDataGenerator
import time

TOPIC_NAME = 'random_energy_data'
KAFKA_SERVER = 'kafka:9092'

try_limits = 30
while (try_limits > 0):
    try:
        producer = KafkaProducer(bootstrap_servers=KAFKA_SERVER, key_serializer=str.encode, value_serializer=lambda v: json.dumps(v).encode('utf-8'))
        break
    except:
        time.sleep(10)
        try_limits -= 1


start = time.time()


while(True):
    id, infos = randomDataGenerator.generate_random_data()

    compania = json.dumps(infos)
    producer.send(TOPIC_NAME, key=str(id), value=compania)
    print(compania)
    time.sleep(1)
