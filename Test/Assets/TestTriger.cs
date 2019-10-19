using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriger : MonoBehaviour {


    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            collider.GetComponent<PlayerStats>().health += 50;
            Destroy(gameObject);
        }
    }

}
