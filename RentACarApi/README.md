# Rent A Car Api
Ezen az API-n keresztül érhető el az adatbázis. 

## Adatbázis
A fejlesztés során az adatbázist lokálisan futtatjuk és magunk állítjuk be a beállításokat,
késöbb docker segítségével az egész api-t egy csomagként szeretnénk kezelni. `MariaDB`-t használunk.
Az adatbázis létrehozásához és kezeléséhez az `Entity Framework Core` eszközt használjuk.

### Jelenlegi beállításai
- server: localhost
- port: 3306
- username: api_user
- password: admin
- database: rent_a_car
- összes privigélium

### Táblák
#### Cars
- Id: int
- ModelId: int 
- FuelTypeId: int 
- CategoryId: int
- Km: int
- PricePerKm: int
- Year: int
- HorsePower: int
- Description: varchar(400)

#### Models
- Id: int
- ManufacturerId: int
- Name: longtext

#### Manufacturers
- Id: int
- Name: varchar(50)
 
#### Categories
- Id: int
- Name: varchar(30)
 
#### Fuel_Types
- Id: int
- Name: varchar(30)

## API Endpointok
### Cars
#### Összes autó lekérése
~~~ http request
GET /cars
~~~
Válasz:
~~~ json
[
  {
    "id": 1,
    "modelId": 3,
    "categoryId": 1,
    "fuelTypeId": 1,
    "km": 121322,
    "pricePerKm": 50,
    "year": 2016,
    "horsePower": 150,
    "description": "A Volkswagen Passat egy tágas és kényelmes szedán..."
  },
  {
    "id": 2,
    "modelId": 4,
    "categoryId": 1,
    "fuelTypeId": 2,
    "km": 98500,
    "pricePerKm": 45,
    "year": 2018,
    "horsePower": 120,
    "description": "A Ford Focus egy dinamikus és megbízható kompakt autó..."
  }
]
~~~

#### Autó id alapján való lekérdezése
~~~ http request
GET /cars/{id}
~~~
Válasz
~~~ json
{
    "id":1,
    "modelId":3,
    "categoryId":1,
    "fuelTypeId":1,
    "km":121322,
    "pricePerKm":50,
    "year":2016,
    "horsePower":150,
    "description":"A Volkswagen Passat egy tágas és kényelmes szedán..."
}
~~~

#### Autó hozzáadása
~~~
POST /cars
~~~
Request body
~~~ json
{
    "modelId": 1,
    "categoryId": 1,
    "fuelTypeId": 1,
    "km":121322,
    "pricePerKm":50,
    "year":2016,
    "horsePower":150,
    "description":"A Volkswagen Passat egy tágas és kényelmes szedán..."
}
~~~

#### Autó frissítése
A választott rekordot teljesen kicseréli
~~~ http request
PUT /cars/{id}
~~~
Request body
~~~ json
{
    "modelId": 4,
    "categoryId": 1,
    "fuelTypeId": 2,
    "km": 98500,
    "pricePerKm": 45,
    "year": 2018,
    "horsePower": 120,
    "description": "A Ford Focus egy dinamikus és megbízható kompakt autó..."
}
~~~

#### Autó törlése
~~~ http request
DELETE /cars/{id}
~~~

---

### Models
#### Összes modell lekérése
~~~ http request
GET /models
~~~
Válasz:
~~~ json
[
    {
        "id":1,
        "manufacturerId":1,
        "name":"C-Osztály"
    },
    {
        "id":2,
        "manufacturerId":1,
        "name":"E-Osztály"
    },
]
~~~

#### Modell id alapján való lekérdezése
~~~ http request
GET /models/{id}
~~~
Válasz
~~~ json
{
    "id":1,
    "manufacturerId":1,
    "name":"C-Osztály"
}
~~~

#### Modell hozzáadása
~~~
POST /models
~~~
Request body
~~~ json
{
    "manufacturerId":1,
    "name":"C-Osztály"
}
~~~

#### Modell frissítése
A választott rekordot teljesen kicseréli
~~~ http request
PUT /models/{id}
~~~
Request body
~~~ json
{
    "manufacturerId":1,
    "name":"E-Osztály"
}
~~~

#### Modell törlése
~~~ http request
DELETE /models/{id}
~~~

--- 

### Categories
#### Összes kategória lekérése
~~~ http request
GET /categories
~~~
Válasz:
~~~ json
[
    {
        "id":1,
        "name": "Hétköznapi"
    },
    {
        "id":2,
        "name": "Luxus"
    },
]
~~~

#### Kategória id alapján való lekérdezése
~~~ http request
GET /categories/{id}
~~~
Válasz
~~~ json
{
    "id":1,
    "name": "Hétköznapi"
}
~~~

#### Kategória hozzáadása
~~~
POST /categories
~~~
Request body
~~~ json
{
    "name": "Hétköznapi"
}
~~~

#### Kategória frissítése
A választott rekordot teljesen kicseréli
~~~ http request
PUT /categories/{id}
~~~
Request body
~~~ json
{
    "name": "Luxus"
}
~~~

#### Kategória törlése
~~~ http request
DELETE /categories/{id}
~~~

### Manufacturers és FuelTypes
Az ezekben tárolt adatok jelenleg teljes mértékben megegyeznek a kategória táblában tároltakkal, így
az endpointjaik is megegyeznek ezekkel. Gyártóknál a `/manufacturers`, üzemanyag típusoknál a `/fuel_types`
a használandó url.