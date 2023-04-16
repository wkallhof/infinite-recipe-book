build:
	dotnet build ./src/InfiniteRecipeBook/InfiniteRecipeBook.csproj

run:
	dotnet run --project ./src/InfiniteRecipeBook/InfiniteRecipeBook.csproj

watch:
	dotnet watch run --project ./src/InfiniteRecipeBook/InfiniteRecipeBook.csproj

docker-build:
	docker build -t recipes .

docker-run:
	docker run --rm -p 7600:7600 recipes

connect:
	ssh -i ~/.ssh/digitalOcean_id_rsa system@164.90.149.20

deploy:
	rsync -Pav --exclude-from "$(shell pwd)"/.exclude -e ssh -i ~/.ssh/digitalOcean_id_rsa "$(shell pwd)" system@164.90.149.20:~/apps/