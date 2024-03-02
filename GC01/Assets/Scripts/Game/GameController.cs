using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    public Animator playerAnimator;

    public bloodController bloodController;

    public bool attack = false;//启动攻击
    public int amod = 1;//攻击模式
    public float atime = 0.5f;//攻击间隔
    public float ctime = 0.5f;//格挡CD时间

    [Header("玩家图像")]
    public Sprite player1;
    public Sprite player2;
    public Sprite player3;
    public Sprite player4;

    [Header("敌人图像")]
    public Sprite enemy1;
    public Sprite enemy2;
    public Sprite enemy3;
    public Sprite enemy4;
    public Sprite enemy5;
    public Sprite enemy6;
    public Sprite enemy7;
    public Sprite enemy8;
    public Sprite enemy9;
    public Sprite enemy10;

    public float counter0;//计时器(攻击发起)
    public float counter1;//计时器（玩家按键）

    private bool rebounded = false;//敌人是否对玩家造成伤害
    private bool canblock = true;//是否可格挡


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canblock)//玩家按下空格时
        {
            counter1 = Time.time;//检测当前时间
            canblock = false;

            if (Mathf.Abs(counter1 - counter0 - 3 * atime) <= 0.25f)
            {
                rebounded = true;
                Debug.Log("弹反！");
                playerAnimator.enabled = false;
                StartCoroutine(Rebound());
                //Player.GetComponent<SpriteRenderer>().sprite = player2;//播放弹反动画
                Invoke("CanBlock", atime);
            }

            else
            {
                playerAnimator.enabled = false;
                Player.GetComponent<SpriteRenderer>().sprite = player1;//播放格挡动画
                Invoke("CanBlock", ctime);
            }


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackLoop();
        }

    }

    public void AttackLoop()
    {
        int amod = Random.Range(1, 4);//随机出1，2，3中一个数字

        Debug.Log(amod);
        if (amod == 1)//普通
        {
            atime = 0.5f;
            StartCoroutine(Idle1());
        }
        if (amod == 2)//慢
        {
            atime = 0.75f;
            StartCoroutine(Idle1());
        }
        if (amod == 3)//快
        {
            atime = 0.25f;
            StartCoroutine(Idle1());
        }
    }

    public void PlayerSprite0()//结束格挡/弹反姿势
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;
        playerAnimator.enabled = true;//玩家角色变回原样
    }

    public void EnemySprite0()
    {

        Enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void CanBlock()//结束格挡/弹反姿势，重新可以格挡
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;
        playerAnimator.enabled = true;//玩家角色变回原样
        canblock = true;

    }

    private IEnumerator Idle1()  //待机动画1
    {
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy4;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy5;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy6;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy7;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy4;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy5;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy6;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy7;
        yield return new WaitForSeconds(0.15f);

        StartCoroutine(Attack1());
    }

    private IEnumerator Rebound()  //弹反动画
    {
        Player.GetComponent<SpriteRenderer>().sprite = player2;
        yield return new WaitForSeconds(0.15f);
        Player.GetComponent<SpriteRenderer>().sprite = player3;
        yield return new WaitForSeconds(0.15f);
        Player.GetComponent<SpriteRenderer>().sprite = player4;
    }
    private IEnumerator Rebounded()  //被弹反动画
    {
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy8;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy9;
    }
    private IEnumerator Attack1()  //攻击模式1
    {
        counter0 = Time.time;
        //攻击动画
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy1;
        //Enemy.GetComponent<SpriteRenderer>().color = Color.green;//预备动作1
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy2;
        //Enemy.GetComponent<SpriteRenderer>().color = Color.yellow;//预备动作2
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy3;
        //Enemy.GetComponent<SpriteRenderer>().color = Color.red;//攻击命中动作
        yield return new WaitForSeconds(0.2f);

        //判断
        Damage();
    }
    public void Damage()//伤害判定和敌人受击
    {
        if (rebounded == false)//没弹反时
        {
            Player.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("PlayerSprite0", 0.25f);

            if (amod == 1)
            {
                bloodController.playerHP -= Random.Range(30, 41);
            }
            if (amod == 2)
            {
                bloodController.playerHP -= Random.Range(15, 26);
            }
            if (amod == 3)
            {
                bloodController.playerHP -= Random.Range(50, 61);
            }

            AttackLoop();
        }
        else
        {
            StartCoroutine(Rebounded());// 弹反动画

            Invoke("EnemySprite0", atime);//变为静止
            bloodController.enemyHP -= Random.Range(5, 16);//怪物扣血
            rebounded = false;

            Invoke("AttackLoop", 0.2f);
        }
    }





    // 暂时不用的
    public void EnemySprite1()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.green;//预备动作1
        Invoke("EnemySprite2", atime);//切到下一动作
    }
    public void EnemySprite2()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.yellow;//预备动作2
        Invoke("EnemySprite3", atime);//下一动作
    }
    public void EnemySprite3()
    {

        Enemy.GetComponent<SpriteRenderer>().color = Color.red;//攻击命中动作
        Invoke("Damage", atime);//伤害判定
    }
}
