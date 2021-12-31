using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenBird
{
    public class GreenBird : MonoBehaviour
    {
        private Vector3 _initialPosition;
        private bool _wasLaunched;
        private float _timeStill;

        [SerializeField] private float launchPower = 250;

        private void Awake()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            ShowPathHint();
            TrackStillness();
            if (ShouldReloadScene())
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnMouseDown()
        {
            GetComponent<LineRenderer>().enabled = true;
        }

        private void OnMouseUp()
        {
            GetComponent<LineRenderer>().enabled = false;
            Vector2 toDirection = _initialPosition - transform.position;
            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.AddForce(toDirection * launchPower);
            rigidBody.gravityScale = 1;
            _wasLaunched = true;
        }

        private void OnMouseDrag()
        {
            if (Camera.main == null) return;
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

        private void ShowPathHint()
        {
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.SetPosition(0, _initialPosition);
        }

        private void TrackStillness()
        {
            if (!_wasLaunched) return;
            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
                _timeStill += Time.deltaTime;
            else
                _timeStill = 0;
        }

        private bool ShouldReloadScene()
        {
            var position = transform.position;
            return position.y is > 10 or < -10 || position.x is > 20 or < -20 || _timeStill > 3;
        }
    }
}
