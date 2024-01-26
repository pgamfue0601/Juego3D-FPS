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
    public TextMeshProUGUI progress;

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
        
    }
}
