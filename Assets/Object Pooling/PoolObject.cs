using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public virtual void OnObjectReuse()
    {
        //Debug.Log("GOOD");
    }

    protected void Destroy()
    {
        gameObject.SetActive(false);
    }
}