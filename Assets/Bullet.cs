using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : NetworkBehaviour
{

    public Rigidbody rbody;
    [SerializeField]
    float force = 15f;
    public float lifeSpan = 1.0f;
    float startTime;

    void OnEnable()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isServer) return;

        if (rbody)
            rbody.velocity = transform.up * force;

        CheckLifeSpan();
    }

    private void CheckLifeSpan()
    {
        if (Time.timeSinceLevelLoad - startTime > lifeSpan)
        {
            //This sets the object inactive for the pool to reuse
            SendMessage("SetObjectInactive", SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnDisable()
    {
        if (!isServer) return;

        if (rbody)
            rbody.velocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isServer) return;
        if (other.tag == "Player")
            other.GetComponent<Health>().TakeDamage(1);
        if (other.name != "The Container")
            SendMessage("SetObjectInactive", SendMessageOptions.DontRequireReceiver);

    }
}
