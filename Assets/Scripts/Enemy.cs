using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject Enemybullet;
    public int points = 3;
    public delegate void EnemyDied(int pointWorth);
    public static event EnemyDied onEnemyDied;
    public GameMangerScript gm;
    private GameObject hitGameObject;
    // Start is called before the first frame update
    public RowMovement rowMovement;
    public Transform shottingOffset;
    private int randomNumber;
    
    
    void Start()
    {
        // Start repeating the movement pattern
        randomNumber = Random.Range(1, 8);
        
    }
     // Flag to track if a shot has been fired
    private void Update()
    {
        
        
        if (rowMovement.moveCount == 1 && !gm.hasFiredShot)
        {
            if (gameObject.CompareTag("Enemy3"))
            {
                
                if (gameObject.name == "Enemy2" || gameObject.name == "Enemy4" || gameObject.name == "Enemy6")
                {
                    GameObject shot = Instantiate(Enemybullet, shottingOffset.position, Quaternion.identity);
                    
                    Destroy(shot, 3f);
                    gm.hasFiredShot = true;
                }
          
            }
        }
        
    }
    

 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Enemy1"))
        {
            if (collision.gameObject.name == "Bullet(Clone)")
            {
                
                gm.killed = gm.killed + 1;
                
                GetComponent<Animator>().SetTrigger("gotHit");
                Destroy(collision.gameObject);
                gm.score = gm.score + 30;
                gm.highScoreCheck(gm.score);
                
            }
        }
        else if (gameObject.CompareTag("Enemy2"))
        {
            if (collision.gameObject.name == "Bullet(Clone)")
            {
                
                gm.killed = gm.killed + 1;
                
                
                GetComponent<Animator>().SetTrigger("gotHit");
                Destroy(collision.gameObject);
                gm.score = gm.score + 20;
                gm.highScoreCheck(gm.score);
 
            }
        }else if (gameObject.CompareTag("Enemy3"))
        {
            if (collision.gameObject.name == "Bullet(Clone)")
            {
                
                gm.killed = gm.killed + 1;
                
                GetComponent<Animator>().SetTrigger("gotHit");
                Destroy(collision.gameObject);
                gm.score = gm.score + 10;
                gm.highScoreCheck(gm.score);

            }
        }else if (gameObject.CompareTag("SpecialEnemy4"))
        {
            if (collision.gameObject.name == "Bullet(Clone)")
            {
                
                gm.killed = gm.killed + 1;
                GetComponent<Animator>().SetTrigger("gotHit");
                Destroy(collision.gameObject);
                gm.score = gm.score + 40;
                gm.highScoreCheck(gm.score);

                
                
            }
        }


    }

 

    void animationCompleteDestroy()
    {

        onEnemyDied.Invoke(points);
        Destroy(gameObject);
    }

    public void enemyFire()
    
    {
        if (gameObject.CompareTag("Enemy3"))
        {
            int randomNumber = Random.Range(1, 8);
            if (gameObject.name == $"Enemy{randomNumber}")
            {
                GameObject shot = Instantiate(Enemybullet, shottingOffset.position, Quaternion.identity);
                Destroy(shot, 3f);
            }
        }
    }
}
