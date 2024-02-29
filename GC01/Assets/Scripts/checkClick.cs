using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    public Animator enemyAnimator;
    public Animator playerAnimator;

    private bool isChecking = false;// �ж��Ƿ��ڼ��

    public float timerDuration = 1.0f; // ��Чʱ��
    public float elapsedTime = 0.0f; // �ѹ�ʱ��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChecking)
        {
            elapsedTime += Time.fixedDeltaTime;// ��ʱ

            if (Input.GetKeyDown(KeyCode.Space))// �жϳɹ�����öܷ��������������
            {
                counterAttack();
                endCheck();
            }
            else if (elapsedTime > timerDuration)// ����ʱ������Чʱ�䣬�����ܻ��������������
            {
                underAttack();
                endCheck();
            }
        }
    }

    public void startCheck()// ��ʼ��⣬ͨ��animation�¼�����
    {
        isChecking = true;
        elapsedTime = 0.0f;// ���ü�ʱ��
    }

    public void endCheck()// �������
    {
        isChecking = false;
    }

    public void counterAttack()// �ܷ�����
    {
        Debug.Log("1");
        enemyAnimator.SetBool("achieve", true);
        playerAnimator.SetBool("counter", true);
    }
    public void underAttack()// �ܻ�����
    {
        playerAnimator.SetBool("injured", true);
    }

    public void endAnimation()// ���ö���״̬
    {
        enemyAnimator.SetBool("achieve", false);
        playerAnimator.SetBool("counter", false);
    }

    public void endInjured()// ��ʵ�����Σ�һ�������player�ű�����
    {
        playerAnimator.SetBool("injured", false);
    }
}