using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodController : MonoBehaviour
{
    public Slider slider;

    public int enemyHP = 100;
    public int playerHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyHP;
    }    
}
