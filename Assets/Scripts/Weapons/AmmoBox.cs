using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammo = 10;
    public TextMeshProUGUI ammoText;
    private AudioSource ammoGrab;
    
    // Start is called before the first frame update
    void Start()
    {
        ammoGrab = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ammoGrab.PlayOneShot(ammoGrab.clip);
            GameManager.Instance.gunAmmo += ammo;
            ammoText.text = GameManager.Instance.gunAmmo.ToString();
        }
    }
}
