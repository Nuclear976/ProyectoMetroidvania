# 🎯 Event System - Guía de Uso

## Sistema de Eventos de Sombras del Umbral

El proyecto usa **dos sistemas de eventos** complementarios:

1. **EventManager** - Eventos basados en código (UnityEvents)
2. **GameEventSO** - Eventos basados en ScriptableObjects

---

## 📋 EventManager (Código)

### Uso Básico

#### Suscribirse a un evento (sin parámetros)
```csharp
using SombrasDelUmbral.Core;

void OnEnable()
{
    EventManager.StartListening(GameEvents.PLAYER_DEATH, OnPlayerDeath);
}

void OnDisable()
{
    EventManager.StopListening(GameEvents.PLAYER_DEATH, OnPlayerDeath);
}

void OnPlayerDeath()
{
    Debug.Log("¡El jugador ha muerto!");
}
```

#### Disparar un evento
```csharp
EventManager.TriggerEvent(GameEvents.PLAYER_DEATH);
```

#### Eventos con parámetros
```csharp
// Suscribirse
void OnEnable()
{
    EventManager.StartListening(GameEvents.PLAYER_DAMAGE_TAKEN, OnDamageTaken);
}

void OnDisable()
{
    EventManager.StopListening(GameEvents.PLAYER_DAMAGE_TAKEN, OnDamageTaken);
}

void OnDamageTaken(object param)
{
    float damage = (float)param;
    Debug.Log($"Daño recibido: {damage}");
}

// Disparar
EventManager.TriggerEvent(GameEvents.PLAYER_DAMAGE_TAKEN, 25f);
```

---

## 🎨 GameEventSO (ScriptableObjects)

### Crear un GameEvent

1. Click derecho en Project: `Create > Sombras del Umbral > Events > Game Event`
2. Nombrar el asset: `OnPlayerDeathEvent`
3. Guardar en `Assets/ScriptableObjects/Events/`

### Usar GameEventListener (Inspector)

1. Añadir componente `GameEventListener` a un GameObject
2. Asignar el `GameEventSO` en el campo "Event"
3. Configurar la respuesta en "Response" (UnityEvent)

### Disparar desde código

```csharp
using SombrasDelUmbral.Core;

[SerializeField] private GameEventSO onPlayerDeathEvent;

void Die()
{
    onPlayerDeathEvent.Raise();
}
```

---

## 🔄 ¿Cuándo usar cada sistema?

### EventManager (Código)
✅ **Usar cuando:**
- Necesitas pasar parámetros complejos
- El evento es temporal o dinámico
- Quieres control total desde código
- Necesitas eventos con múltiples parámetros

❌ **No usar cuando:**
- Quieres configurar desde el Inspector
- Necesitas reutilizar el evento en múltiples escenas

### GameEventSO (ScriptableObjects)
✅ **Usar cuando:**
- Quieres configurar desde el Inspector
- El evento se reutiliza en múltiples lugares
- Quieres desacoplar completamente los sistemas
- No necesitas pasar parámetros (o solo uno simple)

❌ **No usar cuando:**
- Necesitas pasar múltiples parámetros complejos
- El evento es muy específico y temporal

---

## 📝 Eventos Predefinidos

Ver `GameEvents.cs` para la lista completa:

```csharp
// Jugador
GameEvents.PLAYER_DEATH
GameEvents.PLAYER_RESPAWN
GameEvents.PLAYER_DAMAGE_TAKEN
GameEvents.PLAYER_HEALED

// Combate
GameEvents.ENEMY_KILLED
GameEvents.BOSS_DEFEATED

// Progresión
GameEvents.CHECKPOINT_REACHED
GameEvents.ABILITY_UNLOCKED
GameEvents.IMPLANT_EQUIPPED

// UI
GameEvents.GAME_PAUSED
GameEvents.GAME_RESUMED

// Mundo
GameEvents.DOOR_OPENED
GameEvents.AREA_ENTERED
GameEvents.ITEM_COLLECTED
```

---

## 💡 Ejemplos Completos

### Ejemplo 1: Sistema de Vida del Jugador

```csharp
using UnityEngine;
using SombrasDelUmbral.Core;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameEventSO onPlayerDeathEvent; // ScriptableObject
    
    private int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= (int)damage;
        
        // Disparar evento con parámetro (EventManager)
        EventManager.TriggerEvent(GameEvents.PLAYER_DAMAGE_TAKEN, damage);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Disparar evento sin parámetro (EventManager)
        EventManager.TriggerEvent(GameEvents.PLAYER_DEATH);
        
        // Disparar evento ScriptableObject
        onPlayerDeathEvent?.Raise();
    }
}
```

### Ejemplo 2: UI que escucha eventos

```csharp
using UnityEngine;
using UnityEngine.UI;
using SombrasDelUmbral.Core;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    
    void OnEnable()
    {
        EventManager.StartListening(GameEvents.PLAYER_DAMAGE_TAKEN, OnDamageTaken);
        EventManager.StartListening(GameEvents.PLAYER_HEALED, OnHealed);
    }
    
    void OnDisable()
    {
        EventManager.StopListening(GameEvents.PLAYER_DAMAGE_TAKEN, OnDamageTaken);
        EventManager.StopListening(GameEvents.PLAYER_HEALED, OnHealed);
    }
    
    void OnDamageTaken(object param)
    {
        UpdateHealthBar();
    }
    
    void OnHealed(object param)
    {
        UpdateHealthBar();
    }
    
    void UpdateHealthBar()
    {
        // Actualizar slider
    }
}
```

### Ejemplo 3: Checkpoint con GameEventSO

```csharp
using UnityEngine;
using SombrasDelUmbral.Core;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameEventSO onCheckpointReachedEvent;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento ScriptableObject
            onCheckpointReachedEvent?.Raise();
            
            // También disparar evento de código
            EventManager.TriggerEvent(GameEvents.CHECKPOINT_REACHED);
        }
    }
}
```

---

## ⚠️ Buenas Prácticas

1. **Siempre desuscribirse**: Usar `OnEnable`/`OnDisable` para suscribirse/desuscribirse
2. **Usar constantes**: Usar `GameEvents` en lugar de strings literales
3. **No abusar**: No usar eventos para todo, a veces una referencia directa es mejor
4. **Documentar**: Documentar qué eventos dispara cada sistema
5. **Limpiar**: Llamar `EventManager.ClearAllEvents()` al cambiar de escena si es necesario

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
