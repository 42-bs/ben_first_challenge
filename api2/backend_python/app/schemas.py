from pydantic import BaseModel

class EnergyDataCreate(BaseModel):
	"""
	The EnergyDataCreate Pydantic model. Represents the structure of energy data for creation.

	Attributes:
	id (int): The ID of the energy data entry.
	company_id (int): The ID of the company.
	consumer_unity (str): The consumer unit.
	value (float): The energy value.
	timestamp (float): The timestamp.
	"""
	id: int
	company_id: int
	consumer_unity: str
	value: float
	timestamp: float

	class Config:
		orm_mode = True