from sqlalchemy import Column, Integer, String, BigInteger, Float
from app.db import Base

class DataEnergy(Base):
	"""
	The DataEnergy SQLAlchemy model. Represents the energy data entries in the database.

	Attributes:
	id (Integer): The primary key.
	company_id (BigInteger): The ID of the company.
	consumer_unity (String): The consumer unit.
	value (Float): The energy value.
	timestamp (Float): The timestamp.
	"""
	__tablename__ = "DataEnergy"

	id = Column(Integer, primary_key=True, index=True)
	company_id = Column(BigInteger)
	consumer_unity = Column(String)
	value = Column(Float)
	timestamp = Column(Float)
