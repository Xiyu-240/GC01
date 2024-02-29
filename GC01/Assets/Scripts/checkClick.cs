using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    public animatorManager manager;

    private bool isChecking = false;// �ж��Ƿ��ڼ��

    public float timerDuration = 10f; // ��Чʱ��
    public float elapsedTime = 0.0f; // �ѹ�ʱ��

    // Update is called once per frame
    void Update()
    {
        if (isChecking)
        {
            elapsedTime += Time.fixedDeltaTime;// ��ʱ

            if (Input.GetKeyDown(KeyCode.Space))// �жϳɹ�����öܷ��������������
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