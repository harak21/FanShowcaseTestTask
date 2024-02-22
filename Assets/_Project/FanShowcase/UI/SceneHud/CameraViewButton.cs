using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FanShowcase.UI.SceneHud
{
    public class CameraViewButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text viewName;

        public Button Button => button;

        public void SetViewName(string newName)
        {
            viewName.text = newName;
        }
    }
}