from sqlalchemy import Column, Integer, String, Float, DateTime
from dbconfig import Base

class EnergyData(Base):
	__tablename__ = 'energy_data'
	id = Column(Integer, primary_key=True, index=True, autoincrement=True)
	company_id = Column(Integer)
	consumer_unity = Column(String)
	value = Column(Float)
	date = Column(DateTime)