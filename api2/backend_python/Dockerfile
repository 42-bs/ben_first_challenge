# FROM python:3

# WORKDIR /app

# # ENV PYTHONDONTWRITEBYTECODE=1 \
# #     PYTHONUNBUFFERED=1 \
# #     PYTHONIOENCODING=utf-8

# RUN python -m venv venv
# ENV PATH="/apppython/venv/bin:$PATH"

# COPY requirements.txt .

# RUN pip install --no-cache-dir -r requirements.txt

# COPY . .

# CMD ["uvicorn", ".main:app", "--reload"]
# CMD ["python", "-u", "main.py"]
# CMD [ "pytest" ]

# FROM python:3.9
FROM tiangolo/uvicorn-gunicorn-fastapi:python3.9

WORKDIR /code

COPY ./requirements.txt /code/requirements.txt

RUN pip install --no-cache-dir --upgrade -r /code/requirements.txt

COPY ./app /code/app

CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "80"]
