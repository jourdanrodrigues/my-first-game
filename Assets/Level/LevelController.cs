using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelController : MonoBehaviour
    {
        private Enemy.Enemy[] _enemies;
        private static int _nextLevelIndex = 1;

        private void OnEnable()
        {
            _enemies = FindObjectsOfType<Enemy.Enemy>();
        }

        private void Update()
        {
            if (_enemies.Any(enemy => enemy != null)) return;

            SceneManager.LoadScene("Level" + ++_nextLevelIndex);
        }
    }
}
