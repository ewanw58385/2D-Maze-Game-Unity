using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathPosReference : MonoBehaviour
{
    public GameObject deathPosCalc;
   
    // Start is called before the first frame update
    void Start()
{
    deathPosCalc = GameObject.Find("Player");
    Vector2 positionDeath = deathPosCalc.transform.position;
    transform.position = positionDeath;
}

}
