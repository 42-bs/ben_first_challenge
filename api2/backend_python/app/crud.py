from sqlalchemy.orm import Session
from app.models import DataEnergy
from app.energy_data_serializer import energy_data_deserializer

def create_data_energy(db: Session):
	energy_data_received = energy_data_deserializer()
	db.add_all(energy_data_received)
	db.commit()
	return ("Data got from api1. Go for root to see all entries")

def get_all_energy_data(db: Session):
	return db.query(DataEnergy).all()