
using System.Collections.Generic;
using UnityEngine;

namespace IntoTheLight.Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/New PlayerScriptableObject")]
    public class PlayerSO : ScriptableObject
    {
        public float MaxHealth;
        public float speed;
        public float JumpForce;
        public int MaxExtraJumps;
        public float healthDraining;
        public float healthGaining;
        public Dictionary<string, string> PlayerAnim;
        public PlayerView player;
    }
}

