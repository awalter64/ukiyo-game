using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int momentos = 4;
    float zAxis;
    bool onGround = false;
    Quaternion rotation;
    int sceneCount = 0;
    
    GameObject scene1;
    GameObject scene2;
    GameObject scene3;
    GameObject scene4;
    
    GameObject level1;
    GameObject level2;
    GameObject level3;
    GameObject level4;
   
    GameObject momento1;
    GameObject momento2;
    GameObject momento3;
    GameObject momento4;
    
    GameObject welcomeText;
    
    GameObject platform1;
    GameObject platform2;
    GameObject platform3;
    GameObject platform4;
    GameObject platform5;

    GameObject platformTrigger1;
    GameObject platformTrigger2;
    GameObject platformTrigger3;
    GameObject platformTrigger4;
    GameObject platformTrigger5;

    GameObject barrier;

    GameObject jet;
    GameObject iroh;
    GameObject joodee;
    GameObject mai;

    Vector2 startPosition = new Vector2(-10.5f, -3.5f);
    Vector2 movement;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        scene1 = GameObject.Find("Scene1");
        scene2 = GameObject.Find("Scene2");
        scene3 = GameObject.Find("Scene3");
        scene4 = GameObject.Find("Scene4");
        level1 = GameObject.Find("Level1");
        level2 = GameObject.Find("Level2");
        level3 = GameObject.Find("Level3");
        level4 = GameObject.Find("Level4");
        welcomeText = GameObject.Find("WelcomeText");

        jet = GameObject.Find("jet");
        iroh = GameObject.Find("iroh");
        joodee = GameObject.Find("joodee");
        mai = GameObject.Find("mai");
 }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxis("Horizontal");
        if (onGround && Input.GetAxis("Jump") == 1)
            movement.y = 12.0f;
        else
            movement.y = 0.0f;

        //moves to the next level
        //changes existing platforms
        //allows user to scroll through text
        switch (momentos)
        {
            case 3:
                    Destroy(level1);
                    platform1.transform.position = new Vector2(-10f, 1.5f);
                    platform2.transform.position = new Vector2(-7f, -.75f);
                    platform3.transform.position = new Vector2(0f, -.75f);
                    
                    platformTrigger1.transform.position = new Vector2(-10f, 1.5f);
                    platformTrigger2.transform.position = new Vector2(-7f, -.75f);
                    platformTrigger3.transform.position = new Vector2(0f, -.75f);
                    barrier.transform.position = new Vector2(15f, 15f);
                    
                    if (Input.GetKeyDown("down"))
                    {
                        scene2.transform.Translate(Vector2.down);
                    }
                break;
             
            case 2:
                Destroy(level2);
                platform1.transform.position = new Vector2(0f, 1.5f);
                platform2.transform.position = new Vector2(-3f, -.75f);
                platform3.transform.position = new Vector2(3f, -.75f);
                platform4.transform.position = new Vector2(0f, -3f);
                
                platformTrigger1.transform.position = new Vector2(0f, 1.5f);
                platformTrigger2.transform.position = new Vector2(-3f, -.75f);
                platformTrigger3.transform.position = new Vector2(3f, -.75f);
                platformTrigger4.transform.position = new Vector2(0f, -3f);
                
                barrier.transform.position = new Vector2(15f, 15f);

                if (Input.GetKeyDown("down"))
                {
                    scene3.transform.Translate(Vector2.down);
                }
                
                break;
                
            case 1:
                Destroy(level3);
                platform1.transform.position = new Vector2(10f, 1.5f);
                platform2.transform.position = new Vector2(7f, -.75f);
                platform3.transform.position = new Vector2(4f, -.75f);
                platform4.transform.position = new Vector2(0f, -3f);

                platformTrigger1.transform.position = new Vector2(10f, 1.5f);
                platformTrigger2.transform.position = new Vector2(7f, -.75f);
                platformTrigger3.transform.position = new Vector2(4f, -.75f);
                platformTrigger4.transform.position = new Vector2(0f, -3f);

                barrier.transform.position = new Vector2(15f, 15f);
                if (Input.GetKeyDown("down"))
                {
                    scene4.transform.Translate(Vector2.down);
                }
                break;
                
            case 0:
                Destroy(level4);
                Destroy(platform1);
                Destroy(platform2);
                Destroy(platform3);
                Destroy(platform4);
                Destroy(platform5);
                Destroy(platformTrigger1);
                Destroy(platformTrigger2);
                Destroy(platformTrigger3);
                Destroy(platformTrigger4);
                Destroy(platformTrigger5);

                break;

        }
        
        if(momentos == 4 && Input.GetKeyDown("down"))
        {
            Destroy(welcomeText);
            scene1.transform.Translate(Vector2.down);
        }

    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Momento")
        {
            //player collects momento
            Destroy(collision.gameObject);
            momentos--;
            sceneCount++;
            print(momentos);
        }

        //allows player to jump
        if(collision.gameObject.tag == "ground")
        {
            onGround = true;
        }

        //moves player from level intro to actual level
        //sets new platforms and new momentos
        if(collision.gameObject.tag == "door")
        {
            switch(sceneCount)
            {
                case 0:
                        Destroy(scene1);
                        Destroy(jet);
                        rb.position = startPosition;
                        momento1 = GameObject.Instantiate(GameObject.Find("Square"), new Vector2(10f, 3.25f), rotation);
                        platform1 = GameObject.Instantiate(GameObject.Find("Platform"), new Vector2(10f, 1.5f), rotation);
                        platform2 = GameObject.Instantiate(GameObject.Find("Platform"), new Vector2(7f, -.75f), rotation);
                        platform3 = GameObject.Instantiate(GameObject.Find("Platform"), new Vector2(4f, -3f), rotation);
                        platformTrigger1 = GameObject.Instantiate(GameObject.Find("PlatformTrigger"), new Vector2(10f, 1.5f), rotation);
                        platformTrigger2 = GameObject.Instantiate(GameObject.Find("PlatformTrigger"), new Vector2(7f, -.75f), rotation);
                        platformTrigger3 = GameObject.Instantiate(GameObject.Find("PlatformTrigger"), new Vector2(4f, -3f), rotation);
                        barrier = GameObject.Instantiate(GameObject.Find("ClosedDoor"), new Vector3(11.5f, -3f, 10f), rotation);
                        break;

                case 1:
                        Destroy(scene2);
                        Destroy(iroh);
                        rb.position = startPosition;
                        momento2 = GameObject.Instantiate(GameObject.Find("Square"), new Vector2(-10f, 3.25f), rotation);
                        barrier = GameObject.Instantiate(GameObject.Find("ClosedDoor"), new Vector3(11.5f, -3f, 10f), rotation);
                        platform4 = GameObject.Instantiate(GameObject.Find("Platform"), new Vector2(-4f, -3f), rotation);
                        platformTrigger4 = GameObject.Instantiate(GameObject.Find("PlatformTrigger"), new Vector2(-4f, -3f), rotation);
                        break;

                case 2:
                    Destroy(scene3);
                    Destroy(joodee);
                    rb.position = startPosition;
                    momento3 = GameObject.Instantiate(GameObject.Find("Square"), new Vector2(0f, 3.25f), rotation);
                    barrier = GameObject.Instantiate(GameObject.Find("ClosedDoor"), new Vector3(11.5f, -3f, 10f), rotation);
                    break;

                case 3:
                    Destroy(scene4);
                    Destroy(mai);
                    rb.position = startPosition;
                    momento4 = GameObject.Instantiate(GameObject.Find("Square"), new Vector2(10f, 3.5f), rotation);
                    platform5 = GameObject.Instantiate(GameObject.Find("Platform"), new Vector2(-4f, -3f), rotation);
                    platformTrigger5 = GameObject.Instantiate(GameObject.Find("PlatformTrigger"), new Vector2(-4f, -3f), rotation);
                    barrier = GameObject.Instantiate(GameObject.Find("ClosedDoor"), new Vector3(11.5f, -3f, 10f), rotation);
                    break;
            }

        }

    }

    //keeps player from jumping in air
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }
}
