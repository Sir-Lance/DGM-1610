using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    private PlayerHealth healthPoints;
    private FireControl cannon;
    private PlayerControl hull;
    private EnemyCounter enemyCnt;
    public int uiAmmo;
    public float uiHealth;
    public bool uiRdyFire;
    public float uiSpeed;
    public int uiEnemy;
    public Text spdVal;
    public Text ammoVal;
    public Text hpVal;
    public Text loadVal;
    public Text enmyVal;
    public Text warningEngine;
    public Text warningAmmo;
    public Text warningCritical;
    public Text gameOver;
    public Text restartFlash;
    public Text continueFlash;

    bool Warn1;
    bool Warn2;
    bool Warn3;
    bool Cont1;
    bool alive;

    void Awake()
    {
        healthPoints = GameObject.Find("MBTHull").GetComponent<PlayerHealth>();
        cannon = GameObject.Find("PlayerCannon").GetComponent<FireControl>();
        hull = GameObject.Find("MBTHull").GetComponent<PlayerControl>();
        enemyCnt = GameObject.Find("Enemy Counter").GetComponent<EnemyCounter>();
        
        //hide UI elements until if statements are matched below
        Warn1 = true;
        Warn2 = true;
        Warn3 = true;
        alive = true;
        Cont1 = true;
        warningEngine.color = Color.clear;
        warningAmmo.color = Color.clear;
        warningCritical.color = Color.clear;
        gameOver.color = Color.clear;
        restartFlash.color = Color.clear;
        continueFlash.color = Color.clear;

    }
    
    // Update is called once per frame
    void Update()
    {
        uiAmmo = cannon.ammo;
        uiHealth = healthPoints.pHealth;
        uiRdyFire = cannon.chamber;
        uiSpeed = hull.spdUpdate;
        uiEnemy = enemyCnt.enemies;

        //reload UI states
        if(uiRdyFire == false)
        {
            loadVal.text = "RELOADING...";
            loadVal.color = Color.red;
            ammoVal.color = Color.red;
        }
        if(uiRdyFire == true)
        {
            loadVal.text = "READY";
            loadVal.color = Color.green;
            ammoVal.color = Color.white;
        }

        spdVal.text = uiSpeed.ToString("0");

        //Health Value
        hpVal.text = uiHealth.ToString("0");
        if(uiHealth <= 50f)
        {
            hpVal.color = Color.red;

        }
        //dead
        if(uiHealth <= 0.0f && alive)
        {
            alive = false;
            gameOver.color = Color.yellow;
            restartFlash.color = Color.yellow;
            hpVal.text = "DEAD";
        }
        
        //damage state 1
        if(uiHealth >= 0 && uiHealth <= 50 && Warn1)
        {
            Warn1 = false;
            warningEngine.color = Color.red;
        }
        
        //damage state 2
        if(uiHealth >= 0 && uiHealth <= 35 && Warn2)
        {
            Warn2 = false;
            warningAmmo.color = Color.red;
        }
        
        //damage state 3
        if(uiHealth >= 0 && uiHealth <= 20 && Warn3)
        {
            Warn3 = false;
            warningCritical.color = Color.red;
        }
        
        //Ammo Value
        ammoVal.text = uiAmmo.ToString();

        //Enemy Value
        enmyVal.text = uiEnemy.ToString();
        if(enemyCnt.enemies <= 0 && Cont1)
        {
            Cont1 = false;
            continueFlash.color = Color.white;
        }
    }
}
