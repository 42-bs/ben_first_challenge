from sqlalchemy import Column, Integer, String, BigInteger, Float, DateTime

# from .db import Base
import db

class DataEnergy(db.Base):
    __tablename__ = "Data_Energy"

    id = Column(Integer, primary_key=True, index=True, autoincrement=True)
    company_id = Column(BigInteger)
    consumer_unity = Column(String)
    value = Column(Float)
    timestamp = Column(DateTime)