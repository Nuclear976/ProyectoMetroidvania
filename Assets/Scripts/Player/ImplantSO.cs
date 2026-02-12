using UnityEngine;
using SombrasDelUmbral.Core;

namespace SombrasDelUmbral.Player
{
    /// <summary>
    /// Tipos de implantes disponibles en el juego.
    /// </summary>
    public enum ImplantType
    {
        Offensive,  // Mejora combate
        Defensive,  // Mejora defensa
        Mobility,   // Mejora movimiento
        Utility     // Utilidades varias
    }
    
    /// <summary>
    /// ScriptableObject para implantes cibernéticos.
    /// Los implantes otorgan habilidades y mejoras al jugador.
    /// </summary>
    [CreateAssetMenu(fileName = "ImplantSO", menuName = "Sombras del Umbral/Player/Implant")]
    public class ImplantSO : GameDataSO
    {
        [Header("Implant Info")]
        [SerializeField] private ImplantType implantType;
        [SerializeField] private Sprite icon;
        
        [Header("Stats Modifiers")]
        [SerializeField] private float healthModifier = 0f;
        [SerializeField] private float energyModifier = 0f;
        [SerializeField] private float damageModifier = 0f;
        [SerializeField] private float speedModifier = 0f;
        
        [Header("Special Abilities")]
        [SerializeField] private bool grantsDoubleJump = false;
        [SerializeField] private bool grantsWallJump = false;
        [SerializeField] private bool grantsDash = false;
        
        [Header("Energy Cost")]
        [SerializeField] private float energyCost = 0f;
        
        // Properties
        public ImplantType Type => implantType;
        public Sprite Icon => icon;
        
        public float HealthModifier => healthModifier;
        public float EnergyModifier => energyModifier;
        public float DamageModifier => damageModifier;
        public float SpeedModifier => speedModifier;
        
        public bool GrantsDoubleJump => grantsDoubleJump;
        public bool GrantsWallJump => grantsWallJump;
        public bool GrantsDash => grantsDash;
        
        public float EnergyCost => energyCost;
        
        public override bool Validate()
        {
            if (!base.Validate())
                return false;
            
            if (icon == null)
            {
                Debug.LogWarning($"[{name}] Icon no está asignado", this);
            }
            
            return true;
        }
    }
}
