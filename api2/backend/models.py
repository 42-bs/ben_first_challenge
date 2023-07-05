import sqlalchemy
from dbconfig import Base

class EnergyData(Base):
	__tablename__ = 'energy_data'
	id = sqlalchemy.Column(sqlalchemy.Integer, primary_key=True, index=True, autoincrement=True)
	company_id = sqlalchemy.Column(sqlalchemy.Integer)
	consumer_unity = sqlalchemy.Column(sqlalchemy.String)
	value = sqlalchemy.Column(sqlalchemy.Float)
	date = sqlalchemy.Column(sqlalchemy.DateTime)