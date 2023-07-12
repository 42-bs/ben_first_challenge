import requests
import json
from app.models import DataEnergy
import logging

api1_url = 'http://host.docker.internal:5002/api/energy_data'

def get_energy_data_from_api1():
	"""
	Retrieves energy data from the external API.

	Returns:
	A list of energy data from the API.
	"""
	try:
		return json.loads(requests.get(api1_url).text)
	except requests.exceptions.RequestException as err:
		logging.error(f"An error occurred: {err}")
		return []


def energy_data_deserializer():
	"""
	Converts the energy data received from the API into DataEnergy objects.

	Returns:
	A list of DataEnergy objects.
	"""
	energy_data_list_from_api1 = get_energy_data_from_api1()
	energy_data_list = []
	if energy_data_list_from_api1:
		for item in energy_data_list_from_api1:
			energy_data = DataEnergy()
			energy_data.company_id = item['companyId']
			energy_data.consumer_unity = item['consumerUnity']
			energy_data.value = item['value']
			energy_data.timestamp = item['timestamp']
			energy_data_list.append(energy_data)
	return energy_data_list
