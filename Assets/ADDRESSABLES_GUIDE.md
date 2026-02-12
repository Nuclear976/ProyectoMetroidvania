# 🚀 Addressables - Guía de Configuración

## ¿Qué son los Addressables?

Los **Addressables** son el sistema moderno de Unity para gestionar assets de forma eficiente. Reemplazan a Resources y AssetBundles con una API más simple y potente.

---

## ✨ Ventajas de Addressables

✅ **Beneficios:**
- Carga/descarga de assets bajo demanda
- Reduce tamaño del build inicial
- Permite contenido descargable (DLC)
- Mejor gestión de memoria
- Fácil actualización de contenido sin rebuild
- Soporte para carga remota (CDN)

❌ **Desventajas:**
- Complejidad adicional
- Curva de aprendizaje
- Overhead para proyectos pequeños

---

## 📦 Instalación

### 1. Instalar el paquete

1. Abrir **Window > Package Manager**
2. Buscar **"Addressables"**
3. Click en **Install**

O desde el Package Manager UI:
```
com.unity.addressables
```

### 2. Inicializar Addressables

1. **Window > Asset Management > Addressables > Groups**
2. Click en **Create Addressables Settings**

Esto crea:
- `Assets/AddressableAssetsData/` - Configuración
- Grupo "Default Local Group" por defecto

---

## 🏗️ Estructura Recomendada

```
Assets/AddressableAssetsData/
├── AssetGroups/
│   ├── Default Local Group.asset
│   ├── Player.asset          # Assets del jugador
│   ├── Enemies.asset          # Assets de enemigos
│   ├── Audio.asset            # Audio clips
│   └── UI.asset               # Sprites de UI
└── DataBuilders/
```

---

## 📝 Configuración Básica

### Crear Grupos de Assets

1. **Window > Asset Management > Addressables > Groups**
2. Click derecho > **Create New Group > Packed Assets**
3. Nombrar: `Player`, `Enemies`, `Audio`, etc.

### Hacer un Asset Addressable

**Opción 1: Inspector**
1. Seleccionar asset en Project
2. Marcar checkbox **"Addressable"**
3. Asignar una **Address** (nombre único)
4. Seleccionar **Group**

**Opción 2: Addressables Window**
1. Arrastrar asset a la ventana de Addressables Groups
2. Asignar al grupo correspondiente

---

## 💻 Uso en Código

### Cargar un Asset

```csharp
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableLoader : MonoBehaviour
{
    async void Start()
    {
        // Cargar por dirección (string)
        var handle = Addressables.LoadAssetAsync<GameObject>("EnemyPrefab");
        await handle.Task;
        
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = handle.Result;
            Instantiate(prefab);
        }
        
        // IMPORTANTE: Liberar cuando no se necesite
        Addressables.Release(handle);
    }
}
```

### Cargar con AssetReference

```csharp
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetReferenceLoader : MonoBehaviour
{
    [SerializeField] private AssetReference enemyPrefabRef;
    
    private AsyncOperationHandle<GameObject> handle;
    
    async void Start()
    {
        handle = enemyPrefabRef.LoadAssetAsync<GameObject>();
        await handle.Task;
        
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result);
        }
    }
    
    void OnDestroy()
    {
        // Liberar memoria
        if (handle.IsValid())
        {
            Addressables.Release(handle);
        }
    }
}
```

### Instanciar Directamente

```csharp
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DirectInstantiate : MonoBehaviour
{
    async void Start()
    {
        // Instanciar directamente (Unity gestiona la memoria)
        var handle = Addressables.InstantiateAsync("EnemyPrefab", transform.position, Quaternion.identity);
        await handle.Task;
        
        GameObject instance = handle.Result;
        
        // Cuando se destruya el GameObject, se libera automáticamente
    }
}
```

---

## 🎯 Ejemplo Completo: Addressable Manager

```csharp
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// Gestor centralizado para Addressables.
    /// </summary>
    public class AddressableManager : MonoBehaviour
    {
        private static AddressableManager instance;
        public static AddressableManager Instance => instance;
        
        private Dictionary<string, AsyncOperationHandle> loadedAssets;
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                loadedAssets = new Dictionary<string, AsyncOperationHandle>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// Carga un asset de forma asíncrona.
        /// </summary>
        public async Task<T> LoadAsset<T>(string address) where T : Object
        {
            if (loadedAssets.TryGetValue(address, out AsyncOperationHandle existingHandle))
            {
                if (existingHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    return existingHandle.Result as T;
                }
            }
            
            var handle = Addressables.LoadAssetAsync<T>(address);
            await handle.Task;
            
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                loadedAssets[address] = handle;
                return handle.Result;
            }
            
            Debug.LogError($"Failed to load addressable: {address}");
            return null;
        }
        
        /// <summary>
        /// Libera un asset cargado.
        /// </summary>
        public void ReleaseAsset(string address)
        {
            if (loadedAssets.TryGetValue(address, out AsyncOperationHandle handle))
            {
                Addressables.Release(handle);
                loadedAssets.Remove(address);
            }
        }
        
        /// <summary>
        /// Libera todos los assets cargados.
        /// </summary>
        public void ReleaseAll()
        {
            foreach (var handle in loadedAssets.Values)
            {
                Addressables.Release(handle);
            }
            loadedAssets.Clear();
        }
        
        void OnDestroy()
        {
            ReleaseAll();
        }
    }
}
```

---

## 🔧 Configuración de Grupos

### Configuración Recomendada para Sombras del Umbral

**Player Group:**
- Build Path: `LocalBuildPath`
- Load Path: `LocalLoadPath`
- Contenido: Prefabs del jugador, sprites, animaciones

**Enemies Group:**
- Build Path: `LocalBuildPath`
- Load Path: `LocalLoadPath`
- Contenido: Prefabs de enemigos por tipo

**Audio Group:**
- Build Path: `LocalBuildPath`
- Load Path: `LocalLoadPath`
- Contenido: SFX, música (comprimido)

**UI Group:**
- Build Path: `LocalBuildPath`
- Load Path: `LocalLoadPath`
- Contenido: Sprites de UI, iconos

---

## 🚀 Build de Addressables

### Antes de hacer Build del juego

1. **Window > Asset Management > Addressables > Groups**
2. **Build > New Build > Default Build Script**

Esto genera los bundles en:
```
Library/com.unity.addressables/
```

### Build del Juego

Después de hacer build de Addressables:
1. **File > Build Settings**
2. **Build**

---

## 📊 Migración desde Resources

### Antes (Resources)
```csharp
GameObject prefab = Resources.Load<GameObject>("Prefabs/Enemy");
Instantiate(prefab);
```

### Después (Addressables)
```csharp
var handle = Addressables.LoadAssetAsync<GameObject>("Enemy");
await handle.Task;
Instantiate(handle.Result);
Addressables.Release(handle);
```

---

## ⚠️ Mejores Prácticas

### 1. Siempre Liberar Memoria

```csharp
// ✅ Correcto
var handle = Addressables.LoadAssetAsync<GameObject>("Enemy");
await handle.Task;
// ... usar asset ...
Addressables.Release(handle);

// ❌ Incorrecto (memory leak)
var handle = Addressables.LoadAssetAsync<GameObject>("Enemy");
await handle.Task;
// No se libera nunca
```

### 2. Usar AssetReference en Inspector

```csharp
// ✅ Correcto - Type-safe
[SerializeField] private AssetReference enemyRef;

// ❌ Menos seguro - string puede tener typos
[SerializeField] private string enemyAddress = "Enemy";
```

### 3. Organizar por Grupos Lógicos

```
✅ Correcto:
- Player (todo del jugador)
- Enemies (todos los enemigos)
- Audio (todo el audio)

❌ Incorrecto:
- Default Local Group (todo mezclado)
```

### 4. Precargar Assets Críticos

```csharp
async void Start()
{
    // Precargar assets que se usarán pronto
    await Addressables.LoadAssetAsync<GameObject>("PlayerPrefab").Task;
    await Addressables.LoadAssetAsync<GameObject>("UIPrefab").Task;
    
    // Ahora están en memoria, carga instantánea
}
```

---

## 🎯 Cuándo Usar Addressables

### ✅ Usar Addressables para:
- Assets grandes (modelos 3D, texturas HD, audio largo)
- Contenido que no siempre se necesita
- Diferentes variantes (idiomas, calidades)
- Contenido descargable (DLC)
- Optimización de memoria

### ❌ NO usar Addressables para:
- Assets muy pequeños (< 100KB)
- Assets que SIEMPRE se necesitan
- Prototipos rápidos
- Proyectos muy pequeños

---

## 📚 Recursos Adicionales

- [Documentación oficial de Unity](https://docs.unity3d.com/Packages/com.unity.addressables@latest)
- [Best Practices Guide](https://docs.unity3d.com/Packages/com.unity.addressables@latest/manual/BestPractices.html)

---

**Estado:** Opcional - No instalado por defecto  
**Recomendación:** Instalar cuando el proyecto crezca y necesites optimización  
**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral
