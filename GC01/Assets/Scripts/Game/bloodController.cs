using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodController : MonoBehaviour
{
    public Slider enemyslider;
    public Slider playerSlider;

    public int enemyHP = 100;
    public int playerHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyslider.value = enemyHP;
        playerSlider.value = playerHP;
        
    }    
}
