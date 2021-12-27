using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GreenBird
{
    public class GreenBird : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        private void OnMouseUp()
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        private void OnMouseDrag()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}