using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInteraction>().StartCoroutine(collision.gameObject.GetComponent<PlayerInteraction>().BulletDamage(damage));
            Destroy(gameObject);
        }
    }
}
