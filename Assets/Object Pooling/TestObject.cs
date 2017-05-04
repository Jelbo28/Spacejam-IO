using UnityEngine;

public class TestObject : PoolObject
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject explosion;

    void Update()
    {
        //transform.Translate(new Vector3(1, 1, 1) * speed * Time.smoothDeltaTime);
        transform.position += transform.up * Time.deltaTime * speed;
        transform.Rotate(0, speed * Time.deltaTime * 5, 0);
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
