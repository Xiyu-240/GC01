using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    private bool isChecking = false;// 判断是否在检测

    public float timerDuration = 1.0f; // 有效时间
    private float elapsedTime = 0.0f; // 已过时间

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChecking)
        {
            elapsedTime += Time.deltaTime;// 计时

            if (Input.GetButtonDown("Space"))// 判断成功则调用盾反函数并结束检测
            {
                counterAttack();
                endCheck();
            }
            else if (elapsedTime>timerDuration)// 若计时大于有效时间，调用受击函数并结束检测
            {
                underAttack();
                endCheck();
            }
        }
    }

    public void startCheck()// 开始检测
    {
        isChecking = true;
        elapsedTime = 0.0f;// 重置计时器
    }

    public void endCheck()// 结束检测
    {
        isChecking = false;
    }

    public void counterAttack()// 盾反函数
    {

    }
    public void underAttack()// 受击函数
    {

    }
}