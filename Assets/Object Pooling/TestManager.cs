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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.instance.ReuseObject(prefab, spawn.transform.position, spawn.transform.rotation);
            //laser.Play();
        }
    }
}