from fastapi import FastAPI, Depends
from sqlalchemy.orm import Session

import crud, models, schemas
# from crud import create_data_energy
# from .models import DataEnergy
# from .schemas import EnergyDataCreate
from db import SessionLocal, engine

models.DataEnergy.metadata.create_all(bind=engine)

app = FastAPI()

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

@app.get("/")
def root(db: Session = Depends(get_db)):
    return (crud.get_all_energy_data(db))
# @app.get("/")
# async def root():
#     return {"message": "Welcome to 2nd API in BEN Project @ 42 + Bosch!"}

@app.get("/test")
def create_energy_data(db: Session = Depends(get_db)):
# def create_energy_data(energy_data: schemas.EnergyDataCreate, db: Session = Depends(get_db)):
    # db: Session = get_db()
    # energy_data: schemas.EnergyDataCreate
    return (crud.create_data_energy(db))
    # crud.create_data_energy(db = db, energy_data = energy_data)
    # return ("ok!")