from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, declarative_base
from sqlalchemy_utils import database_exists, create_database
import os

username = os.getenv('DB_USER')
password = os.getenv('DB_PASS')
server = os.getenv('DB_SERVER')
connection_string = 'mssql+pymssql://SA:Bosch42$@localhost:1433/Cavalito'
engine = create_engine(connection_string)

if not database_exists(engine.url):
    create_database(engine.url)

SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()