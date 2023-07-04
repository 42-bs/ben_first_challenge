import random
import string
from datetime import datetime

class EnergyDataBuilder:
	"""
	This class maintain the configuration, rules
	and restrictions about every variable of the EnergyData object.
	"""

	def __init__(self,
		id_list_size = 50,
		long_max = 9223372036854775807,
		max_digits_of_consumer_unity = 10,
		max_energy_value = 9999999,
		characters_allowed = string.ascii_letters + string.digits):
		"""
		Constructs the builder object used in the construction of the EnergyData object
		Creates a list of random ids and them always use one of this ids and generate
		random data of every other information

		Args:
			id_list_size (int, optional): The size of the list of ids avaiables. Defaults to 50.
			long_max (int, optional): Assuming the consumer will be written in a language that uses
			long as a type, limits the max value of this long variable so it do not overflow. Defaults to 9223372036854775807.
			max_digits_of_consumer_unity (int, optional): Constraint the max string length of consumer unity. Defaults to 10.
			max_energy_value (int, optional): Constraint the max fake energy value. Defaults to 9999999.
			characters_allowed (string, optional): Set of characters allowed in the fake consumer unity random str generator. Defaults to string.ascii_letters+string.digits.
		"""

		self._id_list_size = id_list_size
		self._long_max = long_max
		self._max_digits_of_consumer_unity = max_digits_of_consumer_unity
		self._max_energy_value = max_energy_value
		self._id_list = [random.randrange(1, long_max) for _ in range(id_list_size)]
		self._characters_allowed = characters_allowed

	def id(self):
		"""
		Choose a random id from the list of ids generated on construction.

		Returns:
			long: a random id as long
		"""

		return random.choice(self._id_list)
	
	def consumer_unity(self):
		"""
		Create a random string to represent the consumer unity field.

		Returns:
			str: a random consumer unity as str
		"""
		return ''.join(random.choices(self._characters_allowed, k=self._max_digits_of_consumer_unity))

	def value(self):
		"""
		Create a random double value to represent the value field.

		Returns:
			double: a random value as double
		"""

		return round(random.uniform(1, self._max_energy_value), 2)

	def date(self):
		"""
		Create a random timestamp value to represent the date field.

		Returns:
			float: a random timestamp value as float
		"""

		return datetime.now().timestamp()