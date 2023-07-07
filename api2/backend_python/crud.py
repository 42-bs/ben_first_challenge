from sqlalchemy.orm import Session

import models, schemas

def create_data_energy(db: Session, energydata: schemas.EnergyDataCreate):
    db_energydata = models.DataEnergy(company_id=123, consumer_unity="abc", value=0.02, timestamp=123)
    db.add(db_energydata)
    db.commit()
    db.refresh(db_energydata)
    return (db_energydata)