using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseAnim : MonoBehaviour
{
    public jump j;
    private Vector3 startPos; 
    private Vector3 endPos; 
    private bool moveRight;
    private Vector3 touchPos;
    private bool moving;
    




    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(transform.position.x + .048f, transform.position.y, transform.position.z);
        moveRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {

    if ( j.notInTut ){

        if (Input.touchCount > 0)
        { //If the screen counts at least one touch
                Touch touch = Input.GetTouch(0); //Get the first touch
                touchPos = touch.position;
            if (touch.phase == TouchPhase.Began){ //Checking if the touch phase that this object is in is the begin phase
                if (touchPos.x < 300 && touchPos.y < 1770 && touchPos.y > 1620){
                    moving = true;
                }
            } 
        }


        if (moving){
                        
                    if (moveRight){
                        if (transform.position.x < endPos.x)
                        {
                            transform.Translate(Vector3.right * Time.deltaTime  , Space.Self);
                        }
                        else{
                            moveRight = false;
                        }
                    }
                    else 
                    {
                        if (transform.position.x > startPos.x)
                        {
                            transform.Translate(Vector3.left * Time.deltaTime , Space.Self);
                        }   
                        else
                        {
                            moveRight = true;
                            moving = false;
                        }
                    }
        }
        
    }



    }


}
