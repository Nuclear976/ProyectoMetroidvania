# 📦 Resources Folder - Guía de Uso

## ⚠️ Carpeta Resources en Unity

La carpeta `Resources` permite cargar assets dinámicamente en runtime usando `Resources.Load()`.

---

## 📁 Estructura Recomendada

```
Assets/Resources/
├── Prefabs/          # Prefabs cargables dinámicamente
├── Audio/            # Audio clips
├── Sprites/          # Sprites dinámicos
├── ScriptableObjects/ # ScriptableObjects dinámicos
└── Data/             # Otros datos
```

---

## 💡 Uso de Resources.Load()

### Cargar un Prefab

```csharp
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    void Start()
    {
        // Cargar prefab desde Resources/Prefabs/
        GameObject prefab = Resources.Load<GameObject>("Prefabs/EnemyPrefab");
        
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
```

### Cargar un ScriptableObject

```csharp
using UnityEngine;
using SombrasDelUmbral.Player;

public class DataLoader : MonoBehaviour
{
    void Start()
    {
        // Cargar desde Resources/ScriptableObjects/
        PlayerDataSO playerData = Resources.Load<PlayerDataSO>("ScriptableObjects/DefaultPlayerData");
        
        if (playerData != null)
        {
            float speed = playerData.MoveSpeed;
        }
    }
}
```

### Cargar Audio Clip

```csharp
using UnityEngine;

public class AudioLoader : MonoBehaviour
{
    void Start()
    {
        // Cargar desde Resources/Audio/
        AudioClip clip = Resources.Load<AudioClip>("Audio/sfx_jump");
        
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
```

### Cargar todos los assets de un tipo

```csharp
// Cargar todos los PlayerDataSO
PlayerDataSO[] allPlayerData = Resources.LoadAll<PlayerDataSO>("ScriptableObjects");

foreach (var data in allPlayerData)
{
    Debug.Log($"Loaded: {data.DisplayName}");
}
```

---

## ⚠️ Advertencias Importantes

### 1. NO Abusar de Resources

**❌ Problemas:**
- Aumenta el tamaño del build
- Todo se carga en memoria al inicio
- No se puede descargar de memoria fácilmente
- Dificulta la optimización

**✅ Alternativas mejores:**
- **Addressables** - Para assets grandes o que se cargan bajo demanda
- **AssetBundles** - Para contenido descargable
- **Referencias directas** - Para assets conocidos en tiempo de diseño

### 2. Cuándo SÍ usar Resources

✅ **Usar Resources para:**
- Assets que SIEMPRE se necesitan en runtime
- Configuraciones globales
- Assets de fallback/default
- Prototipos rápidos

❌ **NO usar Resources para:**
- Assets grandes (texturas, audio largo)
- Assets que solo se usan en ciertas escenas
- Contenido descargable/DLC
- Assets que cambian frecuentemente

### 3. Organización

```csharp
// ✅ Buena práctica: usar constantes
public static class ResourcePaths
{
    public const string PLAYER_DATA = "ScriptableObjects/DefaultPlayerData";
    public const string ENEMY_PREFAB = "Prefabs/EnemyMelee";
    public const string SFX_JUMP = "Audio/sfx_jump";
}

// Uso
PlayerDataSO data = Resources.Load<PlayerDataSO>(ResourcePaths.PLAYER_DATA);
```

---

## 🔄 Descargar Assets de Memoria

```csharp
// Descargar un asset específico
Resources.UnloadAsset(asset);

// Descargar assets no usados (llamar con cuidado)
Resources.UnloadUnusedAssets();
```

---

## 📝 Ejemplo Completo: Resource Manager

```csharp
using UnityEngine;
using System.Collections.Generic;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// Gestor centralizado para cargar recursos desde Resources.
    /// </summary>
    public class ResourceManager : MonoBehaviour
    {
        private static ResourceManager instance;
        public static ResourceManager Instance => instance;
        
        private Dictionary<string, Object> cachedResources;
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                cachedResources = new Dictionary<string, Object>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// Carga un recurso con caché.
        /// </summary>
        public T Load<T>(string path) where T : Object
        {
            if (cachedResources.TryGetValue(path, out Object cached))
            {
                return cached as T;
            }
            
            T resource = Resources.Load<T>(path);
            
            if (resource != null)
            {
                cachedResources[path] = resource;
            }
            else
            {
                Debug.LogError($"No se pudo cargar recurso: {path}");
            }
            
            return resource;
        }
        
        /// <summary>
        /// Limpia la caché de recursos.
        /// </summary>
        public void ClearCache()
        {
            cachedResources.Clear();
            Resources.UnloadUnusedAssets();
        }
    }
}
```

---

## 🎯 Migración a Addressables (Futuro)

Cuando el proyecto crezca, considera migrar a Addressables:

```csharp
// Resources (actual)
GameObject prefab = Resources.Load<GameObject>("Prefabs/Enemy");

// Addressables (futuro)
var handle = Addressables.LoadAssetAsync<GameObject>("Enemy");
await handle.Task;
GameObject prefab = handle.Result;
```

---

## ✅ Checklist de Uso

Antes de poner algo en Resources, pregúntate:

- [ ] ¿Se necesita SIEMPRE en runtime?
- [ ] ¿No es demasiado grande (< 1MB)?
- [ ] ¿No hay una alternativa mejor (referencias directas)?
- [ ] ¿Está organizado en subcarpetas?
- [ ] ¿Usas constantes para las rutas?

---

**Última actualización:** 2026-02-12  
**Versión Unity:** 6000.1.13f1  
**Proyecto:** Sombras del Umbral

**Nota:** En el futuro, considera migrar a **Addressables** para mejor control y optimización.
