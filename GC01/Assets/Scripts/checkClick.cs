using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkClick : MonoBehaviour
{
    private bool isChecking = false;// �ж��Ƿ��ڼ��

    public float timerDuration = 1.0f; // ��Чʱ��
    private float elapsedTime = 0.0f; // �ѹ�ʱ��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChecking)
        {
            elapsedTime += Time.deltaTime;// ��ʱ

            if (Input.GetButtonDown("Space"))// �жϳɹ�����öܷ��������������
            {
                counterAttack();
                endCheck();
            }
            else if (elapsedTime>timerDuration)// ����ʱ������Чʱ�䣬�����ܻ��������������
            {
                underAttack();
                endCheck();
            }
        }
    }

    public void startCheck()// ��ʼ���
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

    }
    public void underAttack()// �ܻ�����
    {

    }
}