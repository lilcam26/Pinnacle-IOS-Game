using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class jump : MonoBehaviour
{

    public bool isPaused;
    private bool isJumping = false;
    private bool itsCoin;

    public Rigidbody playerBody;
    private float jumpLength;
    private float Height;

    private int CENTERX;
    private int CENTERY;

    public int score;
    private int scoreOne;
    private int scoreTwo;
    private int coinCount;

    private string jumpLengthStr;
    private int index1;
    private int index2;

    public GameObject canvas;
    public GameObject[] Bumbers = new GameObject[10];
    private GameObject index1Obj;
    private GameObject index2Obj;
    public GameObject[] coins;

    private GameObject scoreTxt;
    private GameObject scoreTxtTwo;

    public GameObject firstPill;
    private Vector3 scorePos;
    private Vector3 scorePostwo;

    private bool tutCompleted;
    private bool active;

    public GameObject currPillar;

    private GameObject coinTxt;


    private float touchStartTime;
    private float touchEndTime;
    private float swipeTime;

    private Vector3 touchStartPosition;
    private Vector3 touchCurrentPosition;
    private Vector3 touchEndPosition;
    private Vector2 direction;
    private Vector2 lookDirection;
    private float swipeLength;
    private Vector3 ForwardVector;
    private Vector3 HeightVector;
    private Vector3 lookAtPos;
    public GameObject key;


    private Vector3 startPos;

    private Vector3 tapPosition;
    private Vector3 bottomPlayer;

    private Vector3 coinNullPos;
    private Vector3 coinCountPos;

    private Vector3 touchPos;

    private Vector3 num1pos;
    private Vector3 num2pos;
    private float num1posx;
    private float num1posy;
    private float num1posz;
    public int f;

    public Bar slider;

    private bool notClicked;
    public GameObject[] tutSeq;
    private bool inSeq1;
    public bool notInTut;
    private int whichScene;
    private bool move;
    public CanvasGroup myUI;
    private bool donefading;

    public Mask arrowMask;
    public Mask arrowMaskT;
    private bool Aup;
    private bool Adown;
    public GameObject arrow;
    public GameObject arrowT;
    private float finalArrow;
    private float startArrow;
    private Vector3 popUpPos;

    private Vector3 scaleChangeN;
    private Vector3 scaleChangeP;




    private bool inSeq2;
    private bool canTrigger;
    public GameObject[] tutSeq2;
    public GameObject arrow2;
    public GameObject arrow2T;
    public GameObject arrow3 ;



    // Start is called before the first frame update
    void Start()
    {

 
        itsCoin = false;
        startPos = transform.position;
        score = 0;
        coinCount = 0;
        bottomPlayer = new Vector3(transform.position.x, (transform.position.y - 1f), transform.position.z);
        coinCountPos = new Vector3(732.78f, 23.92f, 1368.3f);
        coinNullPos = new Vector3(0f, 0f, 0f);
        tutCompleted = false;
        active = false;
        notClicked = true;
        inSeq1 = true;
        inSeq2 = false;
        notInTut = false;
        move = false;
        donefading = false;
        whichScene = 0;
        Aup = false;
        Adown = true;
        startArrow = arrow.transform.position.y - .5f;
        finalArrow = arrow.transform.position.y - .8f;
        popUpPos = tutSeq[0].transform.position;
        canTrigger = true;


        scaleChangeP = new Vector3(0.05f, 0.05f, 0.05f);
        scaleChangeN = new Vector3(0.04f, 0.04f, 0.04f);

    }

    // Update is called once per frame
    void Update()
    {
      



    if (notInTut){

        if (arrow3.transform.localScale.x > .0001f){
                            arrow3.transform.localScale -= scaleChangeN;


                        }
                    
                        else{
                            Adown = true;
                            Aup = false;
                        }
        if (Input.touchCount > 0)
        { //If the screen counts at least one touch
        
                Touch touch = Input.GetTouch(0); //Get the first touch
                touchPos = touch.position;
            if (touch.phase == TouchPhase.Began){ //Checking if the touch phase that this object is in is the begin phase
                if (touchPos.x < 300 && touchPos.y < 1770 && touchPos.y > 1620){
                        isPaused = true;
                        active = true;
                }
                if (touchPos.x > 205 && touchPos.x < 374 && touchPos.y < 1001 && touchPos.y > 870){
                    if (active){
                    isPaused = false;
                    active = false;
                    }
                }
                if (touchPos.x > 463 && touchPos.x < 639 && touchPos.y < 1001 && touchPos.y > 870){
                    if (active){
                    score = 0;
                    coinCount = 0;
                    transform.position = startPos;
                    isJumping = false;
                    isPaused = false;
                    active = false;
                    currPillar = firstPill;
                    inSeq1 = true;
                    move = false;
                    donefading = false;
                    whichScene = 0;
                    Aup = false;
                    Adown = true;


                    for (int i = 0; i < 7; i++){
                        tutSeq[i].transform.position = popUpPos;
                    }
                    }
                }

                if (touchPos.x > 748 && touchPos.x < 912 && touchPos.y < 1001 && touchPos.y > 870){
                    if (active){
                        active = false;
                    } 
                }

                if (touchPos.x > 912 && touchPos.x < 957 && touchPos.y > 1055 && touchPos.y < 1085){
                    if (active == false){
                        active = true;
                    } 
                }
            } 
        }

       if (isPaused == false){

        if (Input.touchCount > 0){ //If the screen counts at least one touch
                Touch touch = Input.GetTouch(0); //Get the first touch
                touchEndPosition = touch.position;
                touchEndTime = Time.time;
                swipeLength = (touchEndPosition - touchStartPosition).magnitude;
                swipeTime = touchEndTime - touchStartTime;
                direction = (touchEndPosition - touchStartPosition).normalized;
                lookAtPos = new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z + direction.y );


            if (touch.phase == TouchPhase.Began){ //Checking if the touch phase that this object is in is the begin phase
                touchStartPosition = touch.position;
                touchStartTime = Time.time;
            } 

            if (touch.phase == TouchPhase.Moved){
                transform.LookAt(lookAtPos);

                if (direction.y > 0 && isJumping == false){
                    jumpLength = (1-swipeTime) * 200;
                    if (jumpLength < 0){
                        jumpLength = 0;
                    }
                    Height = (swipeLength/3);
                    if (Height > 890){
                        Height = 890;
                    }
                }

                
                jumpLengthStr = ($"{jumpLength/20}");
                if (jumpLength > 0){
                    index1 = Int16.Parse(jumpLengthStr.Substring(0,1));
                    index2 = Int16.Parse(jumpLengthStr.Substring(2,1));

                    Destroy (index1Obj);
                    Destroy (index2Obj);

                    index1Obj =Instantiate(Bumbers[index1], canvas.transform, false);
                    index2Obj =Instantiate(Bumbers[index2], canvas.transform, false);

                    num1posx = (float)(731.3 + ((touch.position.x/750) * 1.3));
                    num1posy = (float)(21.2 + ((touch.position.y/1300) * 1.5));
                    num1posz = index1Obj.transform.position.z;
                    num1pos = new Vector3(num1posx, num1posy, num1posz);
                    
                    num2pos = new Vector3(num1posx + .16f, num1posy, num1posz);
                    index1Obj.transform.position = num1pos;
                    index2Obj.transform.position = num2pos;

                    

                }
                else{
                    Destroy (index1Obj);
                    Destroy (index2Obj);
                    index1Obj = Instantiate(Bumbers[0], canvas.transform, false);
                    num1posx = (float)(731.3 + ((touch.position.x/750) * 1.3));
                    num1posy = (float)(21.2 + ((touch.position.y/1300) * 1.5));
                    num1posz = index1Obj.transform.position.z;
                    num1pos = new Vector3(num1posx, num1posy, num1posz);
                    index1Obj.transform.position = num1pos;
                }

                slider.setHeight(Height);
            }
            
            if (touch.phase == TouchPhase.Ended){ //Checking if the touch phase that this object is in is the begin phase
                Destroy (index1Obj);
                Destroy (index2Obj);
                if (direction.y > 0 && isJumping == false){
                    jumpLength = (1-swipeTime) * 200;
                    if (jumpLength < 0){
                        jumpLength = 0;
                    }
                    ForwardVector = new Vector3(direction.x, 0.0f , direction.y);
                    Height = (swipeLength/3);
                    if (Height > 890){
                        Height = 890;
                    }
                    transform.LookAt(lookAtPos);
                    jumping();
                    isJumping = true;
                }
            }
        }
        

        Destroy(scoreTxt);
        Destroy(scoreTxtTwo);
        Destroy(coinTxt);

        if (score > 99){
            //triple dig
        }
        else if (score > 9)
        {
            scoreOne = score/10;
            scoreTwo = score % 10;
            scoreTxt = Instantiate(Bumbers[scoreOne], canvas.transform, false);
            scoreTxtTwo = Instantiate(Bumbers[scoreTwo], canvas.transform, false);
            
            if (scoreOne == 1 || scoreOne == 0){
                scoreTxt.transform.localScale = new Vector3(scoreTxt.transform.localScale.x * .7f, scoreTxt.transform.localScale.y * .7f, scoreTxt.transform.localScale.z * .78f);
                scorePostwo = new Vector3(scoreTxt.transform.position.x + .052f, scoreTxt.transform.position.y + 1.099f, scoreTxt.transform.position.z);
                scorePos = new Vector3(scoreTxt.transform.position.x - .05f , scoreTxt.transform.position.y + 1.1f, scoreTxt.transform.position.z);


            }
            else{
                scoreTxt.transform.localScale = new Vector3(scoreTxt.transform.localScale.x * .72f, scoreTxt.transform.localScale.y * .72f, scoreTxt.transform.localScale.z * .8f);
                scorePostwo = new Vector3(scoreTxt.transform.position.x + .064f, scoreTxt.transform.position.y + 1.099f, scoreTxt.transform.position.z);
                scorePos = new Vector3(scoreTxt.transform.position.x - .055f , scoreTxt.transform.position.y + 1.1f, scoreTxt.transform.position.z);


            }        


            if (scoreTwo == 1 || scoreTwo == 0){
                scoreTxtTwo.transform.localScale = new Vector3(scoreTxtTwo.transform.localScale.x * .7f, scoreTxtTwo.transform.localScale.y * .7f, scoreTxtTwo.transform.localScale.z * .78f);
                

            }
            else{
                scoreTxtTwo.transform.localScale = new Vector3(scoreTxtTwo.transform.localScale.x * .72f, scoreTxtTwo.transform.localScale.y * .72f, scoreTxtTwo.transform.localScale.z * .8f);

            }  
            
            
            scoreTxt.transform.position = scorePos;
            scoreTxtTwo.transform.position = scorePostwo;
        } 
        else 
        {
            scoreTxt = Instantiate(Bumbers[score], canvas.transform, false);
            if (score == 1){
                scoreTxt.transform.localScale = new Vector3(scoreTxt.transform.localScale.x * .7f, scoreTxt.transform.localScale.y * .7f, scoreTxt.transform.localScale.z * .75f);
            }
            else{
                scoreTxt.transform.localScale = new Vector3(scoreTxt.transform.localScale.x * .72f, scoreTxt.transform.localScale.y * .72f, scoreTxt.transform.localScale.z * .8f);
            }            
            scorePos = new Vector3(scoreTxt.transform.position.x + .01f, scoreTxt.transform.position.y + 1.1f, scoreTxt.transform.position.z);
            scoreTxt.transform.position = scorePos;
        } 

        if (coinCount < 9){

            coinTxt = Instantiate(Bumbers[coinCount], canvas.transform, false);
            coinCountPos = new Vector3(coinTxt.transform.position.x + .455f, coinTxt.transform.position.y + 1.11f, coinTxt.transform.position.z);
            coinTxt.transform.localScale = new Vector3(coinTxt.transform.localScale.x * .55f, coinTxt.transform.localScale.y * .55f, coinTxt.transform.localScale.z * .55f);
            coinTxt.transform.position = coinCountPos;
        }

        if (transform.position.y < -30){
            score = 0;
            coinCount = 0;
            transform.position = startPos;
            isJumping = false;
            currPillar = firstPill;
        }
        
    }

    }

    if (inSeq1){

      if (whichScene < 8){
        if (whichScene > 0){

            if (whichScene == 5){

                if (Adown){
                    if(arrow.transform.position.y > finalArrow){
                        arrow.transform.Translate(Vector3.left * Time.deltaTime , Space.Self);
                        arrowT.transform.Translate(Vector3.left * Time.deltaTime  , Space.Self);
                    }
                    else{
                        Adown = false;
                        Aup = true;
                    }
                    
                }

                if (Aup){
                    if( arrow.transform.position.y < startArrow){
                        arrow.transform.Translate(Vector3.right * Time.deltaTime , Space.Self);
                        arrowT.transform.Translate(Vector3.right * Time.deltaTime  , Space.Self);
                    }
                    else{
                        Adown = true;
                        Aup = false;
                    }
                    
                }
            }
            

            if (move){
                    if (whichScene < 7)
                    {


                    if (tutSeq[whichScene].transform.position.x < 732.3)
                    {
                        tutSeq[whichScene].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                        tutSeq[whichScene-1].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                    }
                    else 
                    {
                        if (whichScene == 4)
                        {
                        arrowMask.showMaskGraphic = true;
                        arrowMaskT.showMaskGraphic = true;
                        }
                        move = false;
                        whichScene++;
                    }


                    } 
                    else 
                    {

                        if (tutSeq[whichScene - 1].transform.position.x < 734.3){
                            tutSeq[whichScene - 1].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                        }
                        else{
                            whichScene++;
                            donefading = false;
                        }

                    }
            }





            if (move == false){
            if (Input.touchCount > 0){
                Touch touch2 = Input.GetTouch(0);
                if (touch2.phase == TouchPhase.Ended){
                    move = true;
                    
                    if (whichScene == 5){
                        arrowMask.showMaskGraphic = false;
                        arrowMaskT.showMaskGraphic = false;
                    }
                    
                }
            }
            }




        }
        else{

            if (myUI.alpha < .7){
                myUI.alpha += .04f;
            }
            else {
                donefading = true;
            }

            if (donefading){
                if (tutSeq[whichScene].transform.position.x < 732.305f)
                {
                    tutSeq[whichScene].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                }
                else{
                    whichScene++; 
                }
            }
        }
      }
      else {
            if (myUI.alpha > 0){
                myUI.alpha -= .04f;
            }
            else {
                inSeq1 = false;
                notInTut = true;
            }
          
      }

    }


    
    if (canTrigger){
    if (score == 1){
        canTrigger = false;
        inSeq2 = true;
        notInTut = false;
        whichScene = 0;
        donefading = false;
        move = false;
    }
    }

    if (inSeq2){

        if (whichScene > 0){
        if (whichScene < 4){


            if (whichScene == 1){
                if (Adown){

                        if (arrow2.transform.localScale.x < 1.0f){
                            arrow2.transform.localScale += scaleChangeP;
                            arrow2T.transform.localScale += scaleChangeP;


                        }
                    
                        else{
                            Adown = false;
                            Aup = true;
                        }

                    }

                    if (Aup){
                    if (arrow2.transform.localScale.x > .0001f){
                            arrow2.transform.localScale -= scaleChangeN;
                            arrow2T.transform.localScale -= scaleChangeN;


                        }
                    
                        else{
                            Adown = true;
                            Aup = false;
                        }

                    
                    
                    }
            }
            if (whichScene == 2){
                        if (arrow2.transform.localScale.x > .0001f){
                            arrow2.transform.localScale -= scaleChangeN;
                            arrow2T.transform.localScale -= scaleChangeN;


                        }
                    
                        if (Adown){

                        if (arrow3.transform.localScale.x < 1.0f){
                            arrow3.transform.localScale += scaleChangeP;

                        }
                    
                        else{
                            Adown = false;
                            Aup = true;
                        } 

                    }

                    if (Aup){
                    if (arrow3.transform.localScale.x > .0001f){
                            arrow3.transform.localScale -= scaleChangeN;


                        }
                    
                        else{
                            Adown = true;
                            Aup = false;
                        }

                    
                    
                    }

            
            }
            if (whichScene == 3){
                if (arrow3.transform.localScale.x > .0001f){
                            arrow3.transform.localScale -= scaleChangeN;


                        }
                    
                        else{
                            Adown = true;
                            Aup = false;
                        }
            }
            
            

            if (move){

                

                switch(whichScene){
                    case 1:
                    
                    if (tutSeq2[whichScene].transform.position.x > 732.4)
                    {
                        tutSeq2[whichScene].transform.Translate(Vector3.left * Time.deltaTime * 5.0f, Space.Self);
                        tutSeq2[whichScene-1].transform.Translate(Vector3.left * Time.deltaTime * 5.0f, Space.Self);
                    }
                    else 
                    {
                        move = false;
                        whichScene++;
                    }

                    break;
                    

                    case 2:

                    if (tutSeq2[whichScene].transform.position.x < 732.3)
                    {
                        tutSeq2[whichScene].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                        tutSeq2[whichScene-1].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                    }
                    else 
                    {
                        move = false;
                        whichScene++;
                    }

                    

                    break;

                    

                    case 3:
                    
                    if (tutSeq2[whichScene-1].transform.position.x < 734.2)
                    {
                        tutSeq2[whichScene-1].transform.Translate(Vector3.right * Time.deltaTime * 5.0f, Space.Self);
                    }
                    else 
                    {
                        move = false;
                        whichScene++;
                    }

                    



                    break;

                }

                

                    

                   
            }





            if (move == false){
            if (Input.touchCount > 0){
                Touch touch2 = Input.GetTouch(0);
                if (touch2.phase == TouchPhase.Ended){
                    move = true;
                    print("move " + whichScene);
                    
                    
                }
            }
            }


        } else {
            if (myUI.alpha > 0){
                myUI.alpha -= .04f;
            }
            else {
                inSeq2 = false;
                notInTut = true;
            }

        }
        }  


        else{
        if (myUI.alpha < .8){
                myUI.alpha += .02f;
            }
            else {
                donefading = true;
            }

            if (donefading){
                if (tutSeq2[whichScene].transform.position.x > 732.3f)
                {
                    tutSeq2[whichScene].transform.Translate(Vector3.left * Time.deltaTime * 5.0f, Space.Self);
                }
                else{
                    whichScene++; 
                }
            }

        }


    }   



    }

    private void OnTriggerEnter(Collider collider) {

        for (int i = 0; i < 1; i++){
            if (collider.gameObject.name == coins[i].name){

                coinCount++;
                itsCoin = true;
                collider.gameObject.transform.position = coinNullPos;

            }

        }


    if (itsCoin == false)
    {
        if (collider.gameObject != currPillar && transform.position.y > collider.gameObject.transform.position.y + 16.6 && collider.gameObject != firstPill){
            
            score++;
            currPillar = collider.gameObject;

            if (isJumping == true){
                    playerBody.AddForce(-(ForwardVector).normalized * 30);
            }
            isJumping = false;

        } 

        if (collider.gameObject == currPillar) {

                if (isJumping == true){
                 playerBody.AddForce(-(ForwardVector).normalized * 30);
                }
                isJumping = false;
        }
            

        if (collider.gameObject.name == key.name){

                tutCompleted = true;


        }


    }
        
        itsCoin = false;
    }

    void jumping(){

        playerBody.AddForce(ForwardVector.normalized * jumpLength);
        playerBody.AddForce(transform.up * Height);

    }




}
