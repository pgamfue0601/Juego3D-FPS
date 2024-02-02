using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            GameManager.Instance.KillConfirmed();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugadorenlaexplosion");
            other.GetComponent<PlayerInteraction>().StartCoroutine(other.GetComponent<PlayerInteraction>().GrenadeDamage());
        }
    }
}
