using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NewBehaviourScript : MonoBehaviour
{


    [SerializeField]
    private Text TrueAnswerText;

    [SerializeField]
    private Text FalseAnswerText;

    [SerializeField]
    private Animator animator;
    public Image Image;
    private float timeBetweenWords = 0.5f;
    public static List<int> intList;
    public static int lives = 3;
    public static int score = 0;
    public static int ques = 0;
    public static float okr = 0.1f;
   // private List<int> intList2 = Enumerable.Range(0, 20).ToList();
    List<int> listNumbers = new List<int>();

    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public Sprite s10;
    public Sprite s11;
    public Sprite s12;
    public Sprite s13;
    public Sprite s14;
    public Sprite s15;
    public Sprite s16;
    public Sprite s17;
    public Sprite s18;
    public Sprite s19;
    public static Sprite[] images;
    bool exists = false;
    int index;

    // Start is called before the first frame update
    void Start()
    {

        images = new Sprite[20];
        images[0] = s0;
        images[1] = s1;
        images[2] = s2;
        images[3] = s3;
        images[4] = s4;
        images[5] = s5;
        images[6] = s6;
        images[7] = s7;
        images[8] = s8;
        images[9] = s9;
        images[10] = s10;
        images[11] = s11;
        images[12] = s12;
        images[13] = s13;
        images[14] = s14;
        images[15] = s15;
        images[16] = s16;
        images[17] = s17;
        images[18] = s18;
        images[19] = s19;
        score = PlayerPrefs.GetInt("score", 0);
        lives = PlayerPrefs.GetInt("lives", 0);
        ques = PlayerPrefs.GetInt("ques", 0);
        if (lives == 0)
        {
            lives = 3;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.Save();
            
            score = 0;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();

            ques = 0;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
        }
        //if (intList2 == null || intList2.Count == 0)
       // {
       //     intList2 = Enumerable.Range(0, 20).ToList();
       //     listNumbers.Clear();

       // }
        SetCurrentpic();
    }

    void SetCurrentpic()
    {
        for (int i = 0; i< listNumbers.Count; i++)
        {
            Debug.Log(listNumbers[i]);
        }
        do
        {
            index = UnityEngine.Random.Range(0, 20);
        } while (listNumbers.Contains(index));
        listNumbers.Add(index);
        Debug.Log(index);
        Image.sprite = images[index];
        intList = Loadimages.intList;
        exists = intList.Contains(index);
        if (exists)
        {
            TrueAnswerText.text = "CORRECT";
            FalseAnswerText.text = "INCORRECT";
        }
        else
        {
            FalseAnswerText.text = "CORRECT";
            TrueAnswerText.text = "INCORRECT";
        }

    }
    IEnumerator TransitionToNextPic()
    {
        yield return new WaitForSeconds(timeBetweenWords);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Newrep(float okr)
    {
        yield return new WaitForSeconds(okr);
        listNumbers.Clear();
        SceneManager.LoadScene("Menu");


    }
    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (intList.Contains(index))
        {
            Debug.Log("correct");
            score++;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("nope");
            lives--;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.Save();
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
            if (lives < 1)
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", Convert.ToInt32(score));

                }
                PlayerPrefs.SetFloat("score", score);
                SceneManager.LoadScene("lost");
            }

        }
        if (ques % 10 == 0 && ques != 0)
        {
            StartCoroutine(Newrep(okr));
        }

        StartCoroutine(TransitionToNextPic());
    }
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!intList.Contains(index))
        {
            Debug.Log("correct");
            score++;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("nope");
            lives--;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.Save();
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
            if (lives < 1)
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", Convert.ToInt32(score));

                }
                PlayerPrefs.SetFloat("score", score);
                SceneManager.LoadScene("lost");
            }
        }
        if (ques % 10 == 0 && ques != 0)
        {
            StartCoroutine(Newrep(okr));
        }

        StartCoroutine(TransitionToNextPic());
    }
}