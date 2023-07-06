from pydantic import BaseModel
from datetime import datetime

class EnergyDataSchema(BaseModel):
	company_id:int
	consumer_unity:str
	value:float
	date:datetime