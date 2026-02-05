# Roadmap Técnico: Sombras del Umbral
## Documento de Planificación de Desarrollo en Unity

---

## 📋 Visión General del Proyecto

### Información del Proyecto
- **Nombre:** Sombras del Umbral
- **Género:** Metroidvania 2D
- **Pilar Central:** Movilidad extrema y exploración no lineal
- **Engine:** Unity (2022.3 LTS o superior recomendado)
- **Alcance:** Juego comercial completo
- **Plataformas:** PC, Steam Deck, Consolas (opcional)

### Stack Técnico Unity
- **Rendering:** Universal Render Pipeline (URP) 2D
- **Physics:** Unity Physics 2D
- **Input:** New Input System
- **Animation:** 2D Animation + Animator Controller
- **Camera:** Cinemachine
- **Tilemap:** Unity Tilemap + Rule Tiles
- **Audio:** Unity Audio Mixer + FMOD (opcional)
- **Localization:** Unity Localization Package (opcional)

---

## 📊 Etapas de Desarrollo

### **ETAPA 1: Preproducción Técnica**
**Duración Estimada:** 2-4 semanas  
**Objetivo:** Establecer fundamentos técnicos y pipeline de desarrollo

---

#### **FASE 1.1: Setup de Unity y Arquitectura**

##### **Tarea 1.1.1: Configuración Inicial de Unity**
**Descripción:** Crear proyecto Unity y configurar packages esenciales

**Checklist:**
- [ ] Crear nuevo proyecto Unity 2D (URP Template)
- [ ] Configurar Unity 2022.3 LTS o superior
- [ ] Instalar **Universal Render Pipeline (URP)** 2D
- [ ] Instalar **New Input System** (Package Manager)
- [ ] Instalar **Cinemachine** (Package Manager)
- [ ] Instalar **2D Animation** package
- [ ] Instalar **2D Sprite** package
- [ ] Instalar **2D Tilemap Editor** package
- [ ] Configurar **TextMeshPro** (importar essentials)
- [ ] Configurar Project Settings (Physics 2D, Input, Quality)
- [ ] Establecer Target Platform (PC, Steam Deck)
- [ ] Configurar Build Settings (resolución, aspect ratio)
- [ ] Crear escena base (MainMenu, GameScene)

**Dependencias:** Ninguna  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1-2 días

---

##### **Tarea 1.1.2: Arquitectura Base del Proyecto Unity**
**Descripción:** Definir estructura de carpetas Unity y patrones de diseño

**Checklist:**
- [ ] Crear estructura de carpetas Unity:
  ```
  Assets/
  ├── _Project/
  │   ├── Scenes/
  │   ├── Scripts/
  │   │   ├── Core/
  │   │   ├── Player/
  │   │   ├── AI/
  │   │   ├── World/
  │   │   ├── UI/
  │   │   └── Utilities/
  │   ├── Prefabs/
  │   ├── ScriptableObjects/
  │   ├── Sprites/
  │   ├── Animations/
  │   ├── Audio/
  │   ├── Materials/
  │   └── Tilemaps/
  ```
- [ ] Definir convenciones de nomenclatura (PascalCase para scripts, camelCase para variables)
- [ ] Establecer namespaces: `SombrasDelUmbral.Player`, `SombrasDelUmbral.AI`, etc.
- [ ] Crear **GameManager** con singleton pattern (DontDestroyOnLoad)
- [ ] Crear **EventManager** para comunicación desacoplada (UnityEvents/ScriptableObject Events)
- [ ] Configurar **ScriptableObject** base para datos de juego
- [ ] Crear carpeta de **Resources** para assets dinámicos
- [ ] Configurar **Addressables** (opcional, para optimización)
- [ ] Documentar arquitectura en README.md
- [ ] Crear template de script con header estándar

**Dependencias:** Tarea 1.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2-3 días

---

##### **Tarea 1.1.3: Pipeline de Desarrollo Unity**
**Descripción:** Configurar control de versiones y herramientas Unity

**Checklist:**
- [ ] Inicializar repositorio Git con **.gitignore para Unity**
- [ ] Configurar **Git LFS** para assets grandes (.psd, .fbx, .wav, etc.)
- [ ] Configurar Unity para **Visible Meta Files** (Edit > Project Settings > Editor)
- [ ] Configurar **Asset Serialization** a "Force Text" (para mejor merge)
- [ ] Establecer branching strategy (GitFlow recomendado)
- [ ] Instalar **Unity Collaborate** o **Plastic SCM** (opcional, alternativa a Git)
- [ ] Configurar **Unity Cloud Build** o **GitHub Actions** para builds automáticas
- [ ] Instalar **JetBrains Rider** o **Visual Studio** con Unity Tools
- [ ] Configurar **Unity Test Framework** para unit tests
- [ ] Establecer sistema de tracking (GitHub Issues/Trello/Notion)
- [ ] Crear plantillas de documentación técnica
- [ ] Configurar backup automático (Unity Auto Save + Cloud backup)
- [ ] Instalar **Unity Performance Profiler** tools

**Dependencias:** Tarea 1.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2-3 días

---

#### **FASE 1.2: Vertical Slice Planning**

##### **Tarea 1.2.1: Definición del Vertical Slice**
**Descripción:** Planificar el prototipo jugable que demuestre el core loop

**Checklist:**
- [ ] Definir alcance: 1 área pequeña (5-10 min de juego)
- [ ] Listar mecánicas mínimas (correr, saltar, dash, combate básico)
- [ ] Diseñar layout de nivel en papel/Tiled
- [ ] Definir 2-3 tipos de enemigos básicos
- [ ] Planificar 1 mini-jefe como prueba de concepto
- [ ] Establecer métricas de éxito (feel del movimiento, engagement)
- [ ] Crear cronograma detallado del Vertical Slice
- [ ] Asignar responsabilidades si hay equipo

**Dependencias:** Tarea 1.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2-3 días

---

##### **Tarea 1.2.2: Arte y Audio Placeholder en Unity**
**Descripción:** Preparar assets temporales y configurar importación Unity

**Checklist:**
- [ ] Crear sprite placeholder del protagonista (4 frames walk cycle)
- [ ] Configurar **Sprite Import Settings** (Pixels Per Unit: 16 o 32, Filter Mode: Point)
- [ ] Crear **Sprite Atlas** para optimización de draw calls
- [ ] Diseñar tileset básico y configurar **Tile Palette**
- [ ] Generar sprites de enemigos placeholder
- [ ] Crear **Sprite Renderer** prefabs para personajes
- [ ] Preparar efectos visuales básicos con **Particle System**
- [ ] Configurar **Sorting Layers** (Background, Ground, Player, Enemies, Effects, UI)
- [ ] Buscar/crear SFX temporales (formato .wav o .ogg)
- [ ] Configurar **Audio Import Settings** (Load Type: Decompress On Load para SFX)
- [ ] Seleccionar música de ambiente (Load Type: Streaming)
- [ ] Crear **Audio Mixer** con buses (Master, Music, SFX, Ambient)
- [ ] Organizar assets en carpeta "_Prototype" separada
- [ ] Documentar fuentes de assets (Kenney.nl, OpenGameArt, etc.)

**Dependencias:** Tarea 1.2.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 3-5 días

---

### **ETAPA 2: Core Systems Development**
**Duración Estimada:** 6-8 semanas  
**Objetivo:** Implementar sistemas fundamentales de gameplay

---

#### **FASE 2.1: Sistema de Movimiento Avanzado**

##### **Tarea 2.1.1: Controlador de Personaje Base en Unity**
**Descripción:** Implementar física 2D y movimiento básico del jugador

**Checklist:**
- [ ] Crear GameObject "Player" con **Rigidbody2D** (Dynamic, Freeze Rotation Z)
- [ ] Añadir **CapsuleCollider2D** o **BoxCollider2D**
- [ ] Crear script `PlayerController.cs` con namespace `SombrasDelUmbral.Player`
- [ ] Configurar **Physics2D Settings** (gravedad: -20 a -30 recomendado)
- [ ] Implementar movimiento horizontal con `Rigidbody2D.velocity`
- [ ] Añadir aceleración/desaceleración con `Mathf.Lerp` o `SmoothDamp`
- [ ] Configurar detección de suelo con **Physics2D.Raycast** o **OverlapCircle**
- [ ] Crear **LayerMask** para "Ground" (Physics2D layers)
- [ ] Implementar salto con altura variable (detectar input release)
- [ ] Ajustar gravedad con `Rigidbody2D.gravityScale` (0.8-1.2 para feel cinemático)
- [ ] Implementar **coyote time** (6-8 frames = ~0.1-0.13s)
- [ ] Implementar **jump buffering** (4-6 frames = ~0.07-0.1s)
- [ ] Configurar **New Input System** (crear Input Actions Asset)
- [ ] Crear Input Actions: Move (Vector2), Jump (Button), Dash (Button)
- [ ] Añadir debug visualization con `OnDrawGizmos()` (raycasts, ground check)
- [ ] Crear **PlayerDataSO** (ScriptableObject) para tunear valores
- [ ] Configurar **Animator Controller** básico (Idle, Run, Jump, Fall)

**Dependencias:** Tarea 1.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 2.1.2: Habilidades de Movilidad Avanzada en Unity**
**Descripción:** Implementar dash, doble salto, wall-jump, planeo con Unity

**Checklist:**
- [ ] **Dash:**
  - [ ] Implementar dash con `Rigidbody2D.velocity` o `AddForce`
  - [ ] Añadir cooldown con `Time.time` o coroutine
  - [ ] Implementar dash diagonal (8 direcciones con Input.GetAxisRaw)
  - [ ] Crear **Trail Renderer** component para efecto visual
  - [ ] Configurar **Particle System** para dash particles
  - [ ] Implementar invulnerabilidad temporal (cambiar layer a "Invulnerable")
  - [ ] Añadir **Cinemachine Impulse Source** para screen shake
  - [ ] Crear animación de dash en **Animator**
- [ ] **Doble Salto:**
  - [ ] Implementar contador de saltos (reset en ground check)
  - [ ] Añadir **Particle System** para segundo salto
  - [ ] Ajustar impulso del segundo salto (80% del primero)
  - [ ] Crear animación de doble salto
- [ ] **Wall-Jump:**
  - [ ] Detectar contacto con pared con **Physics2D.Raycast** lateral
  - [ ] Crear **LayerMask** para "Wall"
  - [ ] Implementar wall-slide (reducir `Rigidbody2D.gravityScale`)
  - [ ] Añadir wall-jump con impulso diagonal (`Vector2` con X e Y)
  - [ ] Crear animación de wall-cling y wall-jump
  - [ ] Añadir **Particle System** para fricción en pared
- [ ] **Planeo:**
  - [ ] Reducir gravedad con `Rigidbody2D.gravityScale` al mantener botón
  - [ ] Añadir límite de duración (timer o consumo de energía)
  - [ ] Crear **Particle System** para efecto de planeo
  - [ ] Crear animación de planeo
- [ ] Crear **PlayerStateMachine** (Idle, Run, Jump, Dash, WallSlide, Glide)
- [ ] Configurar **Animator Controller** con transiciones
- [ ] Crear **AbilitySO** (ScriptableObject) para unlock progresivo
- [ ] Implementar sistema de unlock con booleans persistentes

**Dependencias:** Tarea 2.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

##### **Tarea 2.1.3: Sistema de Energía para Movimiento en Unity**
**Descripción:** Implementar barra de energía con Unity UI

**Checklist:**
- [ ] Crear script `EnergySystem.cs` con valor actual/máximo
- [ ] Crear **EnergyDataSO** (ScriptableObject) para configuración
- [ ] Implementar consumo de energía por habilidad (dash: 25%, planeo: 10%/s)
- [ ] Añadir regeneración automática con `Time.deltaTime` (50% por segundo)
- [ ] Prevenir uso de habilidades con check de energía suficiente
- [ ] Crear **Canvas** para HUD con **Screen Space - Overlay**
- [ ] Añadir **UI Slider** para barra de energía
- [ ] Configurar **Image Fill** para visualización de barra
- [ ] Implementar feedback visual (cambiar color con `Image.color` cuando < 30%)
- [ ] Crear gradiente de colores (verde > amarillo > rojo)
- [ ] Añadir **AudioSource** para SFX de energía baja (loop cuando < 20%)
- [ ] Crear sistema de upgrades con **ScriptableObject**
- [ ] Implementar eventos con **UnityEvent** o **ScriptableObject Events**
- [ ] Guardar capacidad máxima en sistema de save (PlayerPrefs o JSON)

**Dependencias:** Tarea 2.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 4-5 días

---

#### **FASE 2.2: Sistema de Combate Base**

##### **Tarea 2.2.1: Combate Cuerpo a Cuerpo en Unity**
**Descripción:** Implementar sistema de combate con Unity Physics 2D

**Checklist:**
- [ ] Crear GameObject hijo "AttackHitbox" con **Collider2D** (trigger)
- [ ] Configurar **LayerMask** para "Enemy" y collision matrix
- [ ] Crear script `PlayerCombat.cs` para gestión de ataques
- [ ] Implementar combo de 3 golpes con timer de ventana de input
- [ ] Crear animaciones de ataque en **Animator** (Attack1, Attack2, Attack3)
- [ ] Configurar **Animation Events** para activar/desactivar hitbox en frames específicos
- [ ] Implementar cancelación de animación con `Animator.CrossFade` al dash
- [ ] Crear interface `IDamageable` para sistema de daño
- [ ] Crear scripts `DamageDealer.cs` y `Health.cs`
- [ ] Implementar `OnTriggerEnter2D` para detección de golpes
- [ ] Añadir knockback con `Rigidbody2D.AddForce` (ForceMode2D.Impulse)
- [ ] Implementar **hitstop** con `Time.timeScale = 0` por 2-4 frames
- [ ] Crear coroutine para restaurar `Time.timeScale`
- [ ] Añadir **Cinemachine Impulse Source** para screen shake
- [ ] Crear **Particle System** para slash effect
- [ ] Instanciar particles con **Object Pooling** (evitar Instantiate)
- [ ] Añadir **AudioSource** para SFX de ataque y impacto
- [ ] Configurar **Audio Mixer** para mezcla de sonidos

**Dependencias:** Tarea 2.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 2.2.2: Sistema de Vida y Muerte**
**Descripción:** Implementar HP, daño recibido y respawn

**Checklist:**
- [ ] Crear clase HealthSystem con HP actual/máximo
- [ ] Implementar recepción de daño con invulnerabilidad temporal (i-frames)
- [ ] Añadir feedback visual de daño (sprite flash, shader)
- [ ] Crear animación de muerte del jugador
- [ ] Implementar sistema de respawn en último checkpoint
- [ ] Añadir penalización por muerte (pérdida de recursos temporales)
- [ ] Crear UI de corazones/barra de vida
- [ ] Implementar sistema de checkpoints
- [ ] Guardar HP en sistema de save
- [ ] Añadir power-up de curación

**Dependencias:** Tarea 2.2.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 5-6 días

---

#### **FASE 2.3: Sistema de Cámara**

##### **Tarea 2.3.1: Cámara Cinemática 2D con Cinemachine**
**Descripción:** Implementar sistema de cámara avanzado con Cinemachine

**Checklist:**
- [ ] Crear **Cinemachine Virtual Camera** en escena
- [ ] Configurar **Follow** target (Player Transform)
- [ ] Configurar **Body**: Framing Transposer (2D)
- [ ] Ajustar **Damping** (X: 0.5-1, Y: 0.3-0.7 para smoothing)
- [ ] Configurar **Dead Zone** (centro pequeño) y **Soft Zone**
- [ ] Añadir **Cinemachine Confiner 2D** con **PolygonCollider2D** para límites
- [ ] Implementar **look-ahead** con Aim: POV o Group Target
- [ ] Crear múltiples **Virtual Cameras** para diferentes zonas
- [ ] Configurar **Priority** para transiciones automáticas
- [ ] Añadir **Cinemachine Impulse Listener** a cámara principal
- [ ] Crear **Cinemachine Impulse Source** en Player y enemigos
- [ ] Configurar perfiles de impulso (shake patterns)
- [ ] Implementar zoom dinámico con `Lens.OrthographicSize` animado
- [ ] Crear script `CameraZone.cs` con trigger para cambiar cámaras
- [ ] Configurar **Blend Settings** para transiciones suaves (EaseInOut)
- [ ] Implementar **parallax scrolling**:
  - [ ] Crear 3 capas de fondo (far, mid, near)
  - [ ] Crear script `ParallaxLayer.cs` con velocidad relativa
  - [ ] Configurar **Sorting Layers** (Background -3, -2, -1)
- [ ] Optimizar con **Culling Mask** en cámara
- [ ] Implementar **Frustum Culling** manual para enemigos lejanos

**Dependencias:** Tarea 2.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

### **ETAPA 3: Gameplay Systems Expansion**
**Duración Estimada:** 6-8 semanas  
**Objetivo:** Expandir mecánicas y sistemas de progresión

---

#### **FASE 3.1: Sistema de Implantes**

##### **Tarea 3.1.1: Arquitectura de Implantes en Unity**
**Descripción:** Crear sistema modular con ScriptableObjects

**Checklist:**
- [ ] Crear **ImplantSO** (ScriptableObject base) con:
  - [ ] Nombre, descripción, icono (Sprite)
  - [ ] Tipo (Pasivo/Activo)
  - [ ] Efectos (stats modificados)
  - [ ] Requisitos de unlock
- [ ] Crear script `ImplantManager.cs` (singleton)
- [ ] Implementar lista de implantes equipados (List<ImplantSO>)
- [ ] Crear slots de equipamiento (4-6 slots)
- [ ] Implementar sistema de unlock con booleans (PlayerPrefs o JSON)
- [ ] Crear **Canvas** para UI de inventario
- [ ] Implementar **Grid Layout Group** para grid de implantes
- [ ] Crear prefab `ImplantSlotUI` con **Image** y **Button**
- [ ] Implementar **drag & drop** con interfaces:
  - [ ] `IBeginDragHandler`, `IDragHandler`, `IEndDragHandler`
  - [ ] `IDropHandler` para slots de equipamiento
- [ ] Crear **Tooltip** UI con **TextMeshPro**
- [ ] Implementar `IPointerEnterHandler` para mostrar tooltip
- [ ] Guardar implantes equipados en **JSON** o **PlayerPrefs**
- [ ] Crear sistema de efectos visuales:
  - [ ] Añadir **SpriteRenderer** hijos al Player para implantes visibles
  - [ ] Activar/desactivar según implantes equipados
- [ ] Implementar sistema de sinergias con diccionario de combinaciones
- [ ] Crear **UnityEvent** para notificar cambios de implantes

**Dependencias:** Tarea 2.1.2, Tarea 2.2.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1.5 semanas

---

##### **Tarea 3.1.2: Implantes Específicos**
**Descripción:** Implementar implantes individuales del GDD

**Checklist:**
- [ ] **Implantes de Movilidad:**
  - [ ] Doble Salto (unlock permanente)
  - [ ] Dash Mejorado (reduce cooldown 30%)
  - [ ] Magnetismo (atrae objetos cercanos)
  - [ ] Planeo Extendido (+50% duración)
- [ ] **Implantes de Combate:**
  - [ ] Daño Aumentado (+25%)
  - [ ] Velocidad de Ataque (+20%)
  - [ ] Críticos (15% probabilidad de x2 daño)
- [ ] **Implantes de Supervivencia:**
  - [ ] Vida Extra (+1 corazón)
  - [ ] Regeneración Pasiva (1 HP cada 30s)
  - [ ] Escudo Temporal (absorbe 1 golpe cada 60s)
- [ ] Balancear valores de cada implante
- [ ] Crear assets visuales para cada implante
- [ ] Añadir descripciones de lore

**Dependencias:** Tarea 3.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

#### **FASE 3.2: Inteligencia Artificial**

##### **Tarea 3.2.1: Framework de IA Base en Unity**
**Descripción:** Implementar sistema modular de IA con FSM y pathfinding

**Checklist:**
- [ ] Crear clase base `AIController.cs` con namespace `SombrasDelUmbral.AI`
- [ ] Implementar **Finite State Machine** genérica:
  - [ ] Crear interface `IState` con Enter(), Update(), Exit()
  - [ ] Crear clase `StateMachine` con ChangeState()
- [ ] Crear estados base (scripts):
  - [ ] `IdleState.cs` (espera con animación idle)
  - [ ] `PatrolState.cs` (movimiento entre waypoints)
  - [ ] `ChaseState.cs` (persecución del jugador)
  - [ ] `AttackState.cs` (ejecutar ataque)
  - [ ] `FleeState.cs` (huida cuando HP bajo)
- [ ] Implementar **sistema de detección** con vision cone:
  - [ ] Usar **Physics2D.OverlapCircle** para rango de detección
  - [ ] Implementar **raycast** para line of sight
  - [ ] Crear **LayerMask** para "Player" y "Obstacles"
  - [ ] Añadir ángulo de visión (FOV: 90-120 grados)
- [ ] Implementar **pathfinding**:
  - [ ] Opción 1: Unity **NavMesh** 2D (experimental)
  - [ ] Opción 2: **A* Pathfinding Project** (asset gratuito)
  - [ ] Configurar **NavMeshAgent2D** o equivalente
- [ ] Crear sistema de aggro:
  - [ ] Implementar timer de persecución
  - [ ] De-aggro cuando jugador sale de rango por X segundos
- [ ] Implementar comportamiento de grupo:
  - [ ] Usar **Physics2D.OverlapCircle** para detectar aliados cercanos
  - [ ] Llamar método `Alert()` en enemigos cercanos
- [ ] Añadir **debug visualization**:
  - [ ] `OnDrawGizmos()` para vision cone (Gizmos.DrawWireSphere)
  - [ ] Mostrar estado actual con `OnGUI()` o Debug.Log
- [ ] Optimizar con **Object Pooling**:
  - [ ] Crear `EnemyPool.cs` con Queue<GameObject>
  - [ ] Implementar Spawn() y Despawn()
- [ ] Crear **AIDataSO** (ScriptableObject) para configurar por tipo:
  - [ ] Velocidad, rango de detección, daño, HP, etc.

**Dependencias:** Tarea 2.2.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

##### **Tarea 3.2.2: Enemigos Básicos**
**Descripción:** Implementar 4-6 tipos de enemigos estándar

**Checklist:**
- [ ] **Enemigo Melee (Patrulla):**
  - [ ] Implementar patrulla en plataforma
  - [ ] Añadir detección y persecución
  - [ ] Crear ataque cuerpo a cuerpo
- [ ] **Enemigo Volador (Ranged):**
  - [ ] Implementar movimiento aéreo
  - [ ] Añadir ataque a distancia (proyectil)
  - [ ] Crear patrón de evasión
- [ ] **Enemigo Tanque (Heavy):**
  - [ ] Alto HP, movimiento lento
  - [ ] Ataque de área (AoE)
  - [ ] Resistencia a knockback
- [ ] **Enemigo Rápido (Assassin):**
  - [ ] Movimiento errático
  - [ ] Dash hacia jugador
  - [ ] Bajo HP, alto daño
- [ ] Balancear HP, daño y velocidad de cada tipo
- [ ] Crear animaciones y sprites
- [ ] Implementar drops de Energía Arcana
- [ ] Añadir efectos de muerte (partículas, SFX)

**Dependencias:** Tarea 3.2.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

##### **Tarea 3.2.3: Sistema de Jefes**
**Descripción:** Crear framework para boss fights con fases

**Checklist:**
- [ ] Crear clase BossController con sistema de fases
- [ ] Implementar Behavior Tree para patrones complejos
- [ ] Añadir sistema de ataques telegrafados (visual cues)
- [ ] Crear transiciones entre fases (25%, 50%, 75% HP)
- [ ] Implementar invulnerabilidad durante transiciones
- [ ] Añadir barra de vida de jefe (UI especial)
- [ ] Crear sistema de arena (cerrar puertas durante pelea)
- [ ] Implementar checkpoint pre-jefe automático
- [ ] Añadir cinemática de introducción
- [ ] Crear sistema de recompensas post-jefe (implante único)

**Dependencias:** Tarea 3.2.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1.5 semanas

---

#### **FASE 3.3: Economía y Progresión**

##### **Tarea 3.3.1: Sistema de Recursos**
**Descripción:** Implementar Energía Arcana y Cristales de Núcleo

**Checklist:**
- [ ] Crear ResourceManager con diccionario de recursos
- [ ] Implementar Energía Arcana (moneda común)
- [ ] Implementar Cristales de Núcleo (moneda premium)
- [ ] Crear pickups con animación de recolección
- [ ] Añadir magnetismo de pickups hacia jugador
- [ ] Implementar UI de contador de recursos (HUD)
- [ ] Guardar recursos en save system
- [ ] Crear sistema de drops de enemigos (loot table)
- [ ] Implementar pérdida parcial de Energía al morir
- [ ] Añadir SFX y VFX de recolección

**Dependencias:** Tarea 2.2.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 3.3.2: Sistema de Mejoras**
**Descripción:** Implementar tienda/estaciones de upgrade

**Checklist:**
- [ ] Crear UpgradeStation (NPC o terminal interactivo)
- [ ] Diseñar UI de menú de mejoras
- [ ] Implementar mejoras permanentes:
  - [ ] Vida máxima (+1 corazón: 50 Energía)
  - [ ] Daño base (+10%: 75 Energía)
  - [ ] Capacidad de energía (+25%: 100 Energía)
- [ ] Añadir mejoras únicas con Cristales de Núcleo
- [ ] Implementar sistema de prerequisitos (unlock tree)
- [ ] Guardar mejoras compradas en save
- [ ] Crear feedback visual de mejora aplicada
- [ ] Añadir descripciones y tooltips
- [ ] Implementar confirmación de compra

**Dependencias:** Tarea 3.3.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1 semana

---

### **ETAPA 4: World Building & Level Design**
**Duración Estimada:** 8-10 semanas  
**Objetivo:** Construir el mundo interconectado y los biomas

---

#### **FASE 4.1: Herramientas de Level Design**

##### **Tarea 4.1.1: Sistema de Tilemap en Unity**
**Descripción:** Configurar Unity Tilemap para level design

**Checklist:**
- [ ] Crear GameObject "Grid" con componente **Grid**
- [ ] Añadir hijos **Tilemap** (Ground, Walls, Decorations, Foreground)
- [ ] Configurar **Tilemap Renderer** (Sorting Layers)
- [ ] Crear **Tile Palette** (Window > 2D > Tile Palette)
- [ ] Importar sprites de tileset (configurar como Multiple, Sprite Mode)
- [ ] Crear **Rule Tiles** para autotiling:
  - [ ] Crear Rule Tile asset (Create > 2D > Tiles > Rule Tile)
  - [ ] Configurar reglas de conexión (8-way, 47 tiles recomendado)
  - [ ] Aplicar a plataformas y paredes
- [ ] Configurar **collision layers**:
  - [ ] Añadir **Tilemap Collider 2D** a Ground y Walls
  - [ ] Añadir **Composite Collider 2D** para optimización
  - [ ] Configurar **Rigidbody2D** (Static) en Tilemap
  - [ ] Configurar **Platform Effector 2D** para one-way platforms
- [ ] Crear tiles decorativos sin collider
- [ ] Crear **Prefab Brushes** (GameObject Brush):
  - [ ] Enemigos, checkpoints, items, hazards
  - [ ] Configurar en Tile Palette
- [ ] Configurar **Grid Snapping** (Edit > Grid and Snap Settings)
- [ ] Crear múltiples **Tile Palettes** por bioma:
  - [ ] Bosques, Ruinas, Laboratorio, Cavernas
- [ ] Configurar parallax layers (Background, Midground, Foreground)
- [ ] Documentar workflow en README (cómo usar Rule Tiles, brushes)

**Dependencias:** Tarea 1.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 4.1.2: Herramientas Internas de Diseño**
**Descripción:** Crear editor tools para acelerar level design

**Checklist:**
- [ ] Crear Room Editor (definir bounds de habitaciones)
- [ ] Implementar Enemy Spawner tool (colocar enemigos con preview)
- [ ] Añadir Checkpoint Placer con visualización de área
- [ ] Crear Secret Area Marker (para tracking de completitud)
- [ ] Implementar Camera Zone Editor (definir encuadres)
- [ ] Añadir Hazard Placer (pinchos, láseres, etc.)
- [ ] Crear sistema de teleport points (fast travel)
- [ ] Implementar Level Validator (detectar áreas inaccesibles)
- [ ] Añadir Minimap Generator automático

**Dependencias:** Tarea 4.1.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 2 semanas

---

#### **FASE 4.2: Diseño Metroidvania**

##### **Tarea 4.2.1: Estructura del Mundo**
**Descripción:** Diseñar mapa interconectado con gating

**Checklist:**
- [ ] Crear mapa conceptual del mundo completo (papel/Miro)
- [ ] Definir Hub central y conexiones a biomas
- [ ] Planificar gates de habilidades (dash para gap, doble salto para altura, etc.)
- [ ] Diseñar shortcuts y atajos post-backtracking
- [ ] Marcar ubicaciones de checkpoints y save points
- [ ] Planificar ubicación de jefes y recompensas
- [ ] Definir áreas secretas y rutas opcionales
- [ ] Crear flowchart de progresión esperada
- [ ] Documentar critical path vs optional content
- [ ] Validar que no haya soft-locks

**Dependencias:** Tarea 4.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1.5 semanas

---

##### **Tarea 4.2.2: Sistema de Puertas y Bloqueos**
**Descripción:** Implementar gates que requieren habilidades específicas

**Checklist:**
- [ ] Crear clase base Gate con requisito de habilidad
- [ ] Implementar tipos de puertas:
  - [ ] Gap Gate (requiere dash)
  - [ ] High Ledge (requiere doble salto)
  - [ ] Wall Passage (requiere wall-jump)
  - [ ] Energy Barrier (requiere implante específico)
- [ ] Añadir feedback visual de requisito (iconos, color)
- [ ] Implementar animación de apertura/desbloqueo
- [ ] Crear sistema de puertas con llave (Cristales de Núcleo)
- [ ] Añadir hint system (tutorial sutil de qué habilidad usar)
- [ ] Guardar estado de puertas abiertas en save
- [ ] Implementar one-way passages (válvulas)

**Dependencias:** Tarea 4.2.1, Tarea 3.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

#### **FASE 4.3: Biomas**

##### **Tarea 4.3.1: Bosques Corruptos (Bioma 1)**
**Descripción:** Primer bioma - tutorial de mecánicas

**Checklist:**
- [ ] Diseñar layout completo (3-5 habitaciones)
- [ ] Crear tileset de bosque (árboles, plataformas orgánicas)
- [ ] Implementar enemigos básicos (2 tipos)
- [ ] Añadir hazards introductorios (pinchos estáticos)
- [ ] Diseñar puzzles de dash y doble salto
- [ ] Crear jefe del bioma (Boss 1)
- [ ] Implementar parallax de bosque (3 capas)
- [ ] Añadir música de ambiente (tema de bosque)
- [ ] Colocar checkpoints y secrets
- [ ] Implementar iluminación dinámica (rayos de luz)
- [ ] Añadir efectos ambientales (partículas de hojas)
- [ ] Balancear dificultad para early game

**Dependencias:** Tarea 4.2.2, Tarea 3.2.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

##### **Tarea 4.3.2: Ruinas Mecánicas (Bioma 2)**
**Descripción:** Segundo bioma - plataformas móviles y precisión

**Checklist:**
- [ ] Diseñar layout con énfasis en verticalidad
- [ ] Crear tileset industrial (metal, cables, maquinaria)
- [ ] Implementar plataformas móviles (horizontal/vertical)
- [ ] Añadir trampas de timing (prensas, sierras)
- [ ] Crear enemigos mecánicos (3 tipos)
- [ ] Diseñar puzzles de wall-jump y timing
- [ ] Crear jefe mecánico (Boss 2)
- [ ] Implementar parallax de fábrica
- [ ] Añadir música industrial/electrónica
- [ ] Colocar áreas secretas con Cristales de Núcleo
- [ ] Añadir efectos de vapor y chispas
- [ ] Implementar luces parpadeantes

**Dependencias:** Tarea 4.3.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2.5 semanas

---

##### **Tarea 4.3.3: Laboratorio Abandonado (Bioma 3)**
**Descripción:** Tercer bioma - puzzles lógicos y química

**Checklist:**
- [ ] Diseñar layout con salas de puzzle
- [ ] Crear tileset de laboratorio (cristal, tecnología avanzada)
- [ ] Implementar sistema de láseres (reflectores, bloqueadores)
- [ ] Añadir elementos químicos reactivos (ácido, electricidad)
- [ ] Crear enemigos experimentales (3 tipos)
- [ ] Diseñar puzzles de lógica y secuencia
- [ ] Crear jefe científico corrupto (Boss 3)
- [ ] Implementar parallax de laboratorio
- [ ] Añadir música misteriosa/tensa
- [ ] Colocar lore items (notas de científicos)
- [ ] Añadir efectos de energía arcana
- [ ] Implementar iluminación de neón

**Dependencias:** Tarea 4.3.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2.5 semanas

---

##### **Tarea 4.3.4: Cavernas de Energía (Bioma 4)**
**Descripción:** Bioma final - desafío completo de habilidades

**Checklist:**
- [ ] Diseñar layout complejo con múltiples rutas
- [ ] Crear tileset de caverna cristalina
- [ ] Implementar corrientes de aire (impulso vertical)
- [ ] Añadir teletransportes naturales (portales de energía)
- [ ] Crear enemigos de energía pura (4 tipos)
- [ ] Diseñar gauntlet sections (desafío de habilidades)
- [ ] Crear jefe final (Boss 4 - multifase)
- [ ] Implementar parallax de caverna
- [ ] Añadir música épica/climática
- [ ] Colocar secretos de endgame
- [ ] Añadir efectos de cristales brillantes
- [ ] Implementar iluminación dinámica de energía

**Dependencias:** Tarea 4.3.3  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 3 semanas

---

#### **FASE 4.4: Sistemas de Mundo**

##### **Tarea 4.4.1: Sistema de Save y Checkpoints en Unity**
**Descripción:** Implementar guardado con JSON y checkpoints

**Checklist:**
- [ ] Crear clase `SaveData` [Serializable] con:
  - [ ] Datos de jugador (HP, energía, recursos, posición, escena)
  - [ ] Implantes equipados (List<string> de IDs)
  - [ ] Estado del mundo (Dictionary<string, bool> para puertas, items)
  - [ ] Timestamp de guardado
- [ ] Crear `SaveSystem.cs` (singleton) con:
  - [ ] `SaveGame(int slot)` - serializar con **JsonUtility.ToJson()**
  - [ ] `LoadGame(int slot)` - deserializar con **JsonUtility.FromJson()**
  - [ ] Guardar en **Application.persistentDataPath**
- [ ] Implementar auto-save en checkpoints:
  - [ ] Crear prefab "Checkpoint" con trigger
  - [ ] Script `Checkpoint.cs` con `OnTriggerEnter2D`
  - [ ] Llamar `SaveSystem.SaveGame()` al activar
- [ ] Guardar datos de jugador:
  - [ ] HP, energía máxima, recursos (Energía Arcana, Cristales)
  - [ ] Posición (Vector3) y escena actual (SceneManager.GetActiveScene().name)
- [ ] Guardar estado del mundo:
  - [ ] Crear `WorldState.cs` con Dictionary<string, bool>
  - [ ] Guardar enemigos muertos (GUID único por enemigo)
  - [ ] Guardar puertas abiertas, items recogidos
- [ ] Implementar **3 slots de guardado**:
  - [ ] Archivos: save_slot_0.json, save_slot_1.json, save_slot_2.json
  - [ ] Crear UI de selección de slot (Canvas con botones)
- [ ] Crear sistema de respawn:
  - [ ] Guardar último checkpoint activado en SaveData
  - [ ] Al morir, cargar posición del último checkpoint
- [ ] Implementar **backup de save**:
  - [ ] Crear copia .bak antes de sobrescribir
  - [ ] Restaurar desde .bak si JSON corrupto
- [ ] Añadir indicador visual de auto-save:
  - [ ] Icono animado en esquina (fade in/out)
  - [ ] Usar **DOTween** o Animator para animación
- [ ] Optimizar tamaño:
  - [ ] Usar JsonUtility (más rápido que JSON.NET)
  - [ ] Comprimir con **GZip** si archivo > 100KB (opcional)

**Dependencias:** Tarea 2.2.2, Tarea 3.3.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1.5 semanas

---

##### **Tarea 4.4.2: Sistema de Mapa**
**Descripción:** Implementar minimapa y mapa completo

**Checklist:**
- [ ] Crear sistema de revelado de mapa por habitación
- [ ] Implementar minimapa en HUD (esquina superior)
- [ ] Crear UI de mapa completo (pantalla completa)
- [ ] Añadir iconos de puntos de interés (checkpoints, jefes, secrets)
- [ ] Implementar marcadores personalizados del jugador
- [ ] Añadir indicador de posición actual
- [ ] Crear sistema de zoom en mapa completo
- [ ] Implementar compra de mapas de bioma (NPC cartógrafo)
- [ ] Añadir porcentaje de exploración por área
- [ ] Guardar progreso de mapa en save

**Dependencias:** Tarea 4.2.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1.5 semanas

---

##### **Tarea 4.4.3: Sistema de Teletransporte**
**Descripción:** Implementar fast travel entre puntos desbloqueados

**Checklist:**
- [ ] Crear TeleportStation (puntos de viaje rápido)
- [ ] Implementar UI de selección de destino
- [ ] Añadir costo de teletransporte (Energía Arcana)
- [ ] Crear animación de teletransporte (fade out/in)
- [ ] Implementar desbloqueo progresivo de estaciones
- [ ] Añadir restricciones (no usar durante combate)
- [ ] Guardar estaciones desbloqueadas en save
- [ ] Crear efectos visuales de portal
- [ ] Añadir SFX de teletransporte
- [ ] Integrar con sistema de mapa (teleport desde mapa)

**Dependencias:** Tarea 4.4.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1 semana

---

### **ETAPA 5: Polish & UX**
**Duración Estimada:** 4-6 semanas  
**Objetivo:** Pulir experiencia de usuario y feedback visual

---

#### **FASE 5.1: Juice y Feedback Visual**

##### **Tarea 5.1.1: Sistema de Partículas**
**Descripción:** Implementar efectos visuales para todas las acciones

**Checklist:**
- [ ] Crear particle system para:
  - [ ] Dash trail (estela de movimiento)
  - [ ] Salto (polvo al despegar/aterrizar)
  - [ ] Impactos de ataque (chispas, slash)
  - [ ] Daño recibido (sangre/aceite)
  - [ ] Muerte de enemigos (explosión)
  - [ ] Recolección de items (brillo)
  - [ ] Activación de implantes (aura)
- [ ] Optimizar particle pooling
- [ ] Añadir variaciones por contexto (superficie)
- [ ] Implementar control de calidad gráfica (low/med/high)
- [ ] Crear efectos ambientales por bioma

**Dependencias:** Tarea 2.1.2, Tarea 2.2.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1.5 semanas

---

##### **Tarea 5.1.2: Screen Shake y Camera Effects**
**Descripción:** Implementar efectos de cámara para impacto

**Checklist:**
- [ ] Crear ScreenShakeManager con sistema de trauma
- [ ] Implementar shake en:
  - [ ] Ataques del jugador (sutil)
  - [ ] Recibir daño (moderado)
  - [ ] Explosiones (intenso)
  - [ ] Ataques de jefes (muy intenso)
- [ ] Añadir chromatic aberration en impactos fuertes
- [ ] Implementar slow-motion temporal (bullet time)
- [ ] Crear zoom dinámico en momentos clave
- [ ] Añadir vignette en situaciones de peligro (HP bajo)
- [ ] Implementar configuración de intensidad (accesibilidad)

**Dependencias:** Tarea 2.3.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 5.1.3: Animaciones y Transiciones**
**Descripción:** Pulir todas las animaciones del juego

**Checklist:**
- [ ] Revisar y pulir animaciones del jugador (12+ estados)
- [ ] Implementar blend trees para transiciones suaves
- [ ] Añadir anticipation frames en ataques
- [ ] Crear animaciones de idle dinámicas (breathing)
- [ ] Implementar squash & stretch en saltos
- [ ] Añadir animaciones de reacción (hit, stun)
- [ ] Crear animaciones de victoria/derrota
- [ ] Pulir animaciones de enemigos
- [ ] Implementar animaciones de objetos interactivos
- [ ] Añadir micro-animaciones en UI (hover, click)

**Dependencias:** Tarea 2.1.2, Tarea 2.2.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

#### **FASE 5.2: UI/UX**

##### **Tarea 5.2.1: HUD y Menús**
**Descripción:** Diseñar e implementar toda la interfaz de usuario

**Checklist:**
- [ ] Diseñar HUD minimalista (HP, energía, recursos)
- [ ] Crear menú principal (New Game, Continue, Settings, Quit)
- [ ] Implementar menú de pausa (Resume, Map, Inventory, Settings)
- [ ] Diseñar inventario de implantes (drag & drop)
- [ ] Crear menú de configuración (gráficos, audio, controles)
- [ ] Implementar pantalla de muerte (Retry, Quit)
- [ ] Añadir tooltips informativos
- [ ] Crear transiciones animadas entre menús
- [ ] Implementar navegación con gamepad
- [ ] Añadir SFX de UI (hover, click, error)

**Dependencias:** Tarea 3.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

##### **Tarea 5.2.2: Tutorial y Onboarding**
**Descripción:** Implementar sistema de tutoriales no intrusivo

**Checklist:**
- [ ] Crear TutorialManager con sistema de triggers
- [ ] Implementar tooltips contextuales (primera vez que se usa habilidad)
- [ ] Añadir señales visuales en entorno (flechas, highlights)
- [ ] Crear sección de práctica opcional (training room)
- [ ] Implementar sistema de hints (ayuda si jugador está atascado)
- [ ] Añadir recordatorios de controles en pantalla de carga
- [ ] Crear tutorial de combate (enemigo de práctica)
- [ ] Implementar skip de tutoriales (para jugadores experimentados)
- [ ] Guardar progreso de tutoriales completados

**Dependencias:** Tarea 5.2.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1 semana

---

#### **FASE 5.3: Accesibilidad**

##### **Tarea 5.3.1: Opciones de Accesibilidad**
**Descripción:** Implementar features de accesibilidad

**Checklist:**
- [ ] Añadir re-mapeo completo de controles
- [ ] Implementar modo para daltónicos (3 variantes)
- [ ] Crear ajuste de velocidad del juego (50%-150%)
- [ ] Añadir subtítulos para diálogos
- [ ] Implementar indicadores visuales de sonidos (enemigos fuera de pantalla)
- [ ] Crear modo de asistencia (invulnerabilidad, daño aumentado)
- [ ] Añadir opción de reducir screen shake
- [ ] Implementar high contrast mode
- [ ] Crear opciones de tamaño de texto
- [ ] Añadir toggle para desactivar flashes (epilepsia)

**Dependencias:** Tarea 5.2.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1.5 semanas

---

#### **FASE 5.4: Audio**

##### **Tarea 5.4.1: Implementación de Audio en Unity**
**Descripción:** Integrar música y SFX con Unity Audio Mixer

**Checklist:**
- [ ] Crear **Audio Mixer** (Create > Audio Mixer):
  - [ ] Buses: Master, Music, SFX, Ambient, UI
  - [ ] Configurar routing y atenuación
- [ ] Crear `AudioManager.cs` (singleton) con object pooling de AudioSource
- [ ] Integrar música adaptativa por bioma con crossfade (coroutines)
- [ ] Implementar música de combate (layer system sincronizado con AudioSettings.dspTime)
- [ ] Configurar Load Type: **Streaming** para música, **Decompress On Load** para SFX
- [ ] Implementar audio 3D posicional (Spatial Blend = 1, Min/Max Distance)
- [ ] Añadir atenuación por obstáculos (raycast + lowpass filter)
- [ ] Crear Audio Mixer Snapshots (Normal, Combat, Pause)
- [ ] Implementar controles de volumen con AudioMixer.SetFloat()
- [ ] Añadir Audio Reverb Zones en cavernas

**Dependencias:** Tarea 4.3.4  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

### **ETAPA 6: Testing & QA**
**Duración Estimada:** 4-6 semanas  
**Objetivo:** Asegurar calidad y balance del juego

---

#### **FASE 6.1: Playtesting Interno**

##### **Tarea 6.1.1: Primera Ronda de Playtesting**
**Descripción:** Testing interno del equipo

**Checklist:**
- [ ] Crear build de playtest con debug tools
- [ ] Definir métricas a medir (tiempo por bioma, muertes, etc.)
- [ ] Realizar playthrough completo (cada miembro del equipo)
- [ ] Documentar bugs encontrados (bug tracker)
- [ ] Identificar puntos de frustración (difficulty spikes)
- [ ] Evaluar claridad de tutoriales
- [ ] Revisar feedback de controles (input lag, responsiveness)
- [ ] Analizar métricas de progresión
- [ ] Compilar lista de mejoras prioritarias
- [ ] Crear plan de correcciones

**Dependencias:** Tarea 5.4.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 6.1.2: Corrección de Bugs Críticos**
**Descripción:** Resolver bugs de alta prioridad

**Checklist:**
- [ ] Clasificar bugs por severidad (crítico, alto, medio, bajo)
- [ ] Resolver bugs críticos (crashes, soft-locks)
- [ ] Corregir bugs de gameplay (física, combate, IA)
- [ ] Arreglar bugs de UI (overlapping, inputs)
- [ ] Solucionar bugs de audio (missing sounds, loops)
- [ ] Corregir bugs de save system
- [ ] Resolver bugs de rendimiento (frame drops)
- [ ] Verificar correcciones con regression testing
- [ ] Actualizar bug tracker con estado

**Dependencias:** Tarea 6.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

#### **FASE 6.2: Balanceo**

##### **Tarea 6.2.1: Balanceo de Combate**
**Descripción:** Ajustar dificultad y progresión de combate

**Checklist:**
- [ ] Analizar datos de muertes por enemigo/jefe
- [ ] Ajustar HP de enemigos por bioma
- [ ] Balancear daño de ataques enemigos
- [ ] Revisar cooldowns de habilidades del jugador
- [ ] Ajustar costo de energía de habilidades
- [ ] Balancear drops de recursos
- [ ] Revisar dificultad de jefes (fases, patrones)
- [ ] Ajustar curva de progresión de daño
- [ ] Testear con jugadores de diferentes skill levels
- [ ] Documentar valores finales en design doc

**Dependencias:** Tarea 6.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1.5 semanas

---

##### **Tarea 6.2.2: Balanceo de Economía**
**Descripción:** Ajustar costos y recompensas

**Checklist:**
- [ ] Analizar tasa de ganancia de Energía Arcana
- [ ] Ajustar costos de mejoras
- [ ] Balancear drops de Cristales de Núcleo
- [ ] Revisar costo de teletransportes
- [ ] Ajustar penalización por muerte
- [ ] Balancear recompensas de secretos
- [ ] Revisar progresión de poder del jugador
- [ ] Asegurar que recursos sean suficientes para completar juego
- [ ] Testear economía en speedrun vs 100% completion
- [ ] Documentar economía balanceada

**Dependencias:** Tarea 6.2.1  
**Prioridad:** Media  
**Esfuerzo Estimado:** 1 semana

---

#### **FASE 6.3: Optimización**

##### **Tarea 6.3.1: Optimización de Rendimiento**
**Descripción:** Asegurar 60 FPS estables en plataformas objetivo

**Checklist:**
- [ ] Perfilar juego con profiler (CPU, GPU, memoria)
- [ ] Optimizar draw calls (batching, atlases)
- [ ] Implementar object pooling para enemigos y proyectiles
- [ ] Optimizar particle systems (límites, LOD)
- [ ] Reducir garbage collection (evitar allocations en Update)
- [ ] Implementar culling agresivo fuera de cámara
- [ ] Optimizar pathfinding (cache, update rate)
- [ ] Comprimir texturas y audio
- [ ] Implementar niveles de calidad gráfica
- [ ] Testear en hardware mínimo (Steam Deck)
- [ ] Asegurar carga de niveles < 3 segundos

**Dependencias:** Tarea 6.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2 semanas

---

#### **FASE 6.4: Playtesting Externo**

##### **Tarea 6.4.1: Beta Testing**
**Descripción:** Testing con jugadores externos

**Checklist:**
- [ ] Reclutar beta testers (20-50 personas)
- [ ] Crear build de beta con telemetría
- [ ] Distribuir build (Steam beta branch, itch.io)
- [ ] Crear formulario de feedback
- [ ] Recopilar datos de telemetría (heatmaps, muertes, tiempo)
- [ ] Analizar feedback cualitativo
- [ ] Identificar patrones de problemas
- [ ] Priorizar cambios basados en feedback
- [ ] Implementar mejoras críticas
- [ ] Realizar segunda ronda de beta si es necesario

**Dependencias:** Tarea 6.3.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 2-3 semanas

---

### **ETAPA 7: Release & Post-Launch**
**Duración Estimada:** 2-4 semanas  
**Objetivo:** Preparar lanzamiento y soporte post-launch

---

#### **FASE 7.1: Preparación de Release**

##### **Tarea 7.1.1: Build Final**
**Descripción:** Crear build de producción

**Checklist:**
- [ ] Remover debug tools y cheats
- [ ] Configurar build settings (optimización, compresión)
- [ ] Crear builds para todas las plataformas (Windows, Linux, Mac)
- [ ] Testear builds en máquinas limpias
- [ ] Verificar que save system funciona en todas las plataformas
- [ ] Comprobar que no hay assets faltantes
- [ ] Validar tamaño de build (< 2GB recomendado)
- [ ] Crear installer/executable
- [ ] Firmar ejecutables (Windows)
- [ ] Preparar archivos de distribución (README, licencias)

**Dependencias:** Tarea 6.4.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

##### **Tarea 7.1.2: Materiales de Marketing**
**Descripción:** Preparar assets para store pages

**Checklist:**
- [ ] Crear trailer de lanzamiento (1-2 minutos)
- [ ] Capturar screenshots de alta calidad (10-15)
- [ ] Diseñar key art y capsule images (Steam)
- [ ] Escribir descripción de store page
- [ ] Crear GIFs para redes sociales
- [ ] Preparar press kit (assets, fact sheet)
- [ ] Configurar Steam page (descripción, tags, precio)
- [ ] Preparar materiales para itch.io/Epic/GOG
- [ ] Crear página web del juego (opcional)
- [ ] Preparar comunicados de prensa

**Dependencias:** Tarea 7.1.1  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1-2 semanas

---

##### **Tarea 7.1.3: Lanzamiento**
**Descripción:** Publicar el juego

**Checklist:**
- [ ] Subir build a Steam (Steamworks)
- [ ] Configurar pricing y regiones
- [ ] Establecer fecha de lanzamiento
- [ ] Activar store page
- [ ] Distribuir keys de prensa
- [ ] Publicar en redes sociales
- [ ] Enviar comunicados a medios
- [ ] Monitorear primeras reviews
- [ ] Responder a feedback de comunidad
- [ ] Preparar para hotfixes si es necesario

**Dependencias:** Tarea 7.1.2  
**Prioridad:** Alta  
**Esfuerzo Estimado:** 1 semana

---

#### **FASE 7.2: Post-Launch**

##### **Tarea 7.2.1: Soporte y Parches**
**Descripción:** Mantener el juego post-lanzamiento

**Checklist:**
- [ ] Monitorear crash reports y bug reports
- [ ] Priorizar bugs reportados por comunidad
- [ ] Crear hotfix para bugs críticos (semana 1)
- [ ] Lanzar patch 1.1 con correcciones (mes 1)
- [ ] Implementar mejoras de QoL basadas en feedback
- [ ] Optimizar rendimiento en hardware problemático
- [ ] Actualizar documentación y FAQs
- [ ] Mantener comunicación con comunidad
- [ ] Considerar ports a consolas
- [ ] Planificar contenido post-launch (DLC, updates)

**Dependencias:** Tarea 7.1.3  
**Prioridad:** Alta  
**Esfuerzo Estimado:** Ongoing (3-6 meses)

---

## 🚨 Riesgos y Mitigaciones

### Riesgos Técnicos

| Riesgo | Probabilidad | Impacto | Mitigación |
|--------|--------------|---------|------------|
| **Scope creep** | Alta | Alto | Definir MVP estricto, feature freeze tras Alpha |
| **Problemas de rendimiento** | Media | Alto | Optimizar desde early stages, perfilar frecuentemente |
| **Bugs de save system** | Media | Crítico | Testing exhaustivo, backups automáticos |
| **Dificultad de balanceo** | Alta | Medio | Playtesting temprano y frecuente, telemetría |
| **Complejidad de IA** | Media | Medio | Usar FSM simple primero, iterar después |
| **Problemas de física** | Media | Alto | Usar valores fijos, evitar física compleja |

### Riesgos de Producción

| Riesgo | Probabilidad | Impacto | Mitigación |
|--------|--------------|---------|------------|
| **Falta de recursos (arte/audio)** | Media | Alto | Asset store, colaboraciones, simplificar estilo |
| **Burnout del equipo** | Alta | Alto | Sprints sostenibles, breaks regulares |
| **Cambios de diseño tardíos** | Media | Alto | Prototipar mecánicas core primero, validar temprano |
| **Problemas de marketing** | Media | Medio | Empezar marketing 3-6 meses antes, build community |

---

## 📅 Timeline Estimado

```
Mes 1-2:   Preproducción + Vertical Slice (M0, M1)
Mes 3:     Core Systems (M2)
Mes 4-5:   Gameplay Expansion + First Playable (M3)
Mes 6-8:   World Building + Biomas (M4 - Alpha)
Mes 9-10:  Polish + Testing (M5 - Beta)
Mes 11-12: QA Final + Release Prep (M6 - Gold)
Mes 13+:   Post-Launch Support
```

**Duración Total Estimada:** 12-15 meses (equipo indie de 2-4 personas)

---

## ✅ Checklist de Hitos

### Milestone 0: Setup (Semana 1-2)
- [ ] Engine seleccionado y configurado
- [ ] Repositorio Git inicializado
- [ ] Pipeline de desarrollo establecido
- [ ] Arquitectura base documentada

### Milestone 1: Vertical Slice (Mes 1-2)
- [ ] Movimiento básico funcional (correr, saltar, dash)
- [ ] Combate básico implementado
- [ ] 1 nivel pequeño jugable (5-10 min)
- [ ] 2 tipos de enemigos funcionales
- [ ] Cámara con smoothing
- [ ] Feedback visual básico

### Milestone 2: Core Systems (Mes 3)
- [ ] Todas las habilidades de movimiento implementadas
- [ ] Sistema de energía funcional
- [ ] Combate pulido con combos
- [ ] Sistema de vida y muerte
- [ ] Cámara con efectos (shake, zoom)

### Milestone 3: First Playable (Mes 4-5)
- [ ] Sistema de implantes funcional
- [ ] IA avanzada con FSM
- [ ] 1 bioma completo (Bosques Corruptos)
- [ ] 1 jefe funcional
- [ ] Sistema de save/checkpoints
- [ ] Economía básica (Energía Arcana)

### Milestone 4: Alpha (Mes 6-8)
- [ ] 4 biomas completos
- [ ] 4 jefes implementados
- [ ] Todos los implantes funcionales
- [ ] Sistema de mapa completo
- [ ] Teletransporte funcional
- [ ] Contenido jugable de inicio a fin

### Milestone 5: Beta (Mes 9-10)
- [ ] Todo el contenido implementado
- [ ] UI/UX completa y pulida
- [ ] Audio completo (música + SFX)
- [ ] Accesibilidad implementada
- [ ] Balance inicial completado
- [ ] Bugs críticos resueltos

### Milestone 6: Gold Master (Mes 11-12)
- [ ] Todos los bugs resueltos
- [ ] Optimización completada (60 FPS estable)
- [ ] Balance final
- [ ] Playtesting externo completado
- [ ] Build final para todas las plataformas
- [ ] Materiales de marketing listos

---

## 📝 Notas Finales

### Prioridades de Desarrollo
1. **Feel del movimiento** - El pilar central del juego
2. **Arquitectura escalable** - Facilita iteración rápida
3. **Playtesting temprano** - Valida mecánicas core
4. **Optimización continua** - Evita deuda técnica

### Recomendaciones
- **Prototipar primero, pulir después** - No optimizar prematuramente
- **Iterar en base a feedback** - Playtesting frecuente
- **Mantener scope controlado** - Mejor un juego pequeño pulido que uno grande incompleto
- **Documentar decisiones** - Facilita onboarding y debugging

### Recursos Recomendados
- **Unity:** Cinemachine, New Input System, 2D Animation
- **Godot:** GDScript, TileMap, AnimationTree
- **Tools:** Aseprite (pixel art), Tiled (level design), FMOD (audio)
- **Assets:** Kenney.nl (placeholders), OpenGameArt

---

**Documento creado:** 2026-02-05  
**Versión:** 1.0  
**Basado en:** GDD 2.0 - Sombras del Umbral
