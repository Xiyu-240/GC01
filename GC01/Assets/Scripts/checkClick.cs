using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    public animatorManager manager;

    private bool isChecking = false;// 判断是否在检测

    public float timerDuration = 10f; // 有效时间
    public float elapsedTime = 0.0f; // 已过时间

    private bool inCD = false;// 判断是否冷却

    public float CD = 5f;// 冷却
    public float elapsedTime2 = 0.0f;// 已过

    // Update is called once per frame
    void Update()
    {
        if (inCD)// 冷却中
        {
            elapsedTime2 += Time.fixedDeltaTime;

            if (elapsedTime2 > CD)
            {
                inCD = false;
                elapsedTime = 0.0f;
            }
        }
        else//冷却完毕
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inCD = true;
            }
        }

        if (isChecking)
        {
            elapsedTime += Time.fixedDeltaTime;// 计时

            if (Input.GetKeyDown(KeyCode.Space) && !inCD)// 判断成功则调用盾反函数并结束检测
            {
                manager.counterAttack();
                endCheck();
            }
            else if (elapsedTime > timerDuration)// 若计时大于有效时间，调用受击函数并结束检测
            {
                manager.underAttack();
                endCheck();
            }
        }
    }

    public void startCheck()// 开始检测，通过animation事件调用
    {
        isChecking = true;
        elapsedTime = 0.0f;// 重置计时器
    }

    public void endCheck()// 结束检测
    {
        isChecking = false;
        elapsedTime = 0.0f;// 重置计时器
    }
}