using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletsLeft;
    [SerializeField] private TextMeshProUGUI healthLeft;
    [SerializeField] private TextMeshProUGUI grenadeLeft;
    private bool vulnerable;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AmmoBox"))
        {
            GameManager.Instance.gunAmmo += other.GetComponent<AmmoBox>().ammo;
            bulletsLeft.text = GameManager.Instance.gunAmmo.ToString();
        }

        if (other.CompareTag("Enemigo") && vulnerable)
        {
            StartCoroutine(VulnerableCoroutine());
        }
    }

    public IEnumerator VulnerableCoroutine()
    {
        

        vulnerable = false;
        GameManager.Instance.vidas -= 15;
        healthLeft.text = GameManager.Instance.vidas.ToString();
        if (GameManager.Instance.vidas <= 0)
        {
            Muerto();
        } else {
            yield return new WaitForSeconds(2f);
            vulnerable = true;
        }
    }

    public IEnumerator BulletDamage(int damage)
    {
        vulnerable = false;
        GameManager.Instance.vidas -= damage;
        healthLeft.text = GameManager.Instance.vidas.ToString();
        if (GameManager.Instance.vidas <= 0)
        {
            Muerto();
        }
        else
        {
            yield return new WaitForSeconds(2f);
            vulnerable = true;
        }
    }

    private void Muerto()
    {
        GameManager.Instance.muerto = true;
        healthLeft.text = "0";
        Transform deathMove = transform;
        float anguloX = -128f;
        deathMove.eulerAngles = new Vector3(anguloX, deathMove.eulerAngles.y, deathMove.eulerAngles.z);
        deathMove.position = new Vector3(deathMove.position.x, deathMove.position.y + 2, deathMove.position.z);
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        StartCoroutine(Reiniciar());
    }

    IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Victoria()
    {

    }
}
