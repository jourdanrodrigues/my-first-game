using UnityEngine;

namespace GreenBird
{
    public class GreenBird : MonoBehaviour
    {
        private Vector3 _initialPosition;
        
        private void Awake()
        {
            _initialPosition = transform.position;
        }
        private void OnMouseUp()
        {
            Vector2 toDirection = _initialPosition - transform.position;
            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.AddForce(toDirection * 100);
            rigidBody.gravityScale = 1;
        }
        private void OnMouseDrag()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}