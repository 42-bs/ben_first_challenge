from fastapi import FastAPI, Depends
from sqlalchemy.orm import Session
from app.crud import get_all_energy_data, create_data_energy
from app.models import DataEnergy
from app.db import SessionLocal, engine

DataEnergy.metadata.create_all(bind=engine)

app = FastAPI()

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

@app.get("/")
def root(db: Session = Depends(get_db)):
    return (get_all_energy_data(db))

@app.get("/save_from_api1")
def create_energy_data(db: Session = Depends(get_db)):
    return (create_data_energy(db))