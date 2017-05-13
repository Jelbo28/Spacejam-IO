using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            other.gameObject.GetComponent<Bullet>().lifeSpan = 0;
        }
        else if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyShip(1f, other.gameObject));
        }
        else
        {      
            Destroy(other.gameObject);
        }
    }

    IEnumerator DestroyShip(float waitTime, GameObject toDestroy)
    {
        Destroy(toDestroy, waitTime - .1f);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }
}
