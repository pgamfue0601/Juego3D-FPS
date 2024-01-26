using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject granada;
    public Transform granadaPoint;
    public AudioClip explosion;
    private AudioSource explosionAudioSource;
    public float throwForce = 30f;
    public GameObject efectoExplosion;
    public TextMeshProUGUI grenadesLeft;
    // Start is called before the first frame update
    void Start()
    {
        explosionAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && GameManager.Instance.grenadeAmmo > 0)
        {
            StartCoroutine(ThrowGrenadeAction());
        }
    }

    private IEnumerator ThrowGrenadeAction()
    {
        GameManager.Instance.grenadeAmmo--;
        grenadesLeft.text = GameManager.Instance.grenadeAmmo.ToString();
        GameObject newGrenade = Instantiate(granada, granadaPoint.position, granadaPoint.rotation);
        Quaternion rotacion = Quaternion.Euler(90f, 0f, 0);
        newGrenade.transform.rotation = rotacion;
        newGrenade.GetComponent<Rigidbody>().AddForce(granadaPoint.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
        yield return new WaitForSeconds(2.25f);
        GameObject explosionEffect = Instantiate(efectoExplosion, newGrenade.transform.position, newGrenade.transform.rotation);
        explosionAudioSource.PlayOneShot(explosion);
        Destroy(newGrenade, 2f);
        Destroy(explosionEffect, 2f);
    }
}
