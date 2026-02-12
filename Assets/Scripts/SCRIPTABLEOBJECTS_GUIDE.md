# 📦 ScriptableObjects - Guía de Uso

## Sistema de ScriptableObjects de Sombras del Umbral

Los ScriptableObjects se usan para almacenar datos de configuración reutilizables.

---

## 🏗️ Jerarquía de ScriptableObjects

```
GameDataSO (Base abstracta)
├── PlayerDataSO (Configuración del jugador)
├── EnemyDataSO (Configuración de enemigos)
├── ImplantSO (Implantes cibernéticos)
└── GameEventSO (Eventos del juego)
```

---

## 📋 GameDataSO (Base)

Clase base abstracta para todos los ScriptableObjects de datos.

**Propiedades comunes:**
- `ID` - Identificador único
- `DisplayName` - Nombre para mostrar
- `Description` - Descripción del dato

**Métodos:**
- `Validate()` - Valida los datos
- `Initialize()` - Inicializa el ScriptableObject

---

## 🎮 PlayerDataSO

Configuración completa del jugador.

### Crear PlayerDataSO

1. Click derecho: `Create > Sombras del Umbral > Player > Player Data`
2. Nombrar: `DefaultPlayerData`
3. Configurar parámetros en Inspector

### Parámetros

**Movement:**
- Move Speed, Sprint Multiplier
- Acceleration, Deceleration

**Jump:**
- Jump Force, Max Jumps
- Jump Buffer Time, Coyote Time

**Dash:**
- Dash Speed, Duration, Cooldown

**Combat:**
- Max Health, Attack Damage
- Attack Range, Attack Cooldown

**Energy:**
- Max Energy, Regen Rate, Regen Delay

### Uso en código

```csharp
using SombrasDelUmbral.Player;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    
    void Start()
    {
        float speed = playerData.MoveSpeed;
        int health = playerData.MaxHealth;
    }
}
```

---

## 👾 EnemyDataSO

Configuración de enemigos.

### Crear EnemyDataSO

1. Click derecho: `Create > Sombras del Umbral > AI > Enemy Data`
2. Nombrar según tipo: `EnemyMeleeData`, `EnemyRangedData`
3. Configurar stats y comportamiento

### Parámetros

**Stats:**
- Max Health, Move Speed
- Attack Damage, Range, Cooldown

**AI Behavior:**
- Detection Range, Chase Range
- Patrol Speed, Patrol Wait Time

**Rewards:**
- Experience Reward, Drop Chance

### Uso en código

```csharp
using SombrasDelUmbral.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyDataSO enemyData;
    
    void Start()
    {
        int health = enemyData.MaxHealth;
        float detectionRange = enemyData.DetectionRange;
    }
}
```

---

## 🔧 ImplantSO

Implantes cibernéticos que mejoran al jugador.

### Crear ImplantSO

1. Click derecho: `Create > Sombras del Umbral > Player > Implant`
2. Nombrar: `ImplantDoubleJump`, `ImplantDash`, etc.
3. Configurar tipo y modificadores

### Tipos de Implantes

- **Offensive** - Mejora combate
- **Defensive** - Mejora defensa
- **Mobility** - Mejora movimiento
- **Utility** - Utilidades varias

### Parámetros

**Stats Modifiers:**
- Health, Energy, Damage, Speed Modifiers

**Special Abilities:**
- Grants Double Jump
- Grants Wall Jump
- Grants Dash

**Energy Cost:**
- Costo de energía para usar

### Uso en código

```csharp
using SombrasDelUmbral.Player;

public class ImplantSystem : MonoBehaviour
{
    [SerializeField] private ImplantSO implant;
    
    public void EquipImplant()
    {
        if (implant.GrantsDoubleJump)
        {
            // Activar doble salto
        }
        
        float damageBonus = implant.DamageModifier;
    }
}
```

---

## 🎯 GameEventSO

Eventos basados en ScriptableObjects (ya documentado en EVENT_SYSTEM_GUIDE.md).

---

## 💡 Mejores Prácticas

### 1. Organización de Assets

```
Assets/ScriptableObjects/
├── Events/
│   ├── OnPlayerDeathEvent.asset
│   └── OnCheckpointReachedEvent.asset
├── Player/
│   ├── DefaultPlayerData.asset
│   └── Implants/
│       ├── ImplantDoubleJump.asset
│       └── ImplantDash.asset
└── Enemies/
    ├── EnemyMeleeData.asset
    └── EnemyRangedData.asset
```

### 2. Nomenclatura

- Usar sufijo `SO` en clases: `PlayerDataSO`
- Usar nombres descriptivos en assets: `DefaultPlayerData`
- Agrupar por tipo en carpetas

### 3. Validación

Todos los ScriptableObjects heredan validación:

```csharp
public override bool Validate()
{
    if (!base.Validate())
        return false;
    
    // Validación específica
    if (moveSpeed <= 0)
    {
        Debug.LogError("MoveSpeed debe ser mayor que 0");
        return false;
    }
    
    return true;
}
```

### 4. Inicialización

Usar `Initialize()` para lógica de inicialización:

```csharp
public override void Initialize()
{
    base.Initialize();
    
    // Inicialización específica
    CalculateDerivedStats();
}
```

---

## 🔄 Crear Nuevos ScriptableObjects

### Template para nuevo ScriptableObject

```csharp
using UnityEngine;

namespace SombrasDelUmbral.YourNamespace
{
    [CreateAssetMenu(fileName = "NewDataSO", menuName = "Sombras del Umbral/Category/New Data")]
    public class NewDataSO : Core.GameDataSO
    {
        [Header("Custom Data")]
        [SerializeField] private float customValue;
        
        public float CustomValue => customValue;
        
        public override bool Validate()
        {
            if (!base.Validate())
                return false;
            
            // Validación específica
            
            return true;
        }
    }
}
```

---

## ⚠️ Notas Importantes

1. **Siempre heredar de GameDataSO**: Para tener funcionalidad común
2. **Usar [CreateAssetMenu]**: Para crear desde el menú contextual
3. **Propiedades de solo lectura**: Usar `=>` para exponer datos
4. **Validar en OnValidate**: Se ejecuta automáticamente en el Editor
5. **No modificar en runtime**: Los ScriptableObjects son assets, no instancias

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
