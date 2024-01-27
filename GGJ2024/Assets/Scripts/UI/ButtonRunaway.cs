using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRunaway : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hoveringOver = false;
    [SerializeField] float speed = 4f;

    //Vector3 pos;
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoveringOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoveringOver = false;
    }

    private void Update()
    {
        if(hoveringOver)
        {
            // find mouse position, then move object in opposite direction
            Vector3 mouse = new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            transform.position -= mouse * speed;
        }
    }
}
