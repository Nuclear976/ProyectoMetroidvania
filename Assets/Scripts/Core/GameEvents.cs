using System.Collections.Generic;

namespace SombrasDelUmbral.Core
{
    /// <summary>
    /// Nombres de eventos estándar del juego.
    /// Usar estas constantes para evitar errores de tipeo.
    /// </summary>
    public static class GameEvents
    {
        // Eventos de jugador
        public const string PLAYER_DEATH = "PlayerDeath";
        public const string PLAYER_RESPAWN = "PlayerRespawn";
        public const string PLAYER_DAMAGE_TAKEN = "PlayerDamageTaken";
        public const string PLAYER_HEALED = "PlayerHealed";
        
        // Eventos de combate
        public const string ENEMY_KILLED = "EnemyKilled";
        public const string BOSS_DEFEATED = "BossDefeated";
        
        // Eventos de progresión
        public const string CHECKPOINT_REACHED = "CheckpointReached";
        public const string ABILITY_UNLOCKED = "AbilityUnlocked";
        public const string IMPLANT_EQUIPPED = "ImplantEquipped";
        
        // Eventos de UI
        public const string GAME_PAUSED = "GamePaused";
        public const string GAME_RESUMED = "GameResumed";
        public const string MENU_OPENED = "MenuOpened";
        public const string MENU_CLOSED = "MenuClosed";
        
        // Eventos de mundo
        public const string DOOR_OPENED = "DoorOpened";
        public const string AREA_ENTERED = "AreaEntered";
        public const string ITEM_COLLECTED = "ItemCollected";
    }
}
