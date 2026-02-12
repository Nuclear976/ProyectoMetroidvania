using UnityEngine;
using SombrasDelUmbral.Core;

namespace SombrasDelUmbral.AI
{
    /// <summary>
    /// ScriptableObject para configuración de enemigos.
    /// Contiene todos los parámetros configurables de un tipo de enemigo.
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Sombras del Umbral/AI/Enemy Data")]
    public class EnemyDataSO : GameDataSO
    {
        [Header("Stats")]
        [SerializeField] private int maxHealth = 50;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float attackDamage = 10f;
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackCooldown = 1.5f;
        
        [Header("AI Behavior")]
        [SerializeField] private float detectionRange = 8f;
        [SerializeField] private float chaseRange = 12f;
        [SerializeField] private float patrolSpeed = 2f;
        [SerializeField] private float patrolWaitTime = 2f;
        
        [Header("Rewards")]
        [SerializeField] private int experienceReward = 10;
        [SerializeField] private float dropChance = 0.3f;
        
        // Stats Properties
        public int MaxHealth => maxHealth;
        public float MoveSpeed => moveSpeed;
        public float AttackDamage => attackDamage;
        public float AttackRange => attackRange;
        public float AttackCooldown => attackCooldown;
        
        // AI Properties
        public float DetectionRange => detectionRange;
        public float ChaseRange => chaseRange;
        public float PatrolSpeed => patrolSpeed;
        public float PatrolWaitTime => patrolWaitTime;
        
        // Rewards Properties
        public int ExperienceReward => experienceReward;
        public float DropChance => dropChance;
        
        public override bool Validate()
        {
            if (!base.Validate())
                return false;
            
            if (maxHealth <= 0)
            {
                Debug.LogError($"[{name}] MaxHealth debe ser mayor que 0", this);
                return false;
            }
            
            if (detectionRange <= 0)
            {
                Debug.LogError($"[{name}] DetectionRange debe ser mayor que 0", this);
                return false;
            }
            
            return true;
        }
    }
}
