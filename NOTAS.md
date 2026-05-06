## 05/05 - Coty

### Lo que se hizo hoy:
- Configuré el proyecto Unity 6.3 (2D), lo subí al repo con .gitignore correcto.
- Importé todos los sprites (frutas, canasta, fondo, corazones, bomba, Game Over).
- Agregué el fondo a la escena.
- Creé BasketController.cs: movimiento horizontal con límites de pantalla.
  - Tuvimos que cambiar Active Input Handling a "Both" en Project Settings > Player.
- Creé FruitFall.cs: fruta que cae y se destruye al llegar a cierta altura.
  - Tiene lógica de "atrapada" (caughtDestroyY) vs "no atrapada" (destroyY).
- Creé FruitSpawner.cs: genera frutas en posiciones aleatorias con Coroutine.
- Creé BasketCollector.cs: detecta colisión con frutas usando OnTriggerEnter2D.
- Creé LifeSystem.cs: 3 vidas con corazones en UI, muestra Game Over al llegar a 0.
- Archivos: BasketController.cs, FruitFall.cs, FruitSpawner.cs, BasketCollector.cs, LifeSystem.cs

### Lo que falta para completar el core loop:
- Puntaje: sumar puntos al atrapar frutas, mostrarlo en pantalla, guardar el high score.
- Bomba: si la canasta agarra una bomba, Game Over instantáneo.
- Dificultad progresiva: con el tiempo, las frutas caen más rápido y aparecen más seguido.
- Menú principal con botón de Start.
- Botón de reinicio en la pantalla de Game Over.