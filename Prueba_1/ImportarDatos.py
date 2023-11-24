# Antes que nada ejecutar el siguiente comando para instalar los requerimientos
# pip install -r requirements.txt

import pandas as pd
import mysql.connector

# Leer el archivo de excel
df = pd.read_excel('DatosPracticaSQL.xlsx', sheet_name=None)

# Crear conexión con la base de datos
con = mysql.connector.connect(
    host='localhost',
    user='root',
    password='MasterediDES2023!',
    database='TestDevBackJr'
)

# Insertar datos en la tabla usuarios
query = """
INSERT INTO usuarios (Login, Nombre, Paterno, Materno)
VALUES (%s, %s, %s, %s)
"""
for i, row in df['Info usuarios'].iterrows():
    cursor = con.cursor()
    #user_id = int(row['Login'].split('user')[-1])
    cursor.execute(query, (row['Login'], row['NOMBRES'], row['PATERNO'], row['MATERNO']))
    con.commit()

# Insertar datos en la tabla empleados
query = """
INSERT INTO empleados (userId, Sueldo, FechaIngreso)
VALUES (%s, %s, %s)
"""
for i, row in df['Info Empleados'].iterrows():
    cursor = con.cursor()
    user_id = int(row['Login'].split('user')[-1])
    sueldo = float(row['Sueldo'])
    fechaIngreso = row['Fecha Ingreso']
    cursor.execute(query, (user_id, sueldo, fechaIngreso))
    con.commit()

# Cerrar conexión con la base de datos
con.close()