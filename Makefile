docker-build:
        docker build -t InfiniteRecipeBook .

docker-run:
        docker run --rm -p 7600:7600 InfiniteRecipeBook

connect:
        ssh -i ~/.ssh/digitalOcean_id_rsa system@164.90.149.20

deploy:
        rsync -Pav --exclude-from "$(shell pwd)"/.exclude -e ssh -i ~/.ssh/digitalOcean_id_rsa "$(shell pwd)" system@164.90.149.20:~/apps/