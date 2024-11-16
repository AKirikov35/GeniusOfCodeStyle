using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletCreator))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;

    private BulletCreator _bulletCreator;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _bulletCreator = GetComponent<BulletCreator>();
        _waitForSeconds = new WaitForSeconds(_shootDelay);
    }

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            Vector3 directionToTarget = (_target.position - transform.position).normalized;
            Bullet bullet = _bulletCreator.Create(transform.position, directionToTarget);
            bullet.Push(directionToTarget, _speed);

            yield return _waitForSeconds;
        }
    }
}
