using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    private AudioSource aES;
    private AudioSource aS;
    public AudioClip aParry;
    public AudioClip aEnemyHurt;
    public AudioClip aSword0;
    public AudioClip aSword1;
    public AudioClip aBlock;
    public AudioClip aPlayerHurt;


    public Animator playerAnimator;

    public bloodController bloodController;

    public int isGaming = 0;
    public bool attack = false;//启动攻击
    public int amod = 1;//攻击模式
    public float atime = 0.5f;//攻击间隔
    public float ctime = 2f;//格挡CD时间

    [Header("设置")]
    public float DOD = 0.15f;
    public int ATK = 20;

    [Header("玩家图像")]
    public Sprite player1;
    public Sprite player2;
    public Sprite player3;
    public Sprite player4;
    public Sprite player5;

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

    bool isWin=false;
    bool isLose = false;

    void Start()
    {
        AttackLoop();
        aS=GetComponent<AudioSource>();
        aES=Enemy.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canblock)//玩家按下空格时
        {
            counter1 = Time.time;//检测当前时间
            canblock = false;

            if (Mathf.Abs(counter1 - counter0 - 3 * atime) <= DOD)
            {
                rebounded = true;
                Debug.Log("弹反！");

                aS.clip = aParry;
                aS.Play();

                playerAnimator.enabled = false;
                StartCoroutine(Rebound());
                Invoke("PlayerSprite0", atime);
                Invoke("CanBlock", ctime);
            }

            else
            {
                playerAnimator.enabled = false;
                Player.GetComponent<SpriteRenderer>().sprite = player1;//播放格挡动画

                aS.clip = aBlock;
                aS.Play();

                Invoke("PlayerSprite0", atime);
                Invoke("CanBlock", ctime);
            }


        }

        if (bloodController.enemyHP <= 0 && !isWin)// 游戏胜利
        {
            StartCoroutine(EnemyFall());
        }

        if (bloodController.playerHP <= 0 && !isLose)// 游戏失败
        {
            StartCoroutine(PlayerFall());
        }

    }

    public void AttackLoop()
    {
        int amod = Random.Range(1, 6);//随机出1，2，3,4,5中一个数字

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
        if (amod == 4)//特别慢
        {
            atime = 1.5f;
            StartCoroutine(Idle1());
        }
        if (amod == 5)//比较快
        {
            atime = 0.375f;
            StartCoroutine(Idle1());
        }
    }

    private IEnumerator PlayerFall()
    {
        Player.GetComponent<SpriteRenderer>().sprite = player5;
        yield return new WaitForSeconds(0.25f);
        isLose = true;
        GameObject.Find("InGameManager").GetComponent<InGameManager>().LoseGame();
    }

    private IEnumerator EnemyFall()
    {
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy10;
        yield return new WaitForSeconds(0.75f);
        isWin = true;
        GameObject.Find("InGameManager").GetComponent<InGameManager>().WinGame();
    }
    public void ResetPosition()
    {
        Player.transform.position = new Vector2(Player.transform.position.x + 1f, Player.transform.position.y + 0.3f);
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
        Enemy.transform.position = new Vector2(Enemy.transform.position.x + 1.5f, Enemy.transform.position.y + 0.3f);
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy9;
        Enemy.transform.position = new Vector2(Enemy.transform.position.x - 1.5f, Enemy.transform.position.y - 0.3f);
        Enemy.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private IEnumerator Attack1()  //攻击模式1
    {
        counter0 = Time.time;

        //攻击动画
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy1;
        aES.clip = aSword1;
        aES.Play();

        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy2;
        aES.clip = aSword1;
        aES.Play();

        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy3;
        aES.clip = aSword0;
        aES.Play();

        yield return new WaitForSeconds(0.2f);

        //判断
        Damage();
    }
    public void Damage()//伤害判定和敌人受击
    {
        if (rebounded == false)//没弹反时
        {
            Player.GetComponent<SpriteRenderer>().color = Color.red;
            Player.transform.position = new Vector2(Player.transform.position.x - 1f, Player.transform.position.y - 0.3f);
            Invoke("PlayerSprite0", 0.25f);
            Invoke("ResetPosition", 0.25f);

            aS.clip = aPlayerHurt;
            aS.Play();

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
                bloodController.playerHP -= Random.Range(30, 41);
            }
            if (amod == 4)
            {
                bloodController.playerHP -= Random.Range(40, 51);
            }
            if (amod == 5)
            {
                bloodController.playerHP -= Random.Range(15, 26);
            }

            Invoke("AttackLoop", 0.2f);
        }
        else
        {
            StartCoroutine(Rebounded());// 弹反动画

            aES.clip = aEnemyHurt;
            aES.Play();

            Invoke("EnemySprite0", 0.45f);//变为静止
            bloodController.enemyHP -= (ATK - (int)(Mathf.Abs(counter1 - counter0 - 3 * atime) * 150));//怪物扣血
            rebounded = false;

            Invoke("AttackLoop", 0.2f);
        }
    }

}
