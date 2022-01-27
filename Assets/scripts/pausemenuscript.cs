using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemenuscript : MonoBehaviour
{
    public jump j;
    private bool moving;
    private Vector3 scaleChange;
    private Vector3 touchPos;
    private bool startP;
    private bool play;
    private bool restart;
    private bool home; 
    public Mask popup;
    

    public Mask playMask;
    public Mask homeMask;
    public Mask restartMask;
    private bool paused;

    

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        startP = false;
        restart = false;

        


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


                if (paused){
                
               if (touchPos.x > 205 && touchPos.x < 374 && touchPos.y < 1001 && touchPos.y > 870){
                    playMask.showMaskGraphic = true;
                    
               }

               if (touchPos.x > 463 && touchPos.x < 639 && touchPos.y < 1001 && touchPos.y > 870){
                    restartMask.showMaskGraphic = true;
                }

                if (touchPos.x > 748 && touchPos.x < 912 && touchPos.y < 1001 && touchPos.y > 870){
                    homeMask.showMaskGraphic = true;
                }






                }


            } 
            if (touch.phase == TouchPhase.Ended){
                playMask.showMaskGraphic = false;
                restartMask.showMaskGraphic = false;
                homeMask.showMaskGraphic = false;
                 if (touchPos.x < 300 && touchPos.y < 1770 && touchPos.y > 1620){
                    moving = true;
                    paused = true;
                    

                }

                if (touchPos.x > 205 && touchPos.x < 374 && touchPos.y < 1001 && touchPos.y > 870){
                    if (paused == true){
                        play = true;
                        paused = false;
                    }
                }

                if (touchPos.x > 463 && touchPos.x < 639 && touchPos.y < 1001 && touchPos.y > 870){
                    if (paused == true){
                        restart = true;
                        paused = false;
                    }
                }

                if (touchPos.x > 748 && touchPos.x < 912 && touchPos.y < 1001 && touchPos.y > 870){
                    if (paused == true){
                        home = true;
                        paused = false;
                    }
                }

                if (touchPos.x > 912 && touchPos.x < 957 && touchPos.y > 1055 && touchPos.y < 1085){
                    if (home == true){
                        home = false;
                        popup.showMaskGraphic = false;
                        paused = true;
                    }
                }

            }
        }

        if (moving){
            if (transform.localScale.x < 1.0f){
                transform.localScale += scaleChange;
            }
            else{
                moving = false;
                startP = true;
            }
        }

        if (startP){
            if(play || restart){
                if (transform.localScale.x > .001f){
                    transform.localScale += -(scaleChange);
            }
                else{
                    play = false;
                    restart = false;
                    home = false;
                    j.notInTut = false;
            }
            }

            if (home){
                popup.showMaskGraphic = true;
            }

            
        }

        }
        
    }
}
