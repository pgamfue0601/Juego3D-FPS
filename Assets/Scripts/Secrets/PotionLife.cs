using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionLife : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Bebida tomada");
                GameManager.Instance.vidas += 100;
                healthLeft.text = GameManager.Instance.vidas.ToString();
                Destroy(gameObject);
            }
        }
    }
}
