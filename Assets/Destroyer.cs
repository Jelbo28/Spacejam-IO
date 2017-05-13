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
            Destroy(other.gameObject, 1f);
            SceneManager.LoadScene(0);
        }
        else
        {      
            Destroy(other.gameObject);
        }
    }
}
