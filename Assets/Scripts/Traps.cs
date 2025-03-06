using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        //only destoy if collactable
        if (other.CompareTag("Collectable"))
        {
            //Destroy(other.gameObject);
        }


    }
}
