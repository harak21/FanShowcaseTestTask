using System.Collections.Generic;
using UnityEngine;

namespace FanShowcase.Utility.Configs
{
    [CreateAssetMenu(fileName = "ScenesConfigRepository", menuName = "FanShowcase/ScenesConfigRepository", order = 0)]
    public class ScenesConfigRepository : ScriptableObject
    {
        [SerializeField] private List<SceneConfig> sceneConfigs = new();
        [SerializeField] private SceneConfig mainMenu;

        public System.Collections.ObjectModel.ReadOnlyCollection<SceneConfig> SceneConfigs => sceneConfigs.AsReadOnly();

        public SceneConfig MainMenu => mainMenu;

        public SceneConfig this[int id] => sceneConfigs.Find(s => s.ID == id);
    }
}