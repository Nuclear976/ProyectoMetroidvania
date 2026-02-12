# 📁 Estructura de Carpetas del Proyecto

## Sombras del Umbral - Organización de Assets

Esta es la estructura de carpetas del proyecto según el ROADMAP.md (Tarea 1.1.2):

```
Assets/
├── Scenes/              # Escenas del juego (MainMenu, GameScene, etc.)
├── Scripts/             # Todos los scripts C#
│   ├── Core/           # Sistemas core (GameManager, EventManager, etc.)
│   ├── Player/         # Scripts del jugador (PlayerController, PlayerCombat, etc.)
│   ├── AI/             # Inteligencia artificial de enemigos
│   ├── World/          # Scripts del mundo (Checkpoints, Doors, etc.)
│   ├── UI/             # Scripts de interfaz de usuario
│   ├── Utilities/      # Scripts de utilidades y helpers
│   └── Editor/         # Scripts de Unity Editor (herramientas de desarrollo)
├── Prefabs/            # Prefabs reutilizables
├── ScriptableObjects/  # ScriptableObjects (datos, configuraciones)
├── Sprites/            # Sprites y texturas 2D
├── Animations/         # Animaciones y Animator Controllers
├── Audio/              # Música y efectos de sonido
├── Materials/          # Materiales 2D
└── Tilemaps/           # Tilesets y Tile Palettes
```

---

## 📝 Convenciones de Nomenclatura

### Scripts (C#)
- **PascalCase** para nombres de archivos y clases: `PlayerController.cs`
- **camelCase** para variables y métodos privados: `moveSpeed`, `jumpForce`
- **PascalCase** para métodos públicos: `TakeDamage()`, `ApplyKnockback()`

### Namespaces
Todos los scripts deben usar namespaces organizados:
```csharp
namespace SombrasDelUmbral.Player { }
namespace SombrasDelUmbral.AI { }
namespace SombrasDelUmbral.Core { }
namespace SombrasDelUmbral.UI { }
namespace SombrasDelUmbral.World { }
namespace SombrasDelUmbral.Utilities { }
```

### Assets
- **PascalCase** para prefabs: `PlayerPrefab`, `EnemyMelee`
- **snake_case** para sprites: `player_idle_01`, `enemy_walk_02`
- **PascalCase** para ScriptableObjects: `PlayerDataSO`, `EnemyConfigSO`

---

## 🎯 Uso de Carpetas

### Scripts/Core/
Sistemas fundamentales del juego:
- `GameManager.cs` - Gestión global del juego
- `EventManager.cs` - Sistema de eventos
- `SaveSystem.cs` - Sistema de guardado
- `InputManager.cs` - Gestión de input

### Scripts/Player/
Todo relacionado con el jugador:
- `PlayerController.cs` - Movimiento
- `PlayerCombat.cs` - Sistema de combate
- `PlayerHealth.cs` - Sistema de vida
- `EnergySystem.cs` - Sistema de energía

### Scripts/AI/
Inteligencia artificial:
- `AIController.cs` - Controlador base de IA
- `StateMachine.cs` - Máquina de estados
- Estados específicos (IdleState, ChaseState, etc.)

### Scripts/World/
Elementos del mundo:
- `Checkpoint.cs` - Puntos de guardado
- `Door.cs` - Puertas y gates
- `Hazard.cs` - Trampas y peligros

### Scripts/UI/
Interfaz de usuario:
- `UIManager.cs` - Gestión de UI
- `HealthBar.cs` - Barra de vida
- `EnergyBar.cs` - Barra de energía

### Scripts/Utilities/
Utilidades y helpers:
- `ObjectPool.cs` - Object pooling
- `Extensions.cs` - Extension methods
- `Constants.cs` - Constantes globales

---

## ⚠️ Notas Importantes

1. **No modificar carpetas de Unity**: `Settings`, `TextMesh Pro` son generadas por Unity
2. **Editor scripts**: Siempre en `Scripts/Editor/` para que Unity los compile correctamente
3. **Resources**: Evitar usar la carpeta `Resources/` (usar Addressables en su lugar)
4. **Organización**: Mantener esta estructura durante todo el desarrollo

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
