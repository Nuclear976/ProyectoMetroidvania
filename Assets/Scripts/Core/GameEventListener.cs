using UnityEngine;
using UnityEngine.Events;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// Listener para GameEventSO.
    /// Se añade a un GameObject para escuchar eventos de ScriptableObject.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        [Header("Event")]
        [Tooltip("El GameEvent ScriptableObject a escuchar")]
        [SerializeField] private GameEventSO gameEvent;
        
        [Header("Response")]
        [Tooltip("La respuesta a ejecutar cuando el evento se dispare")]
        [SerializeField] private UnityEvent response;
        
        private void OnEnable()
        {
            if (gameEvent != null)
            {
                gameEvent.RegisterListener(this);
            }
        }
        
        private void OnDisable()
        {
            if (gameEvent != null)
            {
                gameEvent.UnregisterListener(this);
            }
        }
        
        /// <summary>
        /// Llamado cuando el evento es disparado.
        /// </summary>
        public void OnEventRaised()
        {
            response?.Invoke();
        }
    }
}
