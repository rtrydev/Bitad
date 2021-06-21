# BitadAPI

## Uruchomieniem

1. Skonfiguruj plik .env.
```
$ cd BitadAPI
$ cp .env.sample .env
$ vi .env
```
2. Zbudowanie programu.
```
$ docker-compose build
```
3. Wystartowanie kontenerów.
```
$ docker-compose up -d
```
## Pomocne polecenia
```
$ docker-compose up
$ docker-compose stop
$ docker-compose down
$ docker-compose build <service_name>
```
