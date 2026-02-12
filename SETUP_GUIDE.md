# Guía de Configuración Inicial - Sombras del Umbral
## Unity 6000.1.13f1

---

## 📋 **1. Physics 2D Settings**

### Ruta: `Edit > Project Settings > Physics 2D`

### Configuración de Gravedad:
```
Gravity Y: -25
```
*(Más responsivo que el -9.81 por defecto para plataformas 2D)*

---

## 🏷️ **2. Layers Configuration**

### Ruta: `Edit > Project Settings > Tags and Layers`

Crear las siguientes layers en los índices indicados:

| Índice | Nombre Layer | Uso |
|--------|--------------|-----|
| 6 | `Ground` | Plataformas y suelo |
| 7 | `Wall` | Paredes para wall-jump |
| 8 | `Player` | Protagonista |
| 9 | `Enemy` | Enemigos |
| 10 | `Hazard` | Pinchos, lava, trampas |
| 11 | `PlayerAttack` | Hitbox de ataques del jugador |
| 12 | `EnemyAttack` | Hitbox de ataques enemigos |
| 13 | `Pickup` | Items, energía, cristales |
| 14 | `Trigger` | Zonas de activación, checkpoints |
| 15 | `Invulnerable` | Player durante dash/i-frames |

---

## 🎯 **3. Layer Collision Matrix**

### Ruta: `Edit > Project Settings > Physics 2D` (scroll hasta abajo)

Configurar las colisiones según esta matriz triangular (basada en el roadmap del juego):

**✅ = Marcar checkbox (colisiona) | ❌ = Desmarcar (no colisiona)**

```
                              I  T  P  E  P  H  E  G  W  U  W  P  I  T  D
                              n  r  i  n  l  a  n  r  a  I  a  l  g  r  e
                              v  i  c  e  a  z  e  o  l     t  a  n  a  f
                              u  g  k  m  y  a  m  u  l     e  y  o  n  a
                              l  g  u  y  e  r  y  n     r  e  r  s  u
                              n  e  p  A  r  d     d        r  e  p  l
                              e  r     t  A              a  a  t
                              r        t  t              r  n  r
                              a        a  a              y  s  a
                              b        c  c              c  p  n
                              l        k  k              a  a  s
                              e                          s  r  p
                                                         t  e  a
                                                            n  r
                                                            t  e
                                                            F  n
                                                            X  t

Default                       ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ✅ ✅
TransparentFX                 ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ✅ ✅
Ignore Raycast                ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌
Player                        ❌ ✅ ✅ ✅ ❌ ✅ ✅ ✅ ✅ ❌ ❌ ❌
Water                         ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌
UI                            ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌ ❌
Wall                          ❌ ✅ ❌ ❌ ❌ ✅ ✅ ❌ ❌
Ground                        ❌ ✅ ❌ ❌ ❌ ✅ ✅ ❌
Enemy                         ❌ ✅ ✅ ✅ ✅ ✅ ✅
Hazard                        ❌ ❌ ❌ ❌ ✅ ✅
PlayerAttack                  ❌ ❌ ❌ ✅ ❌
EnemyAttack                   ❌ ❌ ❌
Pickup                        ❌ ❌
Trigger                       ❌
Invulnerable
```

### **Instrucciones para configurar en Unity:**

1. Ve a `Edit > Project Settings > Physics 2D`
2. Scroll hasta el final para ver "Layer Collision Matrix"
3. Busca cada layer en la matriz triangular
4. Marca/desmarca los checkboxes según la tabla de arriba

### **Configuración por layer (basada en roadmap):**

- **Player**: Colisiona con Ground, Wall, Enemy, Hazard, EnemyAttack, Pickup, Trigger
- **Enemy**: Colisiona con Ground, Wall, Player, Enemy, Hazard, PlayerAttack, Trigger
- **Ground**: Colisiona con Player, Enemy, Ground, Wall
- **Wall**: Colisiona con Player, Enemy, Ground, Wall
- **Hazard**: Colisiona con Player, Enemy
- **PlayerAttack**: Colisiona con Enemy (solo)
- **EnemyAttack**: Colisiona con Player (solo)
- **Pickup**: Colisiona con Player (trigger)
- **Trigger**: Colisiona con Player, Enemy (trigger)
- **Invulnerable**: No colisiona con nada (para dash/i-frames)

---

## 🎮 **4. Input System**

### Ruta: `Edit > Project Settings > Player > Other Settings`

**Active Input Handling:**
- Seleccionar: `Input System Package (New)`
- O si necesitas compatibilidad: `Both` (consume más recursos)

### Crear Input Actions Asset:
1. Crear carpeta: `Assets/_Project/Input/`
2. Click derecho > `Create > Input Actions`
3. Nombrar: `PlayerInputActions`
4. Configurar acciones básicas:
   - **Move**: Value, Vector2
   - **Jump**: Button
   - **Dash**: Button
   - **Attack**: Button

---

## 🎨 **5. Quality Settings**

### Ruta: `Edit > Project Settings > Quality`

### Crear 3 niveles de calidad:

#### **Low (para hardware limitado)**
```
VSync Count: Don't Sync
Anti Aliasing: Disabled
Shadows: Disable Shadows
Shadow Resolution: Low
Pixel Light Count: 2
Texture Quality: Half Res
```

#### **Medium (default - Steam Deck)**
```
VSync Count: Every V Blank
Anti Aliasing: 2x Multi Sampling
Shadows: Hard Shadows Only
Shadow Resolution: Medium
Pixel Light Count: 4
Texture Quality: Full Res
```

#### **High (PC potente)**
```
VSync Count: Every V Blank
Anti Aliasing: 4x Multi Sampling
Shadows: All
Shadow Resolution: High
Pixel Light Count: 4
Texture Quality: Full Res
```

**Establecer `Medium` como default**

---

## 🖥️ **6. Platform Settings**

### Ruta: `Edit > Project Settings > Player`

### PC Settings:
```
Company Name: [Tu nombre/estudio]
Product Name: Sombras del Umbral
Default Icon: [Tu icono]
Default Cursor: [Tu cursor]
```

### Resolution and Presentation:
```
Fullscreen Mode: Fullscreen Window
Default Screen Width: 1920
Default Screen Height: 1080
Run In Background: ✅ (checked)
```

---

## 🏗️ **7. Build Settings**

### Ruta: `File > Build Settings`

### Configuración:
```
Platform: PC, Mac & Linux Standalone
Target Platform: Windows
Architecture: x86_64
```

### Scenes a incluir:
1. MainMenu
2. GameScene
3. *(Añadir más según desarrollo)*

---

## ✅ **Checklist de Verificación**

- [ ] Gravity configurada a -25 en Physics 2D
- [ ] 10 layers creadas (Ground, Wall, Player, Enemy, etc.)
- [ ] Layer Collision Matrix configurada correctamente
- [ ] Input System configurado (New Input System)
- [ ] PlayerInputActions.inputactions creado
- [ ] 3 niveles de calidad creados (Low, Medium, High)
- [ ] Medium establecido como default
- [ ] Target Platform configurado (PC)
- [ ] Resolución default: 1920x1080
- [ ] Fullscreen Window activado

---

## 📝 **Notas Importantes**

1. **Invulnerable Layer**: Cambiar el player a esta layer temporalmente durante:
   - Dash (si tiene invulnerabilidad)
   - I-frames después de recibir daño
   - Usar script para cambiar: `gameObject.layer = LayerMask.NameToLayer("Invulnerable");`

2. **Triggers vs Collisions**: 
   - `Pickup` y `Trigger` deben usar `Collider2D.isTrigger = true`
   - Detectar con `OnTriggerEnter2D()` en lugar de `OnCollisionEnter2D()`

3. **PlayerAttack y EnemyAttack**:
   - Activar/desactivar hitbox según frames de animación
   - Usar Animation Events para timing preciso

---

**Última actualización:** 2026-02-05  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
