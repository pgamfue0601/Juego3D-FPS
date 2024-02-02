using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance
    {
        get; private set;
    }

    public int gunAmmo = 10;
    public int vidas = 100;
    public int grenadeAmmo = 3;
    public int tipoDeArma;
    public bool muerto = false;
    public int enemyCounter = 0;
    [SerializeField] private TextMeshProUGUI progress;
    [SerializeField] private TextMeshProUGUI mission;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter >= 4)
        {
            progress.text = "";
            mission.text = "¡Misión cumplida, ahora ve a la puerta de la pared del fondo y pulsa E!";
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void KillConfirmed()
    {
        enemyCounter++;
        progress.text = enemyCounter.ToString() + "/4";
    }
}
