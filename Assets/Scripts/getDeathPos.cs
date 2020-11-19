using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDeathPos : MonoBehaviour
{
    private GameObject enemy;
    public Vector2 deathLoc;

    void Start()
    {
        enemy = GameObject.Find("enemy");
    }

    void Update()
    {
        Vector2 deathLoc = enemy.GetComponent<attackScript>().deathPos;
        Debug.Log(deathLoc);
    }

}   