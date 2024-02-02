using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform spawnBulletPoint;
    public Transform playerPosition;
    public float bulletVelocity = 100;
    public float maxDistance = 200;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShootPlayer", Random.Range(1.5f, 2.25f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootPlayer()
    {
        if (playerPosition != null && CanSeePlayer())
        {
            Vector3 playerDirection = playerPosition.position - transform.position;
            GameObject newEnemyBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
            newEnemyBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
            Invoke("ShootPlayer", Random.Range(1.5f, 2.25f));
        }
    }

    bool CanSeePlayer()
    {
        if (playerPosition == null) { return false; }
        Vector3 direccion = playerPosition.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direccion, out hit, maxDistance))
        {
            if (hit.collider.transform == playerPosition)
            {
                return true;
            }
            
        }
        return false;
    }
}
