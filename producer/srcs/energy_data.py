class EnergyData:
	def __init__(self, builder):
		self._id = builder.id()
		self._consumer_unity = builder.consumer_unity()
		self._value = builder.value()
		self._date = builder.date()

	def to_dict(self):
		return { "id": self._id,
            "consumer_unity": self._consumer_unity,
            "value": self._value,
            "date": self._date }