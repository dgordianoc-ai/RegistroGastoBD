# Registro de Gastos

Programa de consola desarrollado en C# para consultar y mostrar gastos almacenados en una base de datos SQL Server LocalDB utilizando ADO.NET.

## Funciones

- Crear y utilizar la base de datos `GastosDB`.
- Consultar los gastos registrados en la tabla `Gastos`.
- Conectarse a SQL Server LocalDB mediante ADO.NET.
- Mostrar los gastos almacenados.
- Calcular el total gastado.
- Mostrar un mensaje cuando no existen gastos registrados.
- Realizar diferentes escenarios de prueba.
- Comprobar el comportamiento cuando la base de datos no existe.

### Escenario 4: SqlException

Se cambió temporalmente la cadena de conexión para utilizar una base de datos que no existía:

```text
GastosDBPrueba