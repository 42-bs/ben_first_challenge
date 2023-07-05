from fastapi import FastAPI
import models
from dbconfig import Base, engine, SessionLocal
import requests
import json

Base.metadata.create_all(bind=engine)
# variavel = requests.get('localhost:5002/api/energy_data')

variavel = open('../cavalito', 'r').read()
outra = json.loads(variavel)
for energydata in outra:
	print(energydata['id'])

app = FastAPI()

def getdb():
	try:
		db = SessionLocal()
		yield db
	finally:
		db.close()


@app.get("/")
async def root():
	return {variavel}

@app.get("/energy_data/insert")
async def create_energy_data():
	db = getdb()
	energydata = models.EnergyData(company_id=2974009792453170621, consumer_unity="OwiwCsQxLN", value=3647484.66, date="2023-07-04T00:00:00")
	db.add(energydata)
	db.commit()
	db.refresh(energydata)
	return {energydata}