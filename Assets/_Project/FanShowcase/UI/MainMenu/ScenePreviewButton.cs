using UnityEngine;
using UnityEngine.UI;

namespace FanShowcase.UI.MainMenu
{
    public class ScenePreviewButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image preview;

        public Button Button => button;

        public void SetPreview(Sprite sprite)
        {
            preview.sprite = sprite;
        }
    }
}