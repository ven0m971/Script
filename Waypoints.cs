using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    Animator animator;
    public List<GameObject> waypoints;
    public float speed = 2f;
    int index = 0;
  
   
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos =  Vector3.MoveTowards(transform.position,destination,speed*Time.deltaTime);
        transform.position = newPos;

       float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05) 
        {
            if(index < waypoints.Count-1) 
            {
                index++;
            }
            
            
        }
        animator.SetBool("IsWalking", true);
       
    }
}
