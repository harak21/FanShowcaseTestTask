using UnityEngine;
using UnityEngine.EventSystems;

namespace FanShowcase.Core.Scene
{
    [RequireComponent(typeof(Collider))]
    public abstract class SelectableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        //I wanted to use unirx, but its extensions didn't work.
        //I was probably doing something wrong. But, for now, let's do it the standard way. 
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExit();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClick();
        }

        protected abstract void OnPointerEnter();
        protected abstract void OnPointerExit();
        protected abstract void OnPointerClick();
    }
}