using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class manager : MonoBehaviour
{

    public GameObject Kknife, Log, Prefab, Aknife,Log1, Log2, Log3, ParentLog, ParentApple, testob, WhiteSquare, WhiteCircle, GotHitLog, Rstrtscene;
    public int rotate = 0, TotalKnife = 3, WinRotate = 0, forlose = 0, appleCount = 0, whichh, whichh2, whichh3, foricon, forhit = 0, knifeCount = 0, score = 0;
    public float test = 0, test33 = 0, test333 = 0, test5;
    public Boolean winlose = false, canthrow = false;
    public GameObject[] Apples, Knifes, KnifeIcons;
    public TextMeshProUGUI Applecount, Applecount2, KnifeCount, KnifeCount2, scoreTxt;
    public AudioSource KnifeHitLog, KnifeHitKnife, NewLevel, LevelWin;
    public ParticleSystem particleSystem;
    public GameObject Knife1, knife2, knife3,prefab1,prefab2,prefab3;
    public int whichknife;

    private void Awake()
    {
        ParentLog = GameObject.FindGameObjectWithTag("ParentLog");
        Log = GameObject.FindGameObjectWithTag("Log");
        Log1 = GameObject.FindGameObjectWithTag("Log1");
        Log1.SetActive(false);
        Log2 = GameObject.FindGameObjectWithTag("Log2");
        Log2.SetActive(false);
        Log3 = GameObject.FindGameObjectWithTag("Log3");
        Log3.SetActive(false);

        appleCount = PlayerPrefs.GetInt("Apples", appleCount);
        Applecount.text = appleCount.ToString();
        Applecount2.text = appleCount.ToString();

        knifeCount = PlayerPrefs.GetInt("knifes", knifeCount);
        KnifeCount.text = knifeCount.ToString();
        KnifeCount2.text = knifeCount.ToString();

        Obstacle();
        

        testob.SetActive(false);      
    }
    

    void Start()
    {

        whichknife = PlayerPrefs.GetInt("selected");
        if (whichknife == 1)
        {
            Aknife = Knife1;
            Prefab = prefab1;
        }
        if (whichknife == 2)
        {
            Aknife = knife2;
            Prefab = prefab2;
        }
        if (whichknife == 3)
        {
            Aknife = knife3;
            Prefab = prefab3;
        }

        GameObject Nknife = Instantiate(Aknife, new Vector3(0, -2.38f, -0.1f), Quaternion.identity);

        if(knifeCount < 10)
        {
            TotalKnife = 5;
        }
        if(knifeCount >= 10 && knifeCount < 18)
        {
            TotalKnife = 7;
        }
        if(knifeCount >= 18 && knifeCount < 26)
        {
            TotalKnife = 9;
        }
        if(knifeCount >= 26)
        {
            TotalKnife = 10;
        }


        foricon = TotalKnife;
        SetKnifeIcons();

        
    }

    void Update()
    {
        if (!winlose)
        {
            Kknife = GameObject.FindGameObjectWithTag("active");
        }
        
        if(test33 > 0.5f)
        {
            
            testob.GetComponent<Animator>().SetBool("testtt", true);
            testob.SetActive(true);           
        }
        if(test33 > 0.8f)
        {
            NewLevel.Play();
        }
        if(test33 > 0.8f)
        {
            canthrow = true;
        }

        if (Input.GetMouseButtonDown(0) && TotalKnife > 0 && canthrow)
        {
            ThrowKnife();   
        }
        if(rotate == 1 && TotalKnife > 0)
        {
            Kknife.gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, -8));
        }

        if(WinRotate == 1)
        {
            for (int i = 6; i < ParentLog.transform.childCount; i++)
            {
                ParentLog.transform.GetChild(i).GetComponent<TurnPrefab>().enabled = true;
            }
            
        }
        if(test > 0.7f)
        {
            Rstrtscene.SetActive(true);
        }
        if(test5 > 0.7f)
        {
            SceneManager.LoadScene(1);
        }
        if(forhit == 0)
        {
            GotHitLog.GetComponent<Animator>().SetBool("GotHit", false);
        }
        if(forhit == 1)
        {
            GotHitLog.GetComponent<Animator>().SetBool("GotHit", true);
        }
    }

    private void FixedUpdate()
    {
        if (forlose == 1)
        {
            test += Time.deltaTime;
        }
        if (WinRotate == 1)
        {
            test5 += Time.deltaTime;
            
        }
        if(test33 < 1.5f)
        {
            test33 += Time.deltaTime;
        }
        if(forhit == 1)
        {
            test333 += Time.deltaTime;
        }
        if(test333 > 0.01f)
        {
            
            forhit = 0;
            test333 = 0;
            
        }
    }

    public void RestartScene()
    {
        WinRotate = 0;
        test = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ThrowKnife()
    {
        Kknife.GetComponent<knife>().locked = 0;
        KnifeIcons[foricon - 1].transform.GetComponent<SpriteRenderer>().enabled = false;
        foricon -= 1;
    }

    public void SetKnifeIcons()
    {

        for (int i = 0; i < KnifeIcons.Length; i++)
        {
            KnifeIcons[i].transform.gameObject.SetActive(false);
        }

        for (int i = 0; i < TotalKnife; i++)
        {
            KnifeIcons[i].transform.gameObject.SetActive(true);
        }
    }

    public void Obstacle()
    {
        for (int i = 0; i < Apples.Length; i++)
        {
            Apples[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Knifes.Length; i++)
        {
            Knifes[i].gameObject.SetActive(false);
        }

        int SpawnAppleCount = UnityEngine.Random.Range(0, 27);
        if (SpawnAppleCount < 10)
        {

        }
        if (SpawnAppleCount >= 10 && SpawnAppleCount < 20)
        {
            whichh = UnityEngine.Random.Range(0, 7);
            Apples[whichh].gameObject.SetActive(true);
        }
        if (SpawnAppleCount >= 20)
        {
            whichh2 = UnityEngine.Random.Range(0, 3);
            Apples[whichh2].gameObject.SetActive(true);
            whichh3 = UnityEngine.Random.Range(3, 7);
            Apples[whichh3].gameObject.SetActive(true);
        }


        int SpawnKnifeCount = UnityEngine.Random.Range(0, 30);
        if (SpawnKnifeCount < 5)
        {

        }
        if (SpawnKnifeCount >= 5 && SpawnKnifeCount < 17)
        {
            int which = UnityEngine.Random.Range(0, 3);
            if (whichh2 != which && whichh3 != which && whichh != which)
            {
                Knifes[which].gameObject.SetActive(true);
            }
            int which2 = UnityEngine.Random.Range(3, 7);
            if (whichh3 != which2 && whichh2 != which2 && whichh != which2)
            {
                Knifes[which2].gameObject.SetActive(true);
            }

        }
        if (SpawnKnifeCount >= 17)
        {
            int which = UnityEngine.Random.Range(0, 2);
            if (whichh2 != which && whichh3 != which && whichh != which)
            {
                Knifes[which].gameObject.SetActive(true);
            }
            int which2 = UnityEngine.Random.Range(2, 4);
            if (whichh3 != which2 && whichh2 != which2 && whichh != which2)
            {
                Knifes[which2].gameObject.SetActive(true);
            }
            int which3 = UnityEngine.Random.Range(4, 7);
            if (whichh3 != which3 && whichh2 != which3 && whichh != which3)
            {
                Knifes[which3].gameObject.SetActive(true);
            }

        }
    }

    public void Stick()
    {
        forhit = 1;
        rotate = 0;
        knifeCount += 1;
        PlayerPrefs.SetInt("knifes", knifeCount);
        PlayerPrefs.Save();
        KnifeCount.text = knifeCount.ToString();
        KnifeCount2.text = knifeCount.ToString();
        GameObject Pknife = Instantiate(Prefab, new Vector3(0, 0, -0.1f), Quaternion.identity);
        Pknife.transform.parent = ParentLog.transform;
    }

    public void newActiveKnife()
    {
        if (TotalKnife > 0)
        {
            GameObject Nknife = Instantiate(Aknife, new Vector3(0, -2.38f, -0.1f), Quaternion.identity);
            
            TotalKnife -= 1;
        }
        if (TotalKnife == 0)
        {
            winlose = true;
            win();         
        }
    }

    public void throwavayknife()
    {       
        KnifeHitKnife.Play();
        ParentLog.GetComponent<Log>().test = 0;
        Kknife.gameObject.GetComponent<Transform>().position = new Vector3(Kknife.gameObject.GetComponent<Transform>().position.x, Kknife.gameObject.GetComponent<Transform>().position.y, -0.4f);
        
        Kknife.gameObject.GetComponent<Rigidbody2D>().gravityScale = 100;
        rotate = 1;
        ParentLog.GetComponent<Log>().turn = 0;
    }

    public void win()
    {
        WhiteSquareFlash();
        LevelWin.Play();
        Destroy(GameObject.FindGameObjectWithTag("active"));
        GameObject.FindGameObjectWithTag("active").SetActive(false);
        Log.SetActive(false);
        Log1.SetActive(true);
        Log1.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.00015f, 0.0004f));
        Log1.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20;
        Log2.SetActive(true);
        Log2.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.04f, 0.029f));
        Log2.gameObject.GetComponent<Rigidbody2D>().gravityScale = 15;
        Log3.SetActive(true);
        Log3.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.04f, 0.019f));
        Log3.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20;


        for (int i = 5; i < ParentLog.transform.childCount; i++)
        {
            float forx = UnityEngine.Random.Range(-0.08f, 0.08f);
            float fory = UnityEngine.Random.Range(0.01f, 0.04f);
            ParentLog.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(new Vector2(forx, fory));
            ParentLog.transform.GetChild(i).GetComponent<Rigidbody2D>().gravityScale = 4;
            
        }

        WinRotate = 1;


        for (int i = 0; i < 8; i++)
        {
            Apples[i].transform.SetParent(ParentApple.transform);
            int forapple = UnityEngine.Random.Range(-220, 220);
            Apples[i].GetComponent<Rigidbody2D>().gravityScale = 6;
            Apples[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(forapple, 450));
        }

        for (int i = 0; i < 8; i++)
        {
            Knifes[i].transform.SetParent(ParentApple.transform);
            int forapple = UnityEngine.Random.Range(-220, 220);
            Knifes[i].GetComponent<Rigidbody2D>().gravityScale = 6;
            Knifes[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(forapple, 450));
        }

    }

    public void WhiteSquareFlash()
    {
        WhiteSquare.SetActive(true);
        WhiteCircle.SetActive(true);
    }

    public void AppleCountAdd()
    {
        appleCount += 1;
        PlayerPrefs.SetInt("Apples", appleCount);
        PlayerPrefs.Save();
        Applecount.text = appleCount.ToString();
        Applecount2.text = appleCount.ToString();
    }

    public void lose()
    {
        throwavayknife();
        score = PlayerPrefs.GetInt("knifes");
        scoreTxt.text = score.ToString();
        PlayerPrefs.SetInt("knifes", 0);
        PlayerPrefs.Save();
        KnifeCount.text = knifeCount.ToString();
        KnifeCount2.text = knifeCount.ToString();
        forlose = 1;
        
        canthrow = false;
    }

    public void MainScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void knifeMarket()
    {
        SceneManager.LoadScene(2);
    }

    public void setacc()
    {
        SceneManager.LoadScene(3);
    }

}
