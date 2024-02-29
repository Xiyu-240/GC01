using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    public animatorManager manager;

    private bool isChecking = false;// �ж��Ƿ��ڼ��

    public float timerDuration = 10f; // ��Чʱ��
    public float elapsedTime = 0.0f; // �ѹ�ʱ��

    private bool inCD = false;// �ж��Ƿ���ȴ

    public float CD = 5f;// ��ȴ
    public float elapsedTime2 = 0.0f;// �ѹ�

    // Update is called once per frame
    void Update()
    {
        if (inCD)// ��ȴ��
        {
            elapsedTime2 += Time.fixedDeltaTime;

            if (elapsedTime2 > CD)
            {
                inCD = false;
                elapsedTime = 0.0f;
            }
        }
        else//��ȴ���
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inCD = true;
            }
        }

        if (isChecking)
        {
            elapsedTime += Time.fixedDeltaTime;// ��ʱ

            if (Input.GetKeyDown(KeyCode.Space) && !inCD)// �жϳɹ�����öܷ��������������
            {
                manager.counterAttack();
                endCheck();
            }
            else if (elapsedTime > timerDuration)// ����ʱ������Чʱ�䣬�����ܻ��������������
            {
                manager.underAttack();
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
        elapsedTime = 0.0f;// ���ü�ʱ��
    }
}