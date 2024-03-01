using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorManager : MonoBehaviour
{
    public Animator enemyAnimator;
    public Animator playerAnimator;

    public void counterAttack()// �ܷ�����
    {
        enemyAnimator.SetBool("achieve", true);
        playerAnimator.SetBool("counter", true);
    }
    public void underAttack()// �ܻ�����
    {
        playerAnimator.SetBool("injured", true);
    }
    public void defence()// ��ͨ��
    {
        playerAnimator.SetBool("defence", true);
    }
    public void endAnimation()// ���ö���״̬
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
