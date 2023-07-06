from fastapi import FastAPI, Depends
import models
from dbconfig import SessionLocal
import requests
import json
from schema import EnergyDataSchema

energy_data_list_from_api1 = json.loads(requests.get('http://localhost:5002/api/energy_data').text)
app = FastAPI()

def energy_data_deserializer():
	energy_data_list = []
	for energy_data in energy_data_list_from_api1:
		energy_data_list.append(models.EnergyData(
			company_id=energy_data['companyId'],
			consumer_unity=energy_data['consumerUnity'],
			value=energy_data['value'],
			date=energy_data['timestamp']))
	return energy_data_list

energy_data_received = energy_data_deserializer()

@app.get("/")
async def root():
	return energy_data_received[0]

def getdb():
	db = SessionLocal()
	try:
		yield db
	finally:
		db.close()

@app.get("/energy_data/")
def create_energy_data(db: SessionLocal = Depends(getdb)):
	db.add(energy_data_received[0])
	db.commit()
	return energy_data_received[0]