using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject efectoExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            GameManager.Instance.enemyCounter += 1;
            GameManager.Instance.progress.text = GameManager.Instance.enemyCounter.ToString() + "/4";
            Instantiate(efectoExplosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
