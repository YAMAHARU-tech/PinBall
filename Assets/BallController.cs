﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            FindObjectOfType<ScoreController>().AddPoint(10);
        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            FindObjectOfType<ScoreController>().AddPoint(20);
        }
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            FindObjectOfType<ScoreController>().AddPoint(10);
        }
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            FindObjectOfType<ScoreController>().AddPoint(10);
        }

    }
}
