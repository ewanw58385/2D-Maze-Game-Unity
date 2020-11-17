using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDeathPos : MonoBehaviour
{
    Vector2 lastdeathPos = (Vector2)attackScript.GetComponent("deathPos");
    void Start()
    {
         Vector2 lastDeathRef = lastDeathPos.deathPos;
         lastDeathPos = transform.position;
    }

}   