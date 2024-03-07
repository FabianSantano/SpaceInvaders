using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public string inputAxis;
  public GameObject bullet;
  public float speed;
  public Transform shottingOffset;
    // Update is called once per frame
    public void Start()
    {
      Enemy.onEnemyDied += EnemyOnonEnemyDied;


    }

    private void OnDestroy()
    {
      Enemy.onEnemyDied -= EnemyOnonEnemyDied;
    }

    void EnemyOnonEnemyDied( int pointsWorth)
    {
      //Debug.Log($"player recieved 'EnemyDied'  worth {pointsWorth} ");
    }
    void Update()
    {
      float direction = Input.GetAxis(inputAxis);
      Vector3 newPosition = transform.position + new Vector3(direction, 0, 0) * speed * Time.deltaTime;
      

      transform.position = newPosition;
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GetComponent<Animator>().SetTrigger("Shoot Trigger");
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);

      }
    }

    void someAnimationCallBack()
    {
      Debug.Log("Somethung happened in the animation");
    }
     void OnCollisionEnter2D(Collision2D collision)
        {
            if (gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.name == "BulletEnemy(Clone)")
                {
                  
                    gameObject.SetActive(false);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    Debug.Log("You Died!");
                    
                }
            }
         
    
        }
}
