
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MainMenuManager : MonoBehaviour
{

    public int holder = 0, holder1 = 0, appleCount, OwnKnife2, OwnKnife3, selectedknife;
    public float waiter = 0, knifeMarketLoader;
    public GameObject forButtons, forKnife, forKnife2, knifeMarket, Knife1Button, Knife2Button, Knife3Button, Knife1Image, Knife2Image, Knife3Image;
    public GameObject knife1selected, knife2selected, knife3selected, tochose1, tochose2, tochose3, currentK, Knife, Knife1;
    public TextMeshProUGUI AppleC, AppleC2, AppleC3;
    public GameObject knife1, knife2, knife3, settings;
    public Sprite sprite1, sprite2, sprite3;

    // Start is called before the first frame update
    void Start()
    {
        appleCount = PlayerPrefs.GetInt("Apples", appleCount);
        AppleC.text = appleCount.ToString();
        AppleC2.text = appleCount.ToString();
        AppleC3.text = appleCount.ToString();
        OwnKnife2 = PlayerPrefs.GetInt("knife2");
        OwnKnife3 = PlayerPrefs.GetInt("knife3");

        selectedknife = PlayerPrefs.GetInt("selected", 1);

        if(OwnKnife2 == 1)
        {
            Knife2Button.SetActive(false);
            Knife2Image.SetActive(true);
        }
        if (OwnKnife3 == 1)
        {
            Knife3Button.SetActive(false);
            Knife3Image.SetActive(true);
        }

        if (selectedknife == 1)
        {
            knife1.SetActive(true);
            knife2.SetActive(false);
            knife3.SetActive(false);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite1;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        if (selectedknife == 2)
        {
            knife1.SetActive(false);
            knife2.SetActive(true);
            knife3.SetActive(false);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite2;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if (selectedknife == 3)
        {
            knife1.SetActive(false);
            knife2.SetActive(false);
            knife3.SetActive(true);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite3;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (selectedknife == 1)
        {
            knife1.SetActive(true);
            knife2.SetActive(false);
            knife3.SetActive(false);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite1;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        if (selectedknife == 2)
        {
            knife1.SetActive(false);
            knife2.SetActive(true);
            knife3.SetActive(false);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite2;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if (selectedknife == 3)
        {
            knife1.SetActive(false);
            knife2.SetActive(false);
            knife3.SetActive(true);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite3;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite3;
        }

        appleCount = PlayerPrefs.GetInt("Apples", appleCount);
        AppleC.text = appleCount.ToString();
        AppleC2.text = appleCount.ToString();
        AppleC3.text = appleCount.ToString();

        OwnKnife2 = PlayerPrefs.GetInt("knife2");
        OwnKnife3 = PlayerPrefs.GetInt("knife3");

        selectedknife = PlayerPrefs.GetInt("selected");
        if (OwnKnife2 == 1)
        {
            Knife2Button.SetActive(false);
            Knife2Image.SetActive(true);
            tochose2.SetActive(true);
        }
        if (OwnKnife3 == 1)
        {
            Knife3Button.SetActive(false);
            Knife3Image.SetActive(true);
            tochose3.SetActive(true);
        }
        if (OwnKnife2 == 0)
        {
            Knife2Button.SetActive(true);
            Knife2Image.SetActive(false);
        }
        if (OwnKnife3 == 0)
        {
            Knife3Button.SetActive(true);
            Knife3Image.SetActive(false);
        }

        if (waiter > 0.4f)
        {
            SceneManager.LoadScene(1);
        }

        

        if (Knife1Button.gameObject.activeSelf)
        {
            Knife1Image.SetActive(false);
            tochose1.SetActive(false);
        }
        if (OwnKnife2 != 1)
        {
            Knife2Image.SetActive(false);
            tochose2.SetActive(false);
        }
        if (OwnKnife3 != 1)
        {
            Knife3Image.SetActive(false);
            tochose3.SetActive(false);
        }

        if(selectedknife == 1)
        {
            tochose1.SetActive(false);
            tochose2.SetActive(true);
            tochose3.SetActive(true);
            knife1selected.SetActive(true);
            knife2selected.SetActive(false);
            knife3selected.SetActive(false);
        }
        if (selectedknife == 2)
        {
            tochose1.SetActive(true);
            tochose2.SetActive(false);
            tochose3.SetActive(true);
            knife1selected.SetActive(false);
            knife2selected.SetActive(true);
            knife3selected.SetActive(false);
        }
        if (selectedknife == 3)
        {
            tochose1.SetActive(true);
            tochose2.SetActive(true);
            tochose3.SetActive(false);
            knife1selected.SetActive(false);
            knife2selected.SetActive(false);
            knife3selected.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        if(holder == 1)
        {
            waiter += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        holder = 1;
        forButtons.GetComponent<Animator>().enabled = true;
        forKnife.GetComponent<SpriteRenderer>().enabled = false;
        forKnife2.SetActive(true);
    }

    public void openKnifeMarket()
    {
        knifeMarket.SetActive(true);
        knifeMarket.GetComponent<Animator>().SetBool("get", true);
        knifeMarket.GetComponent<Animator>().SetBool("back", false);
    }

    public void closeKnifeMarket()
    {
        knifeMarket.GetComponent<Animator>().SetBool("back", true);
        knifeMarket.GetComponent<Animator>().SetBool("get", false);

    }

    public void buySecondKnife()
    {
        if(appleCount >= 10)
        {
            appleCount -= 10;
            PlayerPrefs.SetInt("Apples", appleCount);
            PlayerPrefs.Save();
            Knife2Button.SetActive(false);
            Knife2Image.SetActive(true);
            knife1selected.SetActive(false);
            knife2selected.SetActive(true);
            knife3selected.SetActive(false);
            knife1.SetActive(false);
            knife2.SetActive(true);
            knife3.SetActive(false);
            PlayerPrefs.SetInt("selected", 2);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("knife2", 1);
            PlayerPrefs.Save();
            OwnKnife2 = 1;
        }
    }

    public void buyThirdKnife()
    {
        if (appleCount >= 10)
        {
            appleCount -= 10;
            PlayerPrefs.SetInt("Apples", appleCount);
            PlayerPrefs.Save();
            Knife3Button.SetActive(false);
            Knife3Image.SetActive(true);
            knife1selected.SetActive(false);
            knife2selected.SetActive(false);
            knife3selected.SetActive(true);
            knife1.SetActive(false);
            knife2.SetActive(false);
            knife3.SetActive(true);
            PlayerPrefs.SetInt("selected", 3);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("knife3", 1);
            PlayerPrefs.Save();
            OwnKnife3 = 1;
        }
    }

    public void chosefirst()
    {
        PlayerPrefs.SetInt("selected", 1);
        PlayerPrefs.Save();
        knife1.SetActive(true);
        knife2.SetActive(false);
        knife3.SetActive(false);
        tochose1.SetActive(false);
        tochose2.SetActive(true);
        tochose3.SetActive(true);
        knife1selected.SetActive(true);
        knife2selected.SetActive(false);
        knife3selected.SetActive(false);
        Knife.GetComponent<SpriteRenderer>().sprite = sprite1;
        Knife1.GetComponent<SpriteRenderer>().sprite = sprite1;
    }
    public void chosesecond()
    {
        if(OwnKnife2 == 1)
        {
            PlayerPrefs.SetInt("selected", 2);
            PlayerPrefs.Save();
            knife1.SetActive(false);
            knife2.SetActive(true);
            knife3.SetActive(false);
            tochose1.SetActive(true);
            tochose2.SetActive(false);
            tochose3.SetActive(true);
            knife1selected.SetActive(false);
            knife2selected.SetActive(true);
            knife3selected.SetActive(false);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite2;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        
    }
    public void chosethird()
    {
        if(OwnKnife3 == 1)
        {
            PlayerPrefs.SetInt("selected", 3);
            PlayerPrefs.Save();
            knife1.SetActive(false);
            knife2.SetActive(false);
            knife3.SetActive(true);
            tochose1.SetActive(true);
            tochose2.SetActive(true);
            tochose3.SetActive(false);
            knife1selected.SetActive(false);
            knife2selected.SetActive(false);
            knife3selected.SetActive(true);
            Knife.GetComponent<SpriteRenderer>().sprite = sprite3;
            Knife1.GetComponent<SpriteRenderer>().sprite = sprite3;
        }
        
    }
    public void resetat()
    {
        PlayerPrefs.SetInt("selected", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("knife2", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("knife3", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Apples", 0);
        knife1selected.SetActive(true);
        knife2selected.SetActive(false);
        knife3selected.SetActive(false);
        knife1.SetActive(true);
        knife2.SetActive(false);
        knife3.SetActive(false);
    }

    public void setac()
    {
        settings.SetActive(true);
    }
    public void setkapa()
    {
        settings.SetActive(false);  
    }
}
