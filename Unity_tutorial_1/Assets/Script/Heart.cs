using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Heart : MonoBehaviour
{
    private TextMeshProUGUI heartText = null;
    private int oldHeartNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        heartText = GetComponent<TextMeshProUGUI>();
        if (GManager.instance != null)
        {
            heartText.text = "�~ " + GManager.instance.heartNum;
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă��I");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldHeartNum != GManager.instance.heartNum)
        {
            heartText.text = "�~ " + GManager.instance.heartNum;
            oldHeartNum = GManager.instance.heartNum;
        }
    }
}