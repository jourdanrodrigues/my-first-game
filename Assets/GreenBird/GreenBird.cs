using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenBird
{
    public class GreenBird : MonoBehaviour
    {
        private Vector3 _initialPosition;
        
        private void Awake()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            if (!(transform.position.y > 10)) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnMouseUp()
        {
            Vector2 toDirection = _initialPosition - transform.position;
            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.AddForce(toDirection * 600);
            rigidBody.gravityScale = 1;
        }
        private void OnMouseDrag()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}