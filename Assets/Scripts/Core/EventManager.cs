using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// EventManager para comunicación desacoplada entre sistemas.
    /// Implementa el patrón Singleton y permite suscripción/desuscripción a eventos.
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        #region Singleton
        
        private static EventManager instance;
        
        /// <summary>
        /// Instancia única del EventManager.
        /// </summary>
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("EventManager no encontrado en la escena.");
                }
                return instance;
            }
        }
        
        #endregion
        
        #region Private Fields
        
        private Dictionary<string, UnityEvent> eventDictionary;
        private Dictionary<string, UnityEvent<object>> eventDictionaryWithParam;
        private bool isInitialized;
        
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
                Destroy(gameObject);
                return;
            }
        }
        
        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
        
        #endregion
        
        #region Initialization
        
        private void Initialize()
        {
            if (isInitialized)
                return;
            
            eventDictionary = new Dictionary<string, UnityEvent>();
            eventDictionaryWithParam = new Dictionary<string, UnityEvent<object>>();
            
            isInitialized = true;
            Debug.Log("[EventManager] Inicializado");
        }
        
        #endregion
        
        #region Event Management (Sin Parámetros)
        
        /// <summary>
        /// Suscribe un listener a un evento sin parámetros.
        /// </summary>
        public static void StartListening(string eventName, UnityAction listener)
        {
            if (Instance == null)
                return;
            
            UnityEvent thisEvent = null;
            
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance.eventDictionary.Add(eventName, thisEvent);
            }
        }
        
        /// <summary>
        /// Desuscribe un listener de un evento sin parámetros.
        /// </summary>
        public static void StopListening(string eventName, UnityAction listener)
        {
            if (Instance == null)
                return;
            
            UnityEvent thisEvent = null;
            
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
        
        /// <summary>
        /// Dispara un evento sin parámetros.
        /// </summary>
        public static void TriggerEvent(string eventName)
        {
            if (Instance == null)
                return;
            
            UnityEvent thisEvent = null;
            
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
        
        #endregion
        
        #region Event Management (Con Parámetros)
        
        /// <summary>
        /// Suscribe un listener a un evento con parámetro.
        /// </summary>
        public static void StartListening(string eventName, UnityAction<object> listener)
        {
            if (Instance == null)
                return;
            
            UnityEvent<object> thisEvent = null;
            
            if (Instance.eventDictionaryWithParam.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent<object>();
                thisEvent.AddListener(listener);
                Instance.eventDictionaryWithParam.Add(eventName, thisEvent);
            }
        }
        
        /// <summary>
        /// Desuscribe un listener de un evento con parámetro.
        /// </summary>
        public static void StopListening(string eventName, UnityAction<object> listener)
        {
            if (Instance == null)
                return;
            
            UnityEvent<object> thisEvent = null;
            
            if (Instance.eventDictionaryWithParam.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
        
        /// <summary>
        /// Dispara un evento con parámetro.
        /// </summary>
        public static void TriggerEvent(string eventName, object param)
        {
            if (Instance == null)
                return;
            
            UnityEvent<object> thisEvent = null;
            
            if (Instance.eventDictionaryWithParam.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(param);
            }
        }
        
        #endregion
        
        #region Utility Methods
        
        /// <summary>
        /// Limpia todos los eventos registrados.
        /// </summary>
        public static void ClearAllEvents()
        {
            if (Instance == null)
                return;
            
            Instance.eventDictionary.Clear();
            Instance.eventDictionaryWithParam.Clear();
            Debug.Log("[EventManager] Todos los eventos limpiados");
        }
        
        #endregion
    }
}
