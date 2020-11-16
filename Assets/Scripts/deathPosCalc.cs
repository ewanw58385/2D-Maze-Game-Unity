using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathPosCalc : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 deathPoscord;
     void OnTriggerExit2D (Collider2D col)
    { 
    if (col.gameObject.tag == "enemy")
      {
        deathPoscord = transform.position;
      }
    }
}
