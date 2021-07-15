using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    Vector2 paddleToballVector;
    bool hasStarted = false;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 1f;


    //cached reference
    AudioSource mySounds;
    Rigidbody2D myRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        paddleToballVector = transform.position - paddle.transform.position;
        mySounds = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>(); //Form1 frm=new Form1(); mantığı

    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted != true)
        {
            lockBallToPaddle();
        }
        launchBallOnMouseClick();



    }
    void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToballVector;

    }
    void launchBallOnMouseClick()
    {
        //0: left click
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(Random.Range(-1f,3f), 15f);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (hasStarted == true)
        {
          
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            mySounds.PlayOneShot(clip);

            Vector2 velocityRand = new Vector2(Random.Range(-randomFactor, randomFactor), Random.Range(0f, randomFactor));
            myRigidBody2D.velocity += velocityRand;
        }
       
    }
}
