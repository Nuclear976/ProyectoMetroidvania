using UnityEngine;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// GameManager principal del juego.
    /// Gestiona el estado global del juego y persiste entre escenas.
    /// Implementa el patrón Singleton con DontDestroyOnLoad.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        
        private static GameManager instance;
        
        /// <summary>
        /// Instancia única del GameManager.
        /// </summary>
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("GameManager no encontrado en la escena. Asegúrate de que existe un GameObject con el componente GameManager.");
                }
                return instance;
            }
        }
        
        #endregion
        
        #region Serialized Fields
        
        [Header("Debug")]
        [SerializeField] private bool showDebugLogs = true;
        
        #endregion
        
        #region Private Fields
        
        private bool isInitialized;
        
        #endregion
        
        #region Public Properties
        
        /// <summary>
        /// Indica si el juego está en pausa.
        /// </summary>
        public bool IsPaused { get; private set; }
        
        /// <summary>
        /// Indica si el GameManager está inicializado.
        /// </summary>
        public bool IsInitialized => isInitialized;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Awake()
        {
            // Implementar Singleton pattern
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
            }
            else
            {
                // Si ya existe una instancia, destruir este objeto
                Destroy(gameObject);
                return;
            }
        }
        
        private void OnDestroy()
        {
            // Limpiar la instancia si este objeto es destruido
            if (instance == this)
            {
                instance = null;
            }
        }
        
        #endregion
        
        #region Initialization
        
        /// <summary>
        /// Inicializa el GameManager.
        /// </summary>
        private void Initialize()
        {
            if (isInitialized)
                return;
            
            LogDebug("GameManager inicializado");
            
            // Aquí se inicializarán otros sistemas cuando se creen
            // Ejemplo: EventManager, SaveSystem, etc.
            
            isInitialized = true;
        }
        
        #endregion
        
        #region Game State Management
        
        /// <summary>
        /// Pausa el juego.
        /// </summary>
        public void PauseGame()
        {
            if (IsPaused)
                return;
            
            IsPaused = true;
            Time.timeScale = 0f;
            LogDebug("Juego pausado");
            
            // Aquí se puede notificar a otros sistemas mediante eventos
        }
        
        /// <summary>
        /// Reanuda el juego.
        /// </summary>
        public void ResumeGame()
        {
            if (!IsPaused)
                return;
            
            IsPaused = false;
            Time.timeScale = 1f;
            LogDebug("Juego reanudado");
            
            // Aquí se puede notificar a otros sistemas mediante eventos
        }
        
        /// <summary>
        /// Reinicia el juego.
        /// </summary>
        public void RestartGame()
        {
            LogDebug("Reiniciando juego...");
            
            // Resetear Time.timeScale por si estaba pausado
            Time.timeScale = 1f;
            IsPaused = false;
            
            // Aquí se implementará la lógica de reinicio cuando exista SaveSystem
            // Por ahora, solo recargar la escena actual
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
        
        /// <summary>
        /// Sale del juego.
        /// </summary>
        public void QuitGame()
        {
            LogDebug("Saliendo del juego...");
            
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        
        #endregion
        
        #region Utility Methods
        
        /// <summary>
        /// Muestra un log de debug si está habilitado.
        /// </summary>
        private void LogDebug(string message)
        {
            if (showDebugLogs)
            {
                Debug.Log($"[GameManager] {message}");
            }
        }
        
        #endregion
    }
}
