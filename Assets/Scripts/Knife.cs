using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private string groundTag = "Ground";

  /*  void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(groundTag))
        {
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag))
        {                                                       //higher optimize
            Destroy(gameObject);
        }

        /* if (collision.gameObject.tag==groundTag)
         {                                                   //poor optimize
             Destroy(gameObject);
         }*/
    }

}
