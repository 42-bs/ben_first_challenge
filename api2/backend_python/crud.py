from sqlalchemy.orm import Session
import datetime

import models

import requests
import json
energy_data_list_from_api1 = json.loads(requests.get('http://localhost:5002/api/energy_data').text)

def energy_data_deserializer():
	energy_data_list = []
	for energy_data1 in energy_data_list_from_api1:
		energy_data = models.DataEnergy()
		energy_data.company_id = energy_data1['companyId']
		energy_data.consumer_unity = energy_data1['consumerUnity']
		energy_data.value = energy_data1['value']
		energy_data.date = datetime.datetime.strptime(energy_data1['timestamp'], '%Y-%m-%dT%H:%M:%S').replace(tzinfo=datetime.timezone.utc)
		print(energy_data.date)
		print(type(energy_data.date))
		# print("2: " + energy_data1['timestamp'])
		print(datetime.datetime.utcnow)
		print(type(datetime.datetime.utcnow))
		energy_data_list.append(energy_data)
		print(type(datetime.datetime.now().timestamp()))
		print(datetime.datetime.now().timestamp())
		# 	company_id=energy_data['companyId'],
		# 	consumer_unity=energy_data['consumerUnity'],
		# 	value=energy_data['value'],
		# 	date=energy_data['timestamp']))
	return energy_data_list


def create_data_energy(db: Session):
	energy_data_received = energy_data_deserializer()
	# db_energydata = models.DataEnergy(company_id=123, consumer_unity="abc", value=0.02)
	# print(db_energydata)
	# db_energydata = models.DataEnergy()
	# db_energydata.company_id = 123
	# db_energydata.consumer_unity = "123"
	# db_energydata.value = 0.5
	# db_energydata.timestamp = datetime.datetime.now()
	# print(db_energydata)
	# db.add(db_energydata)
	# db.commit()
	# db.refresh(db_energydata)
	# db.add(energy_data_received[0])
	db.add_all(energy_data_received)
	db.commit()
	# db.refresh(energy_data_received)
	# db.refresh(energy_data_received[0])

	return ("Hello WORLD!")

def get_all_energy_data(db: Session):
	return db.query(models.DataEnergy).all()

# def get_all_energy_data(db: Session, skip: int = 0, limit: int = 100):
	# return db.query(models.DataEnergy).offset(skip).limit(limit).all()