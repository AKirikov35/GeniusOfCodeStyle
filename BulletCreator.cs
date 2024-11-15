using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;

    public Bullet Create(Vector3 position, Vector3 direction)
    {
        if(_prefab == null)
            return null;

        return Instantiate(_prefab, position + direction, Quaternion.identity);
    }
}
