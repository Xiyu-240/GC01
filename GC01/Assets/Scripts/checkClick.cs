using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    public Animator enemyAnimator;
    public Animator playerAnimator;

    private bool isChecking = false;// 判断是否在检测

    public float timerDuration = 1.0f; // 有效时间
    public float elapsedTime = 0.0f; // 已过时间

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChecking)
        {
            elapsedTime += Time.fixedDeltaTime;// 计时

            if (Input.GetKeyDown(KeyCode.Space))// 判断成功则调用盾反函数并结束检测
            {
                counterAttack();
                endCheck();
            }
            else if (elapsedTime > timerDuration)// 若计时大于有效时间，调用受击函数并结束检测
            {
                underAttack();
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
    }

    public void counterAttack()// 盾反函数
    {
        Debug.Log("1");
        enemyAnimator.SetBool("achieve", true);
        playerAnimator.SetBool("counter", true);
    }
    public void underAttack()// 受击函数
    {
        playerAnimator.SetBool("injured", true);
    }

    public void endAnimation()// 重置动画状态
    {
        enemyAnimator.SetBool("achieve", false);
        playerAnimator.SetBool("counter", false);
    }

    public void endInjured()// 这实属无奈，一会可以添到player脚本或许？
    {
        playerAnimator.SetBool("injured", false);
    }
}