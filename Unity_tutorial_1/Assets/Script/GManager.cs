using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    [Header("�X�R�A")] public int score;
    [Header("���݂̃X�e�[�W")] public int stageNum;
    [Header("���݂̕��A�ʒu")] public int continueNum;
    [Header("���݂̎c�@")] public int heartNum;
    [Header("�f�t�H���g�̎c�@")] public int defaultHeartNum;
    [HideInInspector] public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// �c�@���P���₷
    /// </summary>
    public void AddHeartNum()
    {
        if (heartNum < 99)
        {
            ++heartNum;
        }
    }

    /// <summary>
    /// �c�@���P���炷
    /// </summary>
    public void SubHeartNum()
    {
        if (heartNum > 1)
        {
            --heartNum;
        }
        else
        {
            isGameOver = true;
        }
    }


    /// <summary>
    /// �ŏ�����n�߂鎞�̏���
    /// </summary>
    public void RetryGame()
    {

        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }
}