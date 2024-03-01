using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    private AutomaticDoor aD;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        aD = door.GetComponent<AutomaticDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            aD.battleStarted = true;
        }
    }
}
