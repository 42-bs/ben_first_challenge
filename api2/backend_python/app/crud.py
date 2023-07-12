from sqlalchemy.orm import Session
from app.models import DataEnergy
from app.energy_data_serializer import energy_data_deserializer

def create_data_energy(db: Session):
	"""
	Creates energy data in the database from the external API.

	Returns:
	The success message as a string.
	"""
	try:
		energy_data_received = energy_data_deserializer()
		db.add_all(energy_data_received)
		db.commit()
		return ("Data got from api1. Go for root to see all entries")
	except Exception as e:
		db.rollback()
		raise e

def get_all_energy_data(db: Session):
	"""
	Retrieves all energy data entries from the database.

	Returns:
	A list of all energy data entries.
	"""
	return db.query(DataEnergy).all()
