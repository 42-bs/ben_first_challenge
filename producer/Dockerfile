FROM python:3

WORKDIR /app

RUN python -m venv venv
ENV PATH="/apppython/venv/bin:$PATH"

COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD ["python", "-u", "producer.py"]