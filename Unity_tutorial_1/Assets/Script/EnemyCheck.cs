using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    /// <summary>
    /// ”»’è“à‚É•Ç‚©“G‚ª‚¢‚éB‚à‚µ‚­‚Í’n–Ê‚ÉÚG‚µ‚Ä‚¢‚È‚¢
    /// </summary>

    [HideInInspector] public bool isOn = false;

    private string groundTag = "Ground";
    private string enemyTag = "Enemy";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    #region//‘O•ûÚG”»’è
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = false;
        }

    }
    #endregion

}