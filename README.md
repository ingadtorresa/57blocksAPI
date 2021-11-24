# 57blocksAPI

Este es un proyecto para una prueba de Desarrollador .NET realizado por Andres Torres

## Comenzamos 🚀

Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas.


### Pasos 📋

1. Descargar la solución.
2. En la solución ir al proyecto de base de datos "57blocks.Database"
3. Publicar la base de datos ahí creara las 2 tablas correspondientes al ejercicio.
4. En el proyecto "57blocks.Database" buscar el script "Deploy.sql" realizar la Insert correspondientes a la tabla Pokemon.
5. Ejecutar el proyecto "57blocks.API"
6. Las APIS están documentadas en swagger para revisar la documentación y realizar pruebas de consumo agregar a la Url base /swagger 
```
localhost:44343/swagger
```

### Servicio de Registro ☺

Es el controlador de "UserLoginController". 

- Para poder hacer uso se debe insertar primero el usuario que debe tener un correo y una contraseña se consume el API "InsertLogin" punto 1 del ejercicio
- Para el punto 2 del ejercicio se hace uso de las API "login" y "GenerateToken" no se realiza nuevamente las validaciones porque el correo y la contraseña fue validado en el ejercicio 1 y para consumir estas apis debe ser con el correo y contraseña ya creados.
-  Para consumir Login se debe enviar correo, password y token. Este token es generado en "GenerateToken" que tiene una vigencia de 20 minutos.


### Servicio de Pokemon 🐴

Es el controlador de "PokemonController". 

- Se consume todos los metodos CRUD correspondientes.
- Ademas de los parametros del pokemon es necesario el "Email" para identificar los usuarios, este email fue el creado en el punto 1 en el API "InsertLogin"


## Ejecutando las APIS ⚙️

Para hacer el consumo de las APIS puede usar una aplicacion cliente o hacer uso de la interfaz de swagger donde estan documentadas las APIS

```
localhost:44343/swagger
```



## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto_

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - El framework web usado
* [Maven](https://maven.apache.org/) - Manejador de dependencias
* [ROME](https://rometools.github.io/rome/) - Usado para generar RSS

## Contribuyendo 🖇️

Por favor lee el [CONTRIBUTING.md](https://gist.github.com/villanuevand/xxxxxx) para detalles de nuestro código de conducta, y el proceso para enviarnos pull requests.

## Wiki 📖

Puedes encontrar mucho más de cómo utilizar este proyecto en nuestra [Wiki](https://github.com/tu/proyecto/wiki)

## Versionado 📌

Usamos [SemVer](http://semver.org/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/tu/proyecto/tags).

## Autores ✒️

Los Autores del proyecto son:

* **Andrés Torres Acevedo** - *Creador* - [villanuevand](https://github.com/villanuevand)

También puedes mirar la lista de todos los [contribuyentes](https://github.com/your/project/contributors) quíenes han participado en este proyecto. 

## Licencia 📄



Este proyecto está bajo la Licencia (Tu Licencia) - mira el archivo [LICENSE.md](LICENSE.md) para detalles

## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Invita una cerveza 🍺 o un café ☕ a alguien del equipo. 
* Da las gracias públicamente 🤓.
* etc.



---
⌨️ con ❤️ por [Villanuevand](https://github.com/Villanuevand) 😊
