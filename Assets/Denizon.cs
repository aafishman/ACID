using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Denizon Base Class to derive all types of npc's and player too at some point (maybe soon...)
//we are all denizons...


public class Denizon : MonoBehaviour
{
    // Start is called before the first frame update


    public float mvSpd =1.5f; //deafult move speed, can be slowed down or sped up carious reasons/ways?
    //going to be the factor that decides how many they move per tick?
    //so 1 2 or 3 or something?
    //hrm do we just add the remainder to give them a little boost sometimes? kind of like that?
    //program to add the remaidner, just use ints then anyways for now, then leave at 1 for everyone move a tick at a time


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
