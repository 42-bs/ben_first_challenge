from typing import Union

from pydantic import BaseModel

class EnergyDataCreate(BaseModel):
    id: int
    company_id: int
    consumer_unity: str
    value: float
    timestamp: int

    class Config:
        orm_mode = True