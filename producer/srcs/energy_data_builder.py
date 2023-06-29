import random
import string
from datetime import datetime

class EnergyDataBuilder:
	def __init__(self,
		id_list_size = 50,
		long_max = 9223372036854775807,
		max_digits_of_consumer_unity = 10,
		max_energy_value = 9999999,
		characters_allowed = string.ascii_letters + string.digits):
		self._id_list_size = id_list_size
		self._long_max = long_max
		self._max_digits_of_consumer_unity = max_digits_of_consumer_unity
		self._max_energy_value = max_energy_value
		self._id_list = [random.randrange(1, long_max) for _ in range(id_list_size)]
		self._characters_allowed = characters_allowed

	def id(self):
		return random.choice(self._id_list)
	
	def consumer_unity(self):
		return ''.join(random.choices(self._characters_allowed, k=self._max_digits_of_consumer_unity))

	def value(self):
		return round(random.uniform(1, self._max_energy_value), 2)

	def date(self):
		return datetime.now().timestamp()