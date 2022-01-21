using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class picmain12 : MonoBehaviour
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
    public static Sprite[] images;
    bool exists = false;
    private static List<int> listNumbers = new List<int>();
    int index;


    // private List<int> intList2 = Enumerable.Range(0, 20).ToList();




    // Start is called before the first frame update
    void Start()
    {

        images = Loadimages.images;
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

        if (listNumbers.Count == 20)
        {
            listNumbers.Clear();
        }
        SetCurrentpic();
    }

    void SetCurrentpic()
    {
        Debug.Log("hi");


        do
        {
            index = UnityEngine.Random.Range(0, 20);
            Debug.Log("index" + index);
        } while (listNumbers.Contains(index));

        Debug.Log("final index" + index);

        listNumbers.Add(index);

        for(int i = 0; i< listNumbers.Count; i++)
        {
            Debug.Log("list contains " + listNumbers[i]);
        }


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
        PlayerPrefs.SetInt("mscore", score);
        yield return new WaitForSeconds(okr);
        listNumbers.Clear();
        SceneManager.LoadScene("level 2");


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
          //  lives--;
         //   PlayerPrefs.SetInt("lives", lives);
          //  PlayerPrefs.Save();
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
         //   if (lives < 1)
         //   {
          //      if (score > PlayerPrefs.GetInt("HighScore", 0))
          ////      {
          //          PlayerPrefs.SetInt("HighScore", Convert.ToInt32(score));

          //      }
            PlayerPrefs.SetInt("score", score);
            //    SceneManager.LoadScene("lost");
            // }

        }
        if (ques % 4 == 0 && ques != 0)
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
         //   lives--;
          //  PlayerPrefs.SetInt("lives", lives);
          //  PlayerPrefs.Save();
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
           // if (lives < 1)
           // {
            //    if (score > PlayerPrefs.GetInt("HighScore", 0))
            //    {
            //        PlayerPrefs.SetInt("HighScore", Convert.ToInt32(score));

            //    }
             PlayerPrefs.SetInt("score", score);
            //        SceneManager.LoadScene("lost");
            //  }
        }
        if (ques % 4 == 0 && ques != 0)
        {
            StartCoroutine(Newrep(okr));
        }

        StartCoroutine(TransitionToNextPic());
    }
}