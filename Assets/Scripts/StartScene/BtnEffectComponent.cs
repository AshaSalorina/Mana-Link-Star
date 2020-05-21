using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asha.Component
{
    public class BtnEffectComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}


