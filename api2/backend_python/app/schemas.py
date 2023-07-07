from pydantic import BaseModel

class EnergyDataCreate(BaseModel):
    id: int
    company_id: int
    consumer_unity: str
    value: float
    timestamp: float

    class Config:
        orm_mode = True