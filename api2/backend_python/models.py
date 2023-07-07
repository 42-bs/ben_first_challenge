from sqlalchemy import Column, Integer, String, BigInteger, Float, DateTime

import datetime

import db

class DataEnergy(db.Base):
    __tablename__ = "Data_Energy"

    id = Column(Integer, primary_key=True, index=True)
    company_id = Column(BigInteger)
    consumer_unity = Column(String)
    value = Column(Float)
    # timestamp = Column(DateTime, default=datetime.datetime.utcnow)
    timestamp = Column(DateTime)