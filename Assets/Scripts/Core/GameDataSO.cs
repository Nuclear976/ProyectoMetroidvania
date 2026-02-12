using UnityEngine;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// ScriptableObject base para todos los datos de juego.
    /// Proporciona funcionalidad común para todos los ScriptableObjects del proyecto.
    /// </summary>
    public abstract class GameDataSO : ScriptableObject
    {
        [Header("Base Data")]
        [SerializeField] private string id;
        [SerializeField] private string displayName;
        [TextArea(3, 5)]
        [SerializeField] private string description;
        
        /// <summary>
        /// ID único del dato.
        /// </summary>
        public string ID => id;
        
        /// <summary>
        /// Nombre para mostrar en UI.
        /// </summary>
        public string DisplayName => displayName;
        
        /// <summary>
        /// Descripción del dato.
        /// </summary>
        public string Description => description;
        
        /// <summary>
        /// Valida que los datos del ScriptableObject sean correctos.
        /// Sobreescribir en clases derivadas para validación específica.
        /// </summary>
        public virtual bool Validate()
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogError($"[{name}] ID no puede estar vacío", this);
                return false;
            }
            
            if (string.IsNullOrEmpty(displayName))
            {
                Debug.LogWarning($"[{name}] DisplayName no está configurado", this);
            }
            
            return true;
        }
        
        /// <summary>
        /// Inicializa el ScriptableObject.
        /// Sobreescribir en clases derivadas para inicialización específica.
        /// </summary>
        public virtual void Initialize()
        {
            // Implementar en clases derivadas si es necesario
        }
        
#if UNITY_EDITOR
        /// <summary>
        /// Validación automática en el Editor.
        /// </summary>
        private void OnValidate()
        {
            // Auto-generar ID si está vacío
            if (string.IsNullOrEmpty(id))
            {
                id = name;
            }
            
            Validate();
        }
#endif
    }
}
