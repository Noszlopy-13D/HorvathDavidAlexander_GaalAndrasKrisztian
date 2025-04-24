CREATE DATABASE IF NOT EXISTS rent_a_car;
CREATE USER IF NOT EXISTS 'api_user'@'localhost' IDENTIFIED BY 'admin';

GRANT ALL PRIVILEGES ON rent_a_car.* TO 'api_user'@'localhost';

FLUSH PRIVILEGES;
