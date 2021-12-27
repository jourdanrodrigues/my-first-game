using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenBird
{
    public class GreenBird : MonoBehaviour
    {
        private Vector3 _initialPosition;
        [SerializeField] private float launchPower = 500;
        
        private void Awake()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            if (transform.position.y is > 10 or < -10 || transform.position.x is > 10 or < -10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private void OnMouseUp()
        {
            Vector2 toDirection = _initialPosition - transform.position;
            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.AddForce(toDirection * launchPower);
            rigidBody.gravityScale = 1;
        }
        private void OnMouseDrag()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}