from fastapi import FastAPI
# import models
# from dbconfig import Base, engine, SessionLocal
import requests
import json

variavel = requests.get('http://localhost:5002/api/energy_data')

# outra = json.loads(variavel)


app = FastAPI()


@app.get("/")
async def root():
	return {variavel.text}

# @app.get("/energy_data/insert")
# async def create_energy_data():
# 	db = getdb()
# 	energydata = models.EnergyData(company_id=2974009792453170621, consumer_unity="OwiwCsQxLN", value=3647484.66, date="2023-07-04T00:00:00")
# 	db.add(energydata)
# 	db.commit()
# 	db.refresh(energydata)
# 	return {energydata}