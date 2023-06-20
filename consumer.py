from kafka import KafkaConsumer
import json

TOPIC_NAME = 'items'

consumer = KafkaConsumer(TOPIC_NAME, key_deserializer=lambda key: key.decode('utf-8'), value_deserializer=lambda v: json.loads(v.decode('utf-8')))
for message in consumer:
    print ("key: %s\nvalue: %s" % (message.key, message.value))