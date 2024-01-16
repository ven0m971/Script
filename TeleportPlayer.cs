using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] GameObject Player;

   


    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            Player.transform.position = Target.transform.position;
            Debug.Log("target");
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
