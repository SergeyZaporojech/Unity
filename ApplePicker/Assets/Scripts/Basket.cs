using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class Basket : MonoBehaviour
{
    // Start is called before the first frame update


    public Text scoreGT;

    
    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mosePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mosePos3D.x;
        this.transform.position = pos;

        //Text gt = this.GetComponent<Text>(); 
        //gt.text = "High Score: " + score;

    }

    


private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "Apple")
        {
            Destroy(go);

            int score = int.Parse(scoreGT.text);

            //if (score > HighScore.score)
            //{
            //    HighScore.score = score;
            //}
            score += 10;
            scoreGT.text = score.ToString();
        }
        
    }


}
