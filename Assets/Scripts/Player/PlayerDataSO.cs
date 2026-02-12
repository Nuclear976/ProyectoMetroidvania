using UnityEngine;
using SombrasDelUmbral.Core;

namespace SombrasDelUmbral.Player
{
    /// <summary>
    /// ScriptableObject para configuración del jugador.
    /// Contiene todos los parámetros configurables del jugador.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Sombras del Umbral/Player/Player Data")]
    public class PlayerDataSO : GameDataSO
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float sprintMultiplier = 1.5f;
        [SerializeField] private float acceleration = 10f;
        [SerializeField] private float deceleration = 15f;
        
        [Header("Jump")]
        [SerializeField] private float jumpForce = 12f;
        [SerializeField] private int maxJumps = 2;
        [SerializeField] private float jumpBufferTime = 0.1f;
        [SerializeField] private float coyoteTime = 0.15f;
        
        [Header("Dash")]
        [SerializeField] private float dashSpeed = 15f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldown = 1f;
        
        [Header("Combat")]
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private float attackDamage = 25f;
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackCooldown = 0.5f;
        
        [Header("Energy")]
        [SerializeField] private float maxEnergy = 100f;
        [SerializeField] private float energyRegenRate = 10f;
        [SerializeField] private float energyRegenDelay = 2f;
        
        // Movement Properties
        public float MoveSpeed => moveSpeed;
        public float SprintMultiplier => sprintMultiplier;
        public float Acceleration => acceleration;
        public float Deceleration => deceleration;
        
        // Jump Properties
        public float JumpForce => jumpForce;
        public int MaxJumps => maxJumps;
        public float JumpBufferTime => jumpBufferTime;
        public float CoyoteTime => coyoteTime;
        
        // Dash Properties
        public float DashSpeed => dashSpeed;
        public float DashDuration => dashDuration;
        public float DashCooldown => dashCooldown;
        
        // Combat Properties
        public int MaxHealth => maxHealth;
        public float AttackDamage => attackDamage;
        public float AttackRange => attackRange;
        public float AttackCooldown => attackCooldown;
        
        // Energy Properties
        public float MaxEnergy => maxEnergy;
        public float EnergyRegenRate => energyRegenRate;
        public float EnergyRegenDelay => energyRegenDelay;
        
        public override bool Validate()
        {
            if (!base.Validate())
                return false;
            
            if (moveSpeed <= 0)
            {
                Debug.LogError($"[{name}] MoveSpeed debe ser mayor que 0", this);
                return false;
            }
            
            if (maxHealth <= 0)
            {
                Debug.LogError($"[{name}] MaxHealth debe ser mayor que 0", this);
                return false;
            }
            
            return true;
        }
    }
}
