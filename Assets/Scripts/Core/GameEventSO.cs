using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// ScriptableObject base para eventos sin parámetros.
    /// Permite comunicación desacoplada entre sistemas sin referencias directas.
    /// </summary>
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Sombras del Umbral/Events/Game Event")]
    public class GameEventSO : ScriptableObject
    {
        private readonly List<GameEventListener> listeners = new List<GameEventListener>();
        
        /// <summary>
        /// Dispara el evento, notificando a todos los listeners.
        /// </summary>
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }
        
        /// <summary>
        /// Registra un listener para este evento.
        /// </summary>
        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }
        
        /// <summary>
        /// Desregistra un listener de este evento.
        /// </summary>
        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
