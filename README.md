# Uruchomienie projektu

Project można uruchomić jako [aplikacja](#uruchomienie-jako-aplikacja) lub jako [kontener docker](#uruchom-jako-kontener-docker).

## Uruchomienie jako aplikacja

Przed uruchomieniem aplikacji należy upewnić się, że baza [postgresql](#konfiguracja-bazy-postgresql) oraz [redis](#konfiguracja-bazy-redis) są uruchomione. Po uruchomieniu baz danych i zakutalizowaniu konfiguracji należy uruchomić `SchoolProject.API.exe`.

## Konfiguracja bazy postgresql

Aby aplikacja mogła połączyć się z bazą postgresql należy podmienić wartość `DbConnectionString` w pliku `appsettings.json`. Wartość pola powinna być zapisana w następującym formacie:

```
"DbConnectionString": "Host=[host];Port=[port];Database=SchoolProject;Username=[nazwa użytkownika];Password=[hasło]"
```

## Konfiguracja bazy redis

Aby aplikacja mogła połączyć się z bazą redis należy odpowiednio zmienić wartości `RedisCacheConnectionString` w pliku `appsettings.json`. Wartość pola powinna być zapisana w następujący, formacje:

```
"RedisCacheConnectionString": "[host]:[port]"
```

## Uruchomienie jako kontener docker

Przed uruchomieniem aplikacji należy odpowiednio dostosować konfiguracje bazy [postgres](#konfiguracja-bazy-postgres-w-dockerze) oraz [redis](#konfiguracja=redis-w-dockerze). Po dostosowaniu ustawień do własnych preferencji należy uruchomić konsolę w miejscu `docker-compose.yml` a następnie wywołać w konsoli komendę `docker-compose up --build -d`.

## Konfiguracja bazy postgres w dockerze

Całość konfiguracji znajduje się w pliku `docker-compose.yml` w sekcji `postgres`. Aby zmienić miejsce docelowe zapisu bazy należy odszukać sekcję `volumes` i podmienić ścieżkę wskazując katalog, w którym zostanie zapisana baza.

```
postgres:
    ...
    volumes:
    - [ścieżka bezwzględna katalogu]:/var/lib/postgresql/data
```

Aby zmienić port bazy postgres należy odszukać sekcję `ports` i podmienić wartość.

```
  postgres:
    ...
    ports:
    - "[port]:5432"
```

**UWAGA!** Przy zmianie portu w `docker-compose.yml` należy także zaktualizować port w [konfiguracji aplikacji](#konfiguracja-bazy-postgresql).

## Konfiguracja redis w dockerze

Całość konfiguracji znajduje się w pliku `docker-compose.yml` w sekcji `redis`. Aby zmienić port bazy redis należy odszukać sekcję `ports` i podmienić wartość.

```
  redis:
    ...
    ports:
    - "[port]:6379"
```

**UWAGA!** Przy zmianie portu w `docker-compose.yml` należy takzę zaktualizować port w [konfiguracji aplikacji](#konfiguracja-bazy-redis).

---

# Run project

Project can be run as [exe](#run-as-exe) or in [docker container](#run-in-docker).

## Run as exe

Before running the application, you need to run [postgres](#configuring-postgres) and [redis](#configuring-redis). Make sure that connection parameters in the application configuration are set correctly. To run project, run `SchoolProject.API.exe` file.

## Configuring postgres

To connect the application to postgres database, change `DbConnectionString` in `appsettings.json` file. Connection string value should be in format:

```
"DbConnectionString": "Host=[host];Port=[port];Database=SchoolProject;Username=[username];Password=[password]"
```

## Configuring redis

To connect teh application to redis database, change `RedisCacheConnectionString` in `appsettings.json` file. Connection string value shoud be in format:

```
"RedisCacheConnectionString": "[host]:[port]"
```

## Run in docker

Before running the application, you can configure [postgres](#configuring-postgres-in-docker) and [redis](#configuring-redis-in-docker). After changing configuration, run cmd in folder with the file `docker-compose.yml` and run command `docker-compose up --build -d`.

## Configuring postgres in docker

To change configuration open `docker-compose.yml` file and find `postgres` section.
To change database storage location find `volumes` section and change value. 

```
postgres:
    ...
    volumes:
    - [database absolute path]:/var/lib/postgresql/data
```

To change postgres port find `ports` section and change value.
```
  postgres:
    ...
    ports:
    - "[port]:5432"
```

**WARNING!** After changing port in the `docker-compose.yml` file you need to update port value in [application config file](#configuring-postgres).

## Configuring redis in docker

To change configuration open `docker-compose.yml` file and find `redis` section. To change redis port find `ports` section and change value.

```
  redis:
    ...
    ports:
    - "[port]:6379"
```

**WARNING!** After changing port in the `docker-compose.yml` file you need to update port value in [application config file](#configuring-redis).