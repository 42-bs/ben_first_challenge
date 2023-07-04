class EnergyData:
	"""
	Object to be serialized and sent as a message to kafka.
	This class needs to be built with a builder, which sets up
	all the rules and restrictions about the information.
	"""

	def __init__(self, builder):
		"""
		Constructs the EnergyData object based on passed builder.

		Args:
			builder EnergyDataBuilder: This class maintain the configuration, rules
			and restrictions about every variable of the EnergyData object.
		"""

		self._id = builder.id()
		self._consumer_unity = builder.consumer_unity()
		self._value = builder.value()
		self._date = builder.date()

	def to_dict(self):
		"""
		Convert the current object to a dictionary

		Returns:
			Dictionary: a dictionary representation of class with variable name as key and the variable value as value.
		"""

		return { "id": self._id,
            "consumer_unity": self._consumer_unity,
            "value": self._value,
            "date": self._date }