from fastapi import FastAPI, Depends, HTTPException
from sqlalchemy.orm import Session
from app.crud import get_all_energy_data, create_data_energy
from app.models import DataEnergy
from app.db import SessionLocal, engine
from fastapi.middleware.cors import CORSMiddleware

DataEnergy.metadata.create_all(bind=engine)

app = FastAPI()

origins = [
	"http://localhost:4200",
	"http://localhost:81",
	"http://localhost:80",
	"http://frontend_angular"
]

app.add_middleware(
	CORSMiddleware,
	allow_origins=origins,
	allow_credentials=True,
	allow_methods=["*"],
	allow_headers=["*"],
)

def get_db():
	"""
	Creates and yields a database session.

	Yields:
	The database session.
	"""
	db = SessionLocal()
	try:
		yield db
	finally:
		db.close()

@app.get("/")
def root(db: Session = Depends(get_db)):
	"""
	Root endpoint handler. Retrieves all energy data entries from the database.

	Returns:
	A list of all energy data entries.
	"""
	try:
		return get_all_energy_data(db)
	except Exception as e:
		raise HTTPException(status_code=500, detail=str(e))


@app.get("/save_from_api1")
def create_energy_data(db: Session = Depends(get_db)):
	"""
	Endpoint handler to create energy data in the database from the external API.

	Returns:
	A dictionary containing the status code and a success message.
	"""
	try:
		result = create_data_energy(db)
		return {"message": result, "status": 201}
	except Exception as e:
		raise HTTPException(status_code=500, detail=str(e))
