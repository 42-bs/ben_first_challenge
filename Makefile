all: script build up

up:
	@docker-compose up

build:
	@docker-compose build --no-cache

script:
	@bash script/init_sqlite.sh

down:
	@docker-compose down

clean:    down
	@docker system prune -a

fclean:
	@-docker stop $$(docker ps -qa)
	@docker system prune --all --force --volumes
	@docker network prune --force
	@docker volume prune --force

super_clean:
	-docker stop $(docker ps -qa)
	-docker rm $(docker ps -qa)
	-docker rmi -f $(docker images -qa)
	-docker volume rm $(docker volume ls -q)
	-docker network rm $(docker network ls -q) 2>/dev/null
	
.PHONY: all up script build down re clean fclean super_clean