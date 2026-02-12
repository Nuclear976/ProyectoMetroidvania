# 🔧 Assembly Definitions y Namespaces

## Organización del Código

El proyecto usa **Assembly Definitions** (.asmdef) para organizar el código en módulos y mejorar los tiempos de compilación.

---

## 📦 Assemblies Definidos

### SombrasDelUmbral.Core
**Ubicación:** `Assets/Scripts/Core/`  
**Namespace:** `SombrasDelUmbral.Core`  
**Dependencias:** Ninguna  
**Propósito:** Sistemas fundamentales del juego

**Contenido:**
- GameManager
- EventManager
- SaveSystem
- InputManager

### SombrasDelUmbral.Player
**Ubicación:** `Assets/Scripts/Player/`  
**Namespace:** `SombrasDelUmbral.Player`  
**Dependencias:** Core  
**Propósito:** Todo relacionado con el jugador

**Contenido:**
- PlayerController
- PlayerCombat
- PlayerHealth
- EnergySystem

### SombrasDelUmbral.AI
**Ubicación:** `Assets/Scripts/AI/`  
**Namespace:** `SombrasDelUmbral.AI`  
**Dependencias:** Core  
**Propósito:** Inteligencia artificial de enemigos

**Contenido:**
- AIController
- StateMachine
- Estados (IdleState, ChaseState, etc.)

### SombrasDelUmbral.World
**Ubicación:** `Assets/Scripts/World/`  
**Namespace:** `SombrasDelUmbral.World`  
**Dependencias:** Core  
**Propósito:** Elementos del mundo

**Contenido:**
- Checkpoint
- Door
- Hazard
- Interactables

### SombrasDelUmbral.UI
**Ubicación:** `Assets/Scripts/UI/`  
**Namespace:** `SombrasDelUmbral.UI`  
**Dependencias:** Core  
**Propósito:** Interfaz de usuario

**Contenido:**
- UIManager
- HealthBar
- EnergyBar
- MenuController

### SombrasDelUmbral.Utilities
**Ubicación:** `Assets/Scripts/Utilities/`  
**Namespace:** `SombrasDelUmbral.Utilities`  
**Dependencias:** Ninguna  
**Propósito:** Utilidades y helpers

**Contenido:**
- ObjectPool
- Extensions
- Constants
- Helpers

### SombrasDelUmbral.Editor
**Ubicación:** `Assets/Scripts/Editor/`  
**Namespace:** `SombrasDelUmbral.Editor`  
**Dependencias:** Core  
**Plataforma:** Solo Editor  
**Propósito:** Herramientas de desarrollo

**Contenido:**
- SceneSetupTool
- Otras herramientas de editor

---

## 💡 Beneficios de Assembly Definitions

1. **Compilación más rápida**: Unity solo recompila los assemblies modificados
2. **Mejor organización**: Código modular y bien estructurado
3. **Control de dependencias**: Evita dependencias circulares
4. **Namespace automático**: Unity sugiere el namespace correcto

---

## 🔗 Gráfico de Dependencias

```
Utilities (sin dependencias)
    ↑
Core (sin dependencias)
    ↑
    ├── Player
    ├── AI
    ├── World
    ├── UI
    └── Editor (solo Editor)
```

---

## 📝 Uso en Scripts

Cuando crees un nuevo script, Unity automáticamente sugerirá el namespace correcto según la carpeta:

```csharp
// En Assets/Scripts/Player/
namespace SombrasDelUmbral.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ...
    }
}

// En Assets/Scripts/AI/
namespace SombrasDelUmbral.AI
{
    public class EnemyController : MonoBehaviour
    {
        // ...
    }
}
```

---

## ⚠️ Notas Importantes

1. **No eliminar .asmdef**: Los archivos .asmdef son críticos para la organización
2. **Referencias**: Si un script no compila, verifica las referencias en el .asmdef
3. **Editor scripts**: Deben estar en carpeta `Editor/` con el .asmdef de Editor
4. **GUID**: Los GUIDs en las referencias se generan automáticamente

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
