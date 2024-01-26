using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform PuntoDisparo;
    public float shotForce = 10000f;
    public float shotRate = 0.5f;
    public AudioClip shotSound;
    private AudioSource shotAudioSource;

    public TextMeshProUGUI bulletsLeft;
    // Start is called before the first frame update
    private void Awake()
    {
        shotAudioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.muerto)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.Instance.tipoDeArma == 1 && GameManager.Instance.gunAmmo < 1) { return; }
            if (GameManager.Instance.tipoDeArma == 2 && GameManager.Instance.gunAmmo < 1) { return; }
            if (Time.time > shotRate && GameManager.Instance.gunAmmo > 0)
            {
                GameManager.Instance.gunAmmo--;
                bulletsLeft.text = GameManager.Instance.gunAmmo.ToString();
                shotAudioSource.PlayOneShot(shotSound);
                GameObject newBullet = Instantiate(bullet, PuntoDisparo.position, PuntoDisparo.rotation);
                Quaternion rotacion = Quaternion.Euler(90f, 0f, 0);
                newBullet.transform.rotation = rotacion;
                newBullet.GetComponent<Rigidbody>().AddForce(PuntoDisparo.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRate = shotRate * Time.deltaTime;
                Destroy(newBullet, 3f);
            }
        }
    }
}
