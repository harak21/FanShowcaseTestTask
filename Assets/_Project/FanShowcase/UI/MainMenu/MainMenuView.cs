using UnityEngine;
using UnityEngine.UI;

namespace FanShowcase.UI.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private ScrollRect scenesViewHandler;
        [SerializeField] private GameObject loadingCurtain;


        public void AddButton(Button button)
        {
            button.transform.parent = scenesViewHandler.content;
        }

        public void ShowLoadingCurtain()
        {
            gameObject.SetActive(true);
            loadingCurtain.SetActive(true);
        }

        public void HideLoadingCurtain()
        {
            loadingCurtain.SetActive(false);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}