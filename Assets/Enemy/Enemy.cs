using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var wasHitByBird = collision.collider.GetComponent<GreenBird.GreenBird>() != null;
            var wasHitFromTop = collision.contacts[0].normal.y < -0.5;
            if (!(wasHitByBird || wasHitFromTop)) return;
            Destroy(gameObject);
        }
    }
}
