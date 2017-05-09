using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] private AudioSource laser;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject spawn;

    private void Start()
    {
        PoolManager.instance.CreatePool(prefab, 10);
    }

    public void Shoot()
    {
        PoolManager.instance.ReuseObject(prefab, spawn.transform.position, spawn.transform.rotation);
    }
}