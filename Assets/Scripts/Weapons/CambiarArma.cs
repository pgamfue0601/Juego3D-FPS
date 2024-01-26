using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarArma : MonoBehaviour
{
    public GameObject[] armas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var arma in armas)
            {
                arma.SetActive(false);
            }
            Debug.Log("Arma 1");
            armas[0].SetActive(true);
            GameManager.Instance.tipoDeArma = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var arma in armas)
            {
                arma.SetActive(false);
            }
            Debug.Log("Arma 2");
            armas[1].SetActive(true);
            GameManager.Instance.tipoDeArma = 2;
        }
    }
}
