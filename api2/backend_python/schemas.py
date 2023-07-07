from typing import Union
import datetime

from pydantic import BaseModel

class EnergyDataCreate(BaseModel):
    id: int
    company_id: int
    consumer_unity: str
    value: float
    timestamp: datetime.datetime

    class Config:
        orm_mode = True