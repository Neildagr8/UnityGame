using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Newgame : MonoBehaviour
{
    public Word[] words2;
    public static List<Word> unansweredWords2;
    private Word currentWord;
    public static List<string> CrispUnanswered2;
    public static int lives;
    public static int score;
    public static int ques;
    public static float okr = 0.3f;
    public static List<Word> DispUnanswered2;


    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenWords = 0.5f;

    [SerializeField]
    private Text TrueAnswerText;

    [SerializeField]
    private Text FalseAnswerText;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        lives = PlayerPrefs.GetInt("lives", 0);
        ques = PlayerPrefs.GetInt("ques", 0);
        if (lives == 0)
        {
            lives = 3;
            score = 0;
            ques = 0;
        }
        DispUnanswered2 = Display2.DispUnanswered2;
        CrispUnanswered2 = Display2.CrispUnanswered2;
        if (unansweredWords2 == null || unansweredWords2.Count == 0)
        {
            unansweredWords2 = words2.ToList<Word>();
        }
        SetCurrentWord();
    }

    void SetCurrentWord()
    {
        int randomWordIndex = UnityEngine.Random.Range(0, unansweredWords2.Count);
        currentWord = unansweredWords2[randomWordIndex];
        Debug.Log(unansweredWords2[randomWordIndex]);
        for (var i = 0; i < CrispUnanswered2.Count; i++)
        {
            Debug.Log(CrispUnanswered2[i]);
        }
        if (CrispUnanswered2.Contains(currentWord.word))
        {
            currentWord.ispresent = true;
            Debug.Log(currentWord.ispresent);
        }
        factText.text = currentWord.word;

        if (currentWord.ispresent)
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

    IEnumerator TransitionToNextWord()
    {
        unansweredWords2.Remove(currentWord);

        yield return new WaitForSeconds(timeBetweenWords);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator newrep(float okr)
    {
        yield return new WaitForSeconds(okr);
        unansweredWords2.Clear();
        unansweredWords2 = words2.ToList<Word>();
        SceneManager.LoadScene("oda2");
    }


    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentWord.ispresent)
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
            Debug.Log(lives);
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
            if (lives < 1)
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);

                }
                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene("lost");
            }

        }
        if (ques % 10 == 0 && ques != 0)
        {
            StartCoroutine(newrep(okr));
            ques = 0;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();

        }

        StartCoroutine(TransitionToNextWord());
    }



    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentWord.ispresent)
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
            Debug.Log(lives);
            ques++;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
            if (lives < 1)
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);

                }
                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene("lost");
            }
        }
        if (ques % 10 == 0 && ques != 0)
        {
            StartCoroutine(newrep(okr));
            ques = 0;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
        }

        StartCoroutine(TransitionToNextWord());
    }
}