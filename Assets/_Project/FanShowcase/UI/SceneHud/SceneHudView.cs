using UnityEngine;
using UnityEngine.UI;

namespace FanShowcase.UI.SceneHud
{
    public class SceneHudView : MonoBehaviour
    {
        
        [SerializeField] private ScrollRect viewButtonPlace;

        public void AddViewButton(Button button)
        {
            button.transform.parent = viewButtonPlace.content;
        }
    }
}