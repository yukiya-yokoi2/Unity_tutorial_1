using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("重力")] public float gravity;
    [Header("移動速度")] public float speed;
    [Header("やられて落ちる速度")] public float fallspeed;
    [Header("接触判定")] public EnemyCheck checkcollision;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
            if (checkcollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }
            if (sr.isVisible || nonVisibleAct)
            {
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if (!isDead)
            {
                if (GManager.instance != null)
                {

                    GManager.instance.score += myScore;
                }

                anim.Play("enemy_down");
                isDead = true;
                col.enabled = false;
                Destroy(gameObject, 3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
                rb.velocity = new Vector2(0, -fallspeed);
            }
        }
        
    }
}
