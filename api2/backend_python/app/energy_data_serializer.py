import requests
import json
from app.models import DataEnergy

api1_url = 'http://localhost:5002/api/energy_data'

energy_data_list_from_api1 = json.loads(requests.get(api1_url).text)

def energy_data_deserializer():
	energy_data_list = []
	for item in energy_data_list_from_api1:
		energy_data = DataEnergy()
		energy_data.company_id = item['companyId']
		energy_data.consumer_unity = item['consumerUnity']
		energy_data.value = item['value']
		energy_data.timestamp = item['timestamp']
		energy_data_list.append(energy_data)
	return energy_data_list