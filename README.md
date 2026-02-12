# 🎮 Sombras del Umbral

**Género:** Metroidvania 2D  
**Motor:** Unity 6000.1.13f1  
**Plataforma:** PC (Steam Deck compatible)

---

## 📋 Descripción

Metroidvania 2D ambientado en un mundo cyberpunk oscuro donde exploras, combates y desbloqueas habilidades mediante implantes cibernéticos.

---

## 🏗️ Arquitectura del Proyecto

### Estructura de Carpetas

```
Assets/
├── Scenes/              # Escenas del juego
├── Scripts/             # Código C#
│   ├── Core/           # Sistemas fundamentales (GameManager, EventManager)
│   ├── Player/         # Jugador (Controller, Combat, Health)
│   ├── AI/             # Inteligencia artificial de enemigos
│   ├── World/          # Elementos del mundo (Checkpoints, Doors)
│   ├── UI/             # Interfaz de usuario
│   ├── Utilities/      # Utilidades y helpers
│   └── Editor/         # Herramientas de desarrollo
├── Prefabs/            # Prefabs reutilizables
├── ScriptableObjects/  # Datos de configuración
├── Sprites/            # Sprites y texturas 2D
├── Animations/         # Animaciones y Animator Controllers
├── Audio/              # Música y efectos de sonido
├── Materials/          # Materiales 2D
├── Tilemaps/           # Tilesets y Tile Palettes
└── Resources/          # Assets dinámicos (usar con moderación)
```

### Assembly Definitions

El proyecto usa Assembly Definitions para modularidad y compilación rápida:

- `SombrasDelUmbral.Core` - Sistemas fundamentales
- `SombrasDelUmbral.Player` - Todo del jugador
- `SombrasDelUmbral.AI` - Inteligencia artificial
- `SombrasDelUmbral.World` - Elementos del mundo
- `SombrasDelUmbral.UI` - Interfaz de usuario
- `SombrasDelUmbral.Utilities` - Utilidades
- `SombrasDelUmbral.Editor` - Herramientas de editor

---

## 🎯 Sistemas Core

### GameManager
Singleton que gestiona el estado global del juego.

**Ubicación:** `Assets/Scripts/Core/GameManager.cs`

**Funcionalidades:**
- Pausa/Reanudación del juego
- Reinicio de escenas
- Persistencia entre escenas (DontDestroyOnLoad)

**Uso:**
```csharp
GameManager.Instance.PauseGame();
GameManager.Instance.ResumeGame();
```

### EventManager
Sistema de eventos desacoplado usando UnityEvents.

**Ubicación:** `Assets/Scripts/Core/EventManager.cs`

**Funcionalidades:**
- Eventos sin parámetros
- Eventos con parámetros
- Comunicación desacoplada entre sistemas

**Uso:**
```csharp
// Suscribirse
EventManager.StartListening(GameEvents.PLAYER_DEATH, OnPlayerDeath);

// Disparar
EventManager.TriggerEvent(GameEvents.PLAYER_DEATH);

// Desuscribirse
EventManager.StopListening(GameEvents.PLAYER_DEATH, OnPlayerDeath);
```

### ScriptableObject Events
Sistema de eventos basado en ScriptableObjects para configuración desde Inspector.

**Ubicación:** `Assets/Scripts/Core/GameEventSO.cs`

**Componentes:**
- `GameEventSO` - ScriptableObject de evento
- `GameEventListener` - Componente para escuchar eventos

---

## 📦 ScriptableObjects

### GameDataSO (Base)
Clase base abstracta para todos los datos de juego.

**Propiedades:**
- ID, DisplayName, Description
- Validación automática
- Inicialización

### PlayerDataSO
Configuración completa del jugador.

**Parámetros:**
- Movement (speed, acceleration, sprint)
- Jump (force, max jumps, coyote time)
- Dash (speed, duration, cooldown)
- Combat (health, damage, range)
- Energy (max, regen rate)

### EnemyDataSO
Configuración de enemigos.

**Parámetros:**
- Stats (health, speed, damage)
- AI Behavior (detection, chase, patrol)
- Rewards (experience, drop chance)

### ImplantSO
Implantes cibernéticos que mejoran al jugador.

**Tipos:**
- Offensive, Defensive, Mobility, Utility

**Modificadores:**
- Stats (health, energy, damage, speed)
- Habilidades especiales (double jump, wall jump, dash)

---

## 🎨 Convenciones de Nomenclatura

### Scripts (C#)
- **PascalCase** para clases, métodos, propiedades públicas
- **camelCase** para variables privadas, parámetros
- **Interfaces:** Prefijo `I` (IDamageable)
- **ScriptableObjects:** Sufijo `SO` (PlayerDataSO)

### Namespaces
```csharp
SombrasDelUmbral.Core
SombrasDelUmbral.Player
SombrasDelUmbral.AI
SombrasDelUmbral.World
SombrasDelUmbral.UI
SombrasDelUmbral.Utilities
```

### Assets
- **Prefabs:** PascalCase (PlayerPrefab, EnemyMelee)
- **Sprites:** snake_case (player_idle_01, enemy_run_02)
- **Audio:** snake_case con prefijo (sfx_jump, music_boss_theme)
- **Scenes:** PascalCase (MainMenu, GameScene)

---

## ⚙️ Configuración del Proyecto

### Physics 2D
- Gravity: -25 (plataformas responsivas)
- Velocity Iterations: 8
- Position Iterations: 3
- Queries Hit Triggers: ON

### Layers
- Ground, Wall, Player, Enemy, Hazard
- PlayerAttack, EnemyAttack, Pickup, Trigger, Invulnerable

### Build Settings
- Resolución: 1920x1080
- Fullscreen Window
- Aspect ratios: 16:9, 16:10 (Steam Deck), 21:9 (ultrawide)

---

## 🛠️ Herramientas de Desarrollo

### SceneSetupTool
Crea escenas base (MainMenu, GameScene) automáticamente.

**Ubicación:** `Sombras del Umbral > Setup > Create Base Scenes`

---

## 📚 Documentación Adicional

- [NAMING_CONVENTIONS.md](Assets/NAMING_CONVENTIONS.md) - Guía de estilo de código
- [FOLDER_STRUCTURE.md](Assets/FOLDER_STRUCTURE.md) - Organización de carpetas
- [ASSEMBLY_DEFINITIONS.md](Assets/Scripts/ASSEMBLY_DEFINITIONS.md) - Assembly Definitions
- [EVENT_SYSTEM_GUIDE.md](Assets/Scripts/Core/EVENT_SYSTEM_GUIDE.md) - Sistema de eventos
- [SCRIPTABLEOBJECTS_GUIDE.md](Assets/Scripts/SCRIPTABLEOBJECTS_GUIDE.md) - ScriptableObjects
- [ADDRESSABLES_GUIDE.md](Assets/ADDRESSABLES_GUIDE.md) - Addressables (opcional)
- [ROADMAP.md](ROADMAP.md) - Roadmap técnico completo
- [SETUP_GUIDE.md](SETUP_GUIDE.md) - Guía de configuración

---

## 🚀 Inicio Rápido

### Requisitos
- Unity 6000.1.13f1
- Git (para control de versiones)

### Configuración Inicial
1. Abrir proyecto en Unity
2. Esperar a que compile (primera vez puede tardar)
3. Verificar que no hay errores de compilación
4. Abrir escena `MainMenu` en `Assets/Scenes/`

### Crear Assets
- **Player Data:** `Create > Sombras del Umbral > Player > Player Data`
- **Enemy Data:** `Create > Sombras del Umbral > AI > Enemy Data`
- **Implant:** `Create > Sombras del Umbral > Player > Implant`
- **Game Event:** `Create > Sombras del Umbral > Events > Game Event`

---

## 🎯 Próximos Pasos

Ver [ROADMAP.md](ROADMAP.md) para el plan de desarrollo completo.

**Fase actual:** Arquitectura Base del Proyecto Unity (Tarea 1.1.2)

---

## 📝 Notas de Desarrollo

### Control de Versiones
- Usar Git con `.gitignore` para Unity
- Asset Serialization: Force Text (mejor para merge)
- Commits frecuentes con mensajes descriptivos

### Optimización
- Assembly Definitions para compilación rápida
- Resources solo para assets críticos
- Addressables para assets grandes (futuro)

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Estado:** En desarrollo - Arquitectura base completada
