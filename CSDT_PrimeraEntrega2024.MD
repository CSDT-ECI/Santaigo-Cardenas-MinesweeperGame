# SonarCloud

Haciendo uso de la aplicacion virtual de sonarCloud sobre el codigo base de MinesweeperGame se encontro lo siguiente a un nivel general.

![alt text](assets/image.png)

## Medidas

Se puede observar que, realmente el proyecto, al ser tan pequeño no tiene realmente problemas graves, ya que por un lado no maneja información sensible, tampoco se detectaron bugs. Sin embargo, a nivel de la mantenibilidad del código encontramos ciertas mejoras que sonarCloud detectó.

![alt text](assets/image2.png)

## Problemas

Como se puede observar sonarCloud detectó un porcentaje del 1.6% de deuda técnica en las clases principales y 15 codeSmells.
Analizando los issues que detecta el programa nos encontramos con los ya antes mencionados en el archvio 'CSDT-2024.md'.

![alt text](assets/image3.png)

Sin embargo, todos siguen siendo problemas de mantenibilidad y la mayoría se encuentran en un sector medio de impacto.

## Seguridad

El código, al no tener peticiones reales con la Web y no requerir conexión con internet no tiene realmente vulnerabilidades de seguridad ya que no llega a ser atractivo para un atacante es por esto que para esta sección queda vacía.

## Conclusión

En resumen, el código es de un juego pequeño, que por el tiempo que lleva se notan diferentes malas prácticas que a tenido a lo largo de los años, sin embargo no llegan a ser críticas ni mucho menos, la aplicación es totalmente funcional. Puede que con todo lo expuesto en los archivos ".md" se pueda mejorar el rendimiento del juego o incluso el entendimiento del mismo ya que de cara al usuario llegar a ser algo complejo y en un futuro pensar en cómo escalarlo a nivel de aplicación web para darle un poco más de complejidad y dinamismo. 