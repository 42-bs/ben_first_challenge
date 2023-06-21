import string
import random
from datetime import datetime

# Id da compania : long
# Unidade Consumidora : string
# Valor : double
# Data : DateTime
#long SQL server = -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
long_min = -9223372036854775808
long_max = 9223372036854775807
max_digits_of_consumer_unity = 10
max_energy_value = 9999999

characters_allowed = string.ascii_letters + string.digits

def generate_random_data():
    id = random.randrange(1, long_max)
    consumer_unity = ''.join(random.choices(characters_allowed, k=max_digits_of_consumer_unity))
    value = round(random.uniform(1, max_energy_value), 2)
    date = datetime.now().timestamp()

    return id, {'Consumer Unity' : consumer_unity, 'Value' : value, 'Timestamp' : date}