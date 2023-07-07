from sqlalchemy import Column, Integer, String, BigInteger, Float

from app.db import Base

class DataEnergy(Base):
    __tablename__ = "DataEnergy"

    id = Column(Integer, primary_key=True, index=True)
    company_id = Column(BigInteger)
    consumer_unity = Column(String)
    value = Column(Float)
    timestamp = Column(Float)