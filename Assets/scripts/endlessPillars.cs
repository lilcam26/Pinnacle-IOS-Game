using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node{

    public node next;
    public GameObject pill;
    public float height;

    public node(){
        next = null;
        pill = null;
        height = 0;
    }   
    public node getNext(){
        return next;
    }
    public void setNext(node nextOne){
        next = nextOne;
    }

    public void setPill(GameObject p){
        pill = p;
    }

    public void move(){
            pill.transform.Translate(Vector3.up * Time.deltaTime * 50, Space.World);
    }
    public bool check(){
        if (pill.transform.position.y < height){
            return false;
        }
        else{
            return true;
        }
    }
    public void setHeight(float H){
        height = H;
    }

}

public class linkedList
{
    public node head;
    public node tail;
    public int size;

    public linkedList(){
        size = 0;
    }

    public void iterateAndChange(){
        if (size > 0){
            node current = head;
            while(current != tail){
                current.move();
                current = current.getNext();
            }
            
            current.move();
            if (current.check()){
                deleteTail();
            }
            
        }
    }

         
    public void deleteTail(){
        if (size > 1){

        node current = head;
        while(current.getNext() != tail){
            current = current.getNext();
        }
        current.setNext(null);
        tail = current;
        size--;
        }

        else{
            head = null;
            tail = null;
            size--;
        }
        
    }

    public float getRef(){
        return head.height;
    }

    public void addToHead(GameObject pill, float h){
        if (size < 1){
            node N = new node();
            N.setHeight(h);
            N.setPill(pill);
            head = N;
            tail = N;
            
        }
        else if (size < 2) {
            node N = new node();
            N.setHeight(h);
            N.setPill(pill);
            N.setNext(head);
            tail = head;
            head = N;
        }
        else{
            node N = new node();
            N.setHeight(h);
            N.setPill(pill);
            N.setNext(head);
            head = N;

        }
        size++;

    }

    

}

public class endlessPillars : MonoBehaviour
{
    public jump j;
    public GameObject[] pillars;
    public GameObject player;
    public GameObject pillar;
    public GameObject clouds;
    public GameObject particles;
    private GameObject newPillarObj;
    private int pillarMoveIndex;
    private int pillarReference;
    private float newHeight;
    private Vector3 startPos;
    private Vector3 newPillarPos;
    private float randomX;
    private float randomY;
    private float randomZ;
    public linkedList movingPill;
    public bool isPaused;
    private Vector3 touchPos;
    private Vector3 cloudPos;
    private bool active;

        
    

    // Start is called before the first frame update
    void Start()
    {
        pillarMoveIndex = 0;
        pillarReference = 6;
        newHeight = pillars[pillarReference].transform.position.y;
        startPos = transform.position;
        movingPill = new linkedList();
        cloudPos = clouds.transform.position;
        active = false;
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
                    if (active == true){
                    transform.position = startPos;
                    clouds.transform.position = cloudPos;
                    isPaused = false;
                    active = false;
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

        movingPill.iterateAndChange();
        
        /*
        
        if (pillars[pillarMoveIndex].transform.position.z - transform.position.z < 3){
        

            
            randomX = Random.Range(729f, 735.5f);
            randomZ = Random.Range(1.0f, 5.0f);
            if (pillars[pillarReference].transform.position.y > 8.5f){
                randomY = Random.Range(-2.0f, -.5f);
            }else{
                randomY = Random.Range(0f, 0.05f);
            }


        if (movingPill.size < 1){
            newPillarPos = new Vector3(randomX,  (pillars[pillarReference].transform.position.y + randomY) - 50, randomZ + pillars[pillarReference].transform.position.z);
            newHeight = pillars[pillarReference].transform.position.y + randomY;
        }
        else{
            newPillarPos = new Vector3(randomX,  (movingPill.getRef() + randomY) - 50, randomZ + pillars[pillarReference].transform.position.z);
            newHeight = movingPill.getRef() + randomY;
        }

            newPillarObj = (GameObject) Instantiate(pillar, newPillarPos, Quaternion.Euler(0f, 0f, 0f));
            movingPill.addToHead(newPillarObj, newHeight);
            pillars[pillarMoveIndex] = newPillarObj;
            pillarMoveIndex++;
            if (pillarMoveIndex > 6){
                pillarMoveIndex = 0;
            }
            pillarReference++;
            if (pillarReference > 6){
                pillarReference = 0;
            }

        } 

        */

        if (j.score > 0){

        if (player.transform.position.y > -10){
            //if the camera is too far back then it will move forward faster but if not then it wont
            if (player.transform.position.z - transform.position.z > 7)
            {
                clouds.transform.Translate(Vector3.forward * Time.deltaTime * 1.5f, Space.World);
                particles.transform.Translate(Vector3.forward * Time.deltaTime * 1.5f, Space.World);
                transform.Translate(Vector3.forward * Time.deltaTime * 1.5f, Space.World);
            } else
            {
                clouds.transform.Translate(Vector3.forward * Time.deltaTime * .4f, Space.World);
                particles.transform.Translate(Vector3.forward * Time.deltaTime * .4f, Space.World);
                transform.Translate(Vector3.forward * Time.deltaTime * .4f, Space.World);
            }
            //if player y position gets too high then follow
            if (transform.position.y - player.transform.position.y  < 4f){
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);

            //if player gets too low follow
            } else if (transform.position.y - player.transform.position.y > 5.7f){
                transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            }
        }

        }

        if (player.transform.position.z - transform.position.z < 0 ){
            transform.position = startPos;
            clouds.transform.position = cloudPos;
        }
        
        if (player.transform.position.y < -25){
            transform.position = startPos;
             clouds.transform.position = cloudPos;
        }
        
    }

    }

    }
}
