# 📝 Script Templates - Guía de Uso

## Templates Disponibles

El proyecto incluye templates estándar para crear scripts con la estructura correcta.

---

## 📋 MonoBehaviour Template

**Ubicación:** `Assets/Scripts/ScriptTemplates/MonoBehaviourTemplate.cs.txt`

**Estructura:**
- Namespace correcto
- XML documentation
- Regions organizados
- Serialized Fields con Headers
- Properties públicas
- Unity Lifecycle methods
- Métodos privados y públicos separados

**Placeholders:**
- `#NAMESPACE#` - Reemplazar con namespace correcto
- `#SCRIPTNAME#` - Reemplazar con nombre de la clase
- `#DESCRIPTION#` - Reemplazar con descripción

**Ejemplo de uso:**
```csharp
using UnityEngine;

namespace SombrasDelUmbral.Player
{
    /// <summary>
    /// Controla el movimiento del jugador.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Serialized Fields
        
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        
        #endregion
        
        // ... resto del código
    }
}
```

---

## 📦 ScriptableObject Template

**Ubicación:** `Assets/Scripts/ScriptTemplates/ScriptableObjectTemplate.cs.txt`

**Estructura:**
- Namespace correcto
- CreateAssetMenu attribute
- Propiedades base (ID, DisplayName, Description)
- Validación automática
- OnValidate para Editor

**Placeholders:**
- `#NAMESPACE#` - Reemplazar con namespace correcto
- `#SCRIPTNAME#` - Reemplazar con nombre de la clase
- `#DESCRIPTION#` - Reemplazar con descripción
- `#CATEGORY#` - Reemplazar con categoría del menú

**Ejemplo de uso:**
```csharp
using UnityEngine;

namespace SombrasDelUmbral.Player
{
    /// <summary>
    /// Datos de configuración de arma.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Sombras del Umbral/Player/Weapon Data")]
    public class WeaponDataSO : ScriptableObject
    {
        // ... código
    }
}
```

---

## 🔧 Cómo Usar los Templates

### Opción 1: Copiar y Pegar (Manual)

1. Abrir el template correspondiente
2. Copiar todo el contenido
3. Crear nuevo script en Unity
4. Pegar contenido
5. Reemplazar placeholders (`#NAMESPACE#`, `#SCRIPTNAME#`, etc.)

### Opción 2: Unity Script Templates (Recomendado)

Para que Unity use estos templates automáticamente:

1. Ir a la carpeta de instalación de Unity:
   ```
   C:\Program Files\Unity\Hub\Editor\[VERSION]\Editor\Data\Resources\ScriptTemplates\
   ```

2. Copiar los templates a esa carpeta con nombres específicos:
   - `81-C# Script-NewBehaviourScript.cs.txt` (MonoBehaviour)
   - `82-C# ScriptableObject-NewScriptableObject.cs.txt` (ScriptableObject)

3. Reiniciar Unity

4. Ahora al crear scripts desde `Create > C# Script`, usará el template

---

## 📐 Regions Estándar

### MonoBehaviour
```csharp
#region Serialized Fields
#region Private Fields
#region Public Properties
#region Unity Lifecycle
#region Private Methods
#region Public Methods
```

### ScriptableObject
```csharp
#region Serialized Fields
#region Public Properties
#region Validation
```

---

## ✅ Checklist de Nuevo Script

Cuando crees un nuevo script, verifica:

- [ ] Namespace correcto según carpeta
- [ ] XML documentation (`/// <summary>`)
- [ ] Regions organizados
- [ ] SerializeField con [Header]
- [ ] Properties públicas con get/private set
- [ ] Métodos privados documentados si son complejos
- [ ] Validación en ScriptableObjects

---

## 💡 Ejemplos Completos

### Ejemplo: Enemy Controller

```csharp
using UnityEngine;
using SombrasDelUmbral.Core;

namespace SombrasDelUmbral.AI
{
    /// <summary>
    /// Controlador base para enemigos.
    /// Gestiona movimiento, combate y comportamiento IA.
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        #region Serialized Fields
        
        [Header("Configuration")]
        [SerializeField] private EnemyDataSO enemyData;
        
        [Header("Components")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        
        #endregion
        
        #region Private Fields
        
        private int currentHealth;
        private bool isDead;
        
        #endregion
        
        #region Public Properties
        
        public bool IsDead => isDead;
        public int CurrentHealth => currentHealth;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Awake()
        {
            Initialize();
        }
        
        private void Update()
        {
            if (isDead) return;
            
            UpdateBehavior();
        }
        
        #endregion
        
        #region Private Methods
        
        private void Initialize()
        {
            currentHealth = enemyData.MaxHealth;
        }
        
        private void UpdateBehavior()
        {
            // Lógica de IA
        }
        
        #endregion
        
        #region Public Methods
        
        public void TakeDamage(int damage)
        {
            if (isDead) return;
            
            currentHealth -= damage;
            
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            isDead = true;
            EventManager.TriggerEvent(GameEvents.ENEMY_KILLED);
        }
        
        #endregion
    }
}
```

### Ejemplo: Weapon Data SO

```csharp
using UnityEngine;

namespace SombrasDelUmbral.Player
{
    /// <summary>
    /// Datos de configuración de un arma.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Sombras del Umbral/Player/Weapon Data")]
    public class WeaponDataSO : ScriptableObject
    {
        #region Serialized Fields
        
        [Header("Base Data")]
        [SerializeField] private string id;
        [SerializeField] private string displayName;
        [SerializeField] private Sprite icon;
        
        [Header("Stats")]
        [SerializeField] private float damage = 25f;
        [SerializeField] private float attackSpeed = 1f;
        [SerializeField] private float range = 1.5f;
        
        #endregion
        
        #region Public Properties
        
        public string ID => id;
        public string DisplayName => displayName;
        public Sprite Icon => icon;
        public float Damage => damage;
        public float AttackSpeed => attackSpeed;
        public float Range => range;
        
        #endregion
        
        #region Validation
        
        public bool Validate()
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogError($"[{name}] ID cannot be empty", this);
                return false;
            }
            
            if (damage <= 0)
            {
                Debug.LogError($"[{name}] Damage must be greater than 0", this);
                return false;
            }
            
            return true;
        }
        
        #endregion
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(id))
            {
                id = name;
            }
            
            Validate();
        }
#endif
    }
}
```

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
