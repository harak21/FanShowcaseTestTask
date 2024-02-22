using UnityEngine;

namespace FanShowcase.Utility.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfigRepository", menuName = "FanShowcase/PlayerConfigRepository", order = 0)]
    public class PlayerConfigRepository : ScriptableObject
    {
        [SerializeField] private PlayerConfig playerConfig;

        public PlayerConfig Config => playerConfig;
    }
}