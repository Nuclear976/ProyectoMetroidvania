# 📝 Convenciones de Nomenclatura - Sombras del Umbral

## Guía de Estilo de Código

Basado en ROADMAP.md - Tarea 1.1.2, línea 86

---

## 🔤 Nomenclatura de Scripts y Clases

### Scripts C# (Archivos)
- **PascalCase** para nombres de archivos
- El nombre del archivo debe coincidir con el nombre de la clase principal

```csharp
✅ Correcto:
PlayerController.cs
EnemyAI.cs
GameManager.cs
HealthSystem.cs

❌ Incorrecto:
playerController.cs
enemy_ai.cs
gamemanager.cs
health-system.cs
```

### Clases, Structs, Interfaces
- **PascalCase** para todos los tipos

```csharp
✅ Correcto:
public class PlayerController { }
public struct PlayerData { }
public interface IDamageable { }
public enum GameState { }

❌ Incorrecto:
public class playerController { }
public struct player_data { }
public interface iDamageable { }
```

### Interfaces
- Prefijo `I` seguido de PascalCase

```csharp
✅ Correcto:
public interface IDamageable { }
public interface IInteractable { }
public interface IPoolable { }

❌ Incorrecto:
public interface Damageable { }
public interface interactable { }
```

---

## 🔤 Nomenclatura de Variables y Métodos

### Variables Privadas
- **camelCase** para variables privadas
- Sin prefijos (no usar `_` o `m_`)

```csharp
✅ Correcto:
private float moveSpeed;
private int currentHealth;
private bool isGrounded;
private Vector2 velocity;

❌ Incorrecto:
private float MoveSpeed;
private int _currentHealth;
private bool m_isGrounded;
```

### Variables Públicas y Propiedades
- **PascalCase** para campos públicos y propiedades

```csharp
✅ Correcto:
public float MaxHealth { get; private set; }
public int Score;
public bool IsAlive { get; set; }

❌ Incorrecto:
public float maxHealth;
public int score;
public bool isAlive;
```

### Variables Locales y Parámetros
- **camelCase** para variables locales y parámetros

```csharp
✅ Correcto:
void TakeDamage(float damageAmount)
{
    float finalDamage = damageAmount * defenseMultiplier;
    int healthBefore = currentHealth;
}

❌ Incorrecto:
void TakeDamage(float DamageAmount)
{
    float FinalDamage = DamageAmount * DefenseMultiplier;
}
```

### Constantes
- **PascalCase** o **UPPER_SNAKE_CASE** (preferir PascalCase)

```csharp
✅ Correcto (preferido):
private const float MaxSpeed = 10f;
private const int MaxJumps = 2;

✅ Correcto (alternativo):
private const float MAX_SPEED = 10f;
private const int MAX_JUMPS = 2;

❌ Incorrecto:
private const float maxSpeed = 10f;
```

### Métodos
- **PascalCase** para todos los métodos (públicos y privados)

```csharp
✅ Correcto:
public void TakeDamage(float amount) { }
private void CalculateVelocity() { }
protected void OnDeath() { }

❌ Incorrecto:
public void takeDamage(float amount) { }
private void calculate_velocity() { }
```

---

## 🎯 Nomenclatura de Unity Específico

### Eventos de Unity
- Usar nombres estándar de Unity tal cual

```csharp
✅ Correcto:
void Awake() { }
void Start() { }
void Update() { }
void FixedUpdate() { }
void OnCollisionEnter2D(Collision2D collision) { }
void OnTriggerEnter2D(Collider2D other) { }
```

### SerializeField
- **camelCase** para campos privados serializados

```csharp
✅ Correcto:
[SerializeField] private float moveSpeed = 5f;
[SerializeField] private int maxHealth = 100;
[SerializeField] private GameObject bulletPrefab;

❌ Incorrecto:
[SerializeField] private float MoveSpeed = 5f;
[SerializeField] private int _maxHealth = 100;
```

### ScriptableObjects
- Sufijo `SO` o `Data` en el nombre de la clase
- Archivos con sufijo `SO`

```csharp
✅ Correcto:
public class PlayerDataSO : ScriptableObject { }
public class EnemyConfigSO : ScriptableObject { }
public class ImplantSO : ScriptableObject { }

Archivos:
PlayerDataSO.cs
EnemyConfigSO.cs
```

---

## 📦 Nomenclatura de Assets

### Prefabs
- **PascalCase** con sufijo descriptivo opcional

```
✅ Correcto:
PlayerPrefab.prefab
EnemyMelee.prefab
BulletProjectile.prefab
CheckpointMarker.prefab

❌ Incorrecto:
player_prefab.prefab
enemy-melee.prefab
bullet.prefab
```

### Sprites
- **snake_case** con prefijo de categoría

```
✅ Correcto:
player_idle_01.png
player_run_02.png
enemy_melee_attack_03.png
ui_button_normal.png

❌ Incorrecto:
PlayerIdle01.png
player-run-02.png
EnemyMeleeAttack03.png
```

### Animaciones
- **PascalCase** con nombre descriptivo

```
✅ Correcto:
PlayerIdle.anim
PlayerRun.anim
EnemyAttack.anim
DoorOpen.anim

❌ Incorrecto:
player_idle.anim
player-run.anim
enemy_attack.anim
```

### Animator Controllers
- **PascalCase** con sufijo `Animator`

```
✅ Correcto:
PlayerAnimator.controller
EnemyMeleeAnimator.controller
BossAnimator.controller

❌ Incorrecto:
player_animator.controller
enemy-animator.controller
```

### Audio
- **snake_case** con prefijo de tipo

```
✅ Correcto:
sfx_jump.wav
sfx_attack_slash.wav
music_boss_theme.ogg
ambient_forest.ogg

❌ Incorrecto:
Jump.wav
AttackSlash.wav
BossTheme.ogg
```

### Scenes
- **PascalCase** descriptivo

```
✅ Correcto:
MainMenu.unity
GameScene.unity
BosquesCorrutos.unity
LaboratorioAbandonado.unity

❌ Incorrecto:
main_menu.unity
game-scene.unity
bosques_corrutos.unity
```

---

## 🏗️ Namespaces

### Estructura de Namespaces
- Usar namespaces organizados por módulo
- Formato: `SombrasDelUmbral.<Módulo>`

```csharp
✅ Correcto:
namespace SombrasDelUmbral.Player
{
    public class PlayerController : MonoBehaviour { }
}

namespace SombrasDelUmbral.AI
{
    public class EnemyController : MonoBehaviour { }
}

namespace SombrasDelUmbral.Core
{
    public class GameManager : MonoBehaviour { }
}

namespace SombrasDelUmbral.UI
{
    public class HealthBar : MonoBehaviour { }
}
```

### Namespaces Disponibles
```
SombrasDelUmbral.Core        // GameManager, EventManager, SaveSystem
SombrasDelUmbral.Player      // PlayerController, PlayerCombat, PlayerHealth
SombrasDelUmbral.AI          // EnemyController, StateMachine, States
SombrasDelUmbral.World       // Checkpoint, Door, Hazard
SombrasDelUmbral.UI          // UIManager, HealthBar, EnergyBar
SombrasDelUmbral.Utilities   // Extensions, ObjectPool, Constants
SombrasDelUmbral.Editor      // Editor tools (no namespace en runtime)
```

---

## 💡 Ejemplos Completos

### Script de Player
```csharp
using UnityEngine;

namespace SombrasDelUmbral.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Constantes
        private const float MaxSpeed = 10f;
        
        // Campos serializados (Inspector)
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 12f;
        
        // Campos privados
        private Rigidbody2D rb;
        private bool isGrounded;
        private Vector2 velocity;
        
        // Propiedades públicas
        public bool IsMoving { get; private set; }
        public float CurrentSpeed { get; private set; }
        
        // Eventos de Unity
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            HandleInput();
        }
        
        private void FixedUpdate()
        {
            ApplyMovement();
        }
        
        // Métodos privados
        private void HandleInput()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            velocity.x = horizontalInput * moveSpeed;
        }
        
        private void ApplyMovement()
        {
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);
            CurrentSpeed = Mathf.Abs(rb.velocity.x);
            IsMoving = CurrentSpeed > 0.1f;
        }
        
        // Métodos públicos
        public void Jump()
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        
        public void TakeDamage(float damageAmount)
        {
            // Implementación
        }
    }
}
```

### ScriptableObject
```csharp
using UnityEngine;

namespace SombrasDelUmbral.Player
{
    [CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Sombras del Umbral/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("Movement")]
        public float MoveSpeed = 5f;
        public float JumpForce = 12f;
        public float DashSpeed = 15f;
        
        [Header("Combat")]
        public int MaxHealth = 100;
        public float AttackDamage = 25f;
        
        [Header("Energy")]
        public float MaxEnergy = 100f;
        public float EnergyRegenRate = 10f;
    }
}
```

---

## ✅ Checklist de Revisión

Antes de hacer commit, verifica:

- [ ] Nombres de archivos en PascalCase
- [ ] Variables privadas en camelCase
- [ ] Métodos en PascalCase
- [ ] Propiedades públicas en PascalCase
- [ ] Interfaces con prefijo `I`
- [ ] ScriptableObjects con sufijo `SO`
- [ ] Namespaces correctos
- [ ] Sprites en snake_case
- [ ] Audio con prefijos (sfx_, music_, ambient_)

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
