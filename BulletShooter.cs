using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;

    private BulletCreator _bulletCreator;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        if (!TryGetComponent<BulletCreator>(out _bulletCreator))
            return;

        _waitForSeconds = new WaitForSeconds(_shootDelay);
    }

    private void Start()
    {
        _currentCoroutine = StartCoroutine(ShootingWorker());
    }

    private void StopShooting()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            Vector3 directionToTarget = (_target.position - transform.position).normalized;
            Bullet bullet = _bulletCreator.Create(transform.position, directionToTarget);

            if (bullet != null)
                bullet.Shoot(directionToTarget, _speed);

            yield return _waitForSeconds;
        }
    }
}