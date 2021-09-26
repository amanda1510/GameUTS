using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCantroller : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    public float power;
    int score;
    Text scoreUI;
    GameObject panelSelesai;
    GameObject panelKalah;
    Text txPemenang;
    int nyawa;
    GameObject hati1;
    GameObject hati2;
    GameObject hati3;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, -5).normalized;
        rigid.AddForce(arah * force * power);
        score = 0;
        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
        panelKalah = GameObject.Find("PanelKalah");
        panelKalah.SetActive(false);
        nyawa = 3;
        hati1 = GameObject.Find("Hati1");
        hati2 = GameObject.Find("Hati2");
        hati3 = GameObject.Find("Hati3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "TepiBawah")
        {
            ResetBall();
            Vector2 arah = new Vector2(0, -5).normalized;
            rigid.AddForce(arah * force);
            nyawa -= 1;
            if (nyawa == 2)
            {
                hati1.SetActive(false);
            }
            if (nyawa == 1)
            {
                hati1.SetActive(false);
                hati2.SetActive(false);
            }
        }
        if (coll.gameObject.name == "Paddle")
        {
            float sudut = (transform.position.x - coll.transform.position.x) * 5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * power);
        }
        if (score == 65)
        {
            panelSelesai.SetActive(true);
            Destroy(gameObject);
            return;
        }
        if (nyawa == 0)
        {
            panelKalah.SetActive(true);
            Destroy(gameObject);
            hati1.SetActive(false);
            hati2.SetActive(false);
            hati3.SetActive(false);
            return;
        }
    }
    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
            score = score + 5;
            TampilkanScore();
        }
    }
    void TampilkanScore()
    {
        scoreUI.text = "score: " + score + "";
    }
}
