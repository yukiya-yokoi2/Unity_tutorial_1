using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageCtrl : MonoBehaviour
{
    [Header("�v���C���[�Q�[���I�u�W�F�N�g")] public GameObject playerObj;
    [Header("�R���e�B�j���[�ʒu")] public GameObject[] continuePoint;
    [Header("�Q�[���I�[�o�[")] public GameObject gameOverObj;
    [Header("�t�F�[�h")] public FadeImage fade;

    private Player p;
    private int nextStageNum;
    private bool startFade = false; 
    private bool doGameOver = false;
    private bool retryGame = false; 
    private bool doSceneChange = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null)
        {
            gameOverObj.SetActive(false);
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if (p == null)
            {
                Debug.Log("�v���C���[����Ȃ������A�^�b�`����Ă����I");
            }
        }
        else
        {
            Debug.Log("�ݒ肪����ĂȂ���I");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I�[�o�[���̏���
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            doGameOver = true;
        }
        //�v���C���[�����ꂽ���̏���
        else if (p != null && p.IsContinueWaiting() && !doGameOver)
        {
            if (continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("�R���e�B�j���[�|�C���g�̐ݒ肪����ĂȂ���I");
            }
        }

        //�X�e�[�W��؂�ւ���
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //�Q�[�����g���C
                if (retryGame)
                {
                    GManager.instance.RetryGame();
                }
                //���̃X�e�[�W
                else
                {
                    GManager.instance.stageNum = nextStageNum;
                }
                SceneManager.LoadScene("stage" + nextStageNum);
                doSceneChange = true;
            }
        }
    }

    /// <summary>
    /// �ŏ�����n�߂�
    /// </summary>
    public void Retry()
    {
        ChangeScene(1); //�ŏ��̃X�e�[�W�ɖ߂�̂łP
        retryGame = true;
    }

    /// <summary>
    /// �X�e�[�W��؂�ւ��܂��B
    /// </summary>
    /// <param name="num">�X�e�[�W�ԍ�</param>
    public void ChangeScene(int num)
    {
        if (fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }
}