using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float lifeSpan = 1.0f;
    private float startTime;

    [SerializeField]
    GameObject explosion;

    void Update()
    {
        if (!isServer) return;
        //transform.Translate(new Vector3(1, 1, 1) * speed * Time.smoothDeltaTime);
        transform.position += transform.up * Time.deltaTime * speed;
        //transform.Rotate(0, speed * Time.deltaTime * 5, 0);
        CheckLifeSpan();
    }


    void OnEnable()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    private void CheckLifeSpan()
    {
        if (Time.timeSinceLevelLoad - startTime > lifeSpan)
        {
            //This sets the object inactive for the pool to reuse
            SendMessage("SetObjectInactive", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}