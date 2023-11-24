-- Active: 1700723661075@@localhost@3306@testdevbackjr

-- Empezamos a crear la DB y las tablas
CREATE DATABASE TestDevBackJr;
USE TestDevBackJr;

CREATE TABLE usuarios(
    userId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Login VARCHAR(100),
    Nombre VARCHAR(100),
    Paterno VARCHAR(100),
    Materno VARCHAR(100)
);

CREATE TABLE empleados(
    userId INT,
    Sueldo DOUBLE,
    FechaIngreso DATE,
    PRIMARY KEY(userId),
    FOREIGN KEY(userId) REFERENCES usuarios(userId)
);

-- Depurar solo los ID diferentes de 6,7,9 y 10 de la tabla usuarios
SELECT * FROM usuarios WHERE userId NOT IN (6,7,9,10);

-- Actualizar el dato Sueldo en un 10 porciento a los empleados que 
-- tienen fechas entre el año 2000 y 2001:
UPDATE empleados
SET Sueldo = Sueldo * 1.10
WHERE FechaIngreso BETWEEN '2000-01-01' AND '2001-12-31';


-- Realiza una consulta para traer el nombre de usuario y 
-- fecha de ingreso de los usuarios que ganan más de 10000 y 
-- su apellido comienza con T ordenado del más reciente al más antiguo:
SELECT u.Nombre, u.Paterno, u.Materno, e.FechaIngreso 
FROM usuarios u
JOIN empleados e ON u.userId = e.userId
WHERE e.Sueldo > 10000 AND u.Paterno LIKE 'T%'
ORDER BY e.FechaIngreso DESC;

-- Realiza una consulta donde agrupes a los empleados por sueldo, 
-- un grupo con los que ganan menos de 1200 y uno mayor o igual a 1200, 
-- cuantos hay en cada grupo?:
SELECT 
    CASE
        WHEN Sueldo < 1200 THEN 'Menos de 1200'
        ELSE '1200 o más'
    END AS 'GruposPorSueldo',
    COUNT(*) AS 'Cantidad'
FROM empleados
GROUP BY GruposPorSueldo;

-- R: Existen 46 empleado en el grupo  que tiene 1200 o más de sueldo,
--  y 0 en el grupo de menos de 1200