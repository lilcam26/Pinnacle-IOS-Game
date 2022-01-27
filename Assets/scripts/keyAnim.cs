using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyAnim : MonoBehaviour
{

    private float maxHeight;
    private float minHeight;
    public Rigidbody playerBody;


    // Start is called before the first frame update
    void Start()

    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {

        playerBody.AddForce(transform.up * 50);

        }
}
