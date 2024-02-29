using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorManager : MonoBehaviour
{
    public Animator enemyAnimator;
    public Animator playerAnimator;

    public void counterAttack()// 盾反函数
    {
        enemyAnimator.SetBool("achieve", true);
        playerAnimator.SetBool("counter", true);
    }
    public void underAttack()// 受击函数
    {
        playerAnimator.SetBool("injured", true);
    }
    public void defence()// 普通格挡
    {
        playerAnimator.SetBool("defence", true);
    }
    public void endAnimation()// 重置动画状态
    {
        enemyAnimator.SetBool("achieve", false);
        playerAnimator.SetBool("counter", false);
        playerAnimator.SetBool("injured", false);
    }

    public void endDenfence()
    {
        playerAnimator.SetBool("defence", false);
    }
}
