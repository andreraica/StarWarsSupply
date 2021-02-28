FROM node:15

EXPOSE 4200

RUN mkdir /usr/src/app
WORKDIR /usr/src/app

RUN npm install -g @angular/cli

COPY . .

# docker build -t andreraica/starwarssupplycalculator_webapp .

# >>> Publishing on DockerHub <<<
# docker login
# docker push andreraica/starwarssupplycalculator_webapp