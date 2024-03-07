using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public delegate void WallDestroyed();
    public static event WallDestroyed onWallDes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)" || collision.gameObject.name == "BulletEnemy(Clone)" )
        {
            GetComponent<Animator>().SetTrigger("gotHit");
            Destroy(collision.gameObject);
            
        }
    
    }
    void animationCompleteDestroy()
    {

       
        Destroy(gameObject);
    }
    
}
