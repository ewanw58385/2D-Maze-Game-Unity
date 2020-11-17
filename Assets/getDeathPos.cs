using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDeathPos : MonoBehaviour
{

   private attackScript lastDeathPos = GetComponent<attackScript>();
   
    void Start()
    {
         Vector2 lastDeathRef = lastDeathPos.deathPos;
         lastDeathPos = transform.position;
    }

}   