using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ngame : MonoBehaviour
{
    public Word[] words;
    public static List<Word> unansweredWords;
    private Word currentWord;
    public static List<string> CrispUnanswered;
    public static int lives;
    public static int score;
    public static int ques;
    public static float okr = 0.3f;
    public static List<Word> DispUnanswered;


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
        DispUnanswered = Display.DispUnanswered;
        CrispUnanswered = Display.CrispUnanswered;
        if (unansweredWords == null || unansweredWords.Count == 0)
        {
            unansweredWords = words.ToList<Word>();
        }
        SetCurrentWord();
    }

    void SetCurrentWord()
    {
        int randomWordIndex = UnityEngine.Random.Range(0, unansweredWords.Count);
        currentWord = unansweredWords[randomWordIndex];
        Debug.Log(unansweredWords[randomWordIndex]);
        for (var i = 0; i < CrispUnanswered.Count; i++)
        {
            Debug.Log(CrispUnanswered[i]);
        }
        if (CrispUnanswered.Contains(currentWord.word))
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
        unansweredWords.Remove(currentWord);

        yield return new WaitForSeconds(timeBetweenWords);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator newrep(float okr)
    {
        yield return new WaitForSeconds(okr);
        unansweredWords.Clear();
        unansweredWords = words.ToList<Word>();
        SceneManager.LoadScene("oda");
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
               // lives--;
              //  PlayerPrefs.SetInt("lives", lives);
              //  PlayerPrefs.Save();
              //  Debug.Log(lives);
                ques++;
                PlayerPrefs.SetInt("ques", ques);
                PlayerPrefs.Save();
              //  if (lives < 1)
              //  {
              //      if (score > PlayerPrefs.GetInt("HighScore", 0))
               //     {
               //         PlayerPrefs.SetInt("HighScore", Convert.ToInt32(score));

               //     }
                PlayerPrefs.SetInt("score", score);
               //     SceneManager.LoadScene("lost");
               // }

        }
        if (ques == 6)
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
              //  Debug.Log("nope");
             //   lives--;
            //// //   PlayerPrefs.SetInt("lives", lives);
            //    PlayerPrefs.Save();
             //   Debug.Log(lives);
                ques++;
               PlayerPrefs.SetInt("ques", ques);
               PlayerPrefs.Save();
              //  if (lives < 1)
              //  {
              //      if (score > PlayerPrefs.GetInt("HighScore", 0))
              //      {
              //          PlayerPrefs.SetInt("HighScore", Convert.ToInt32(score));

               //     }
                PlayerPrefs.SetInt("score", score);
               //     SceneManager.LoadScene("lost");
               // }
        }
        if (ques == 6)
        {
            StartCoroutine(newrep(okr));
            ques = 0;
            PlayerPrefs.SetInt("ques", ques);
            PlayerPrefs.Save();
        }

        StartCoroutine(TransitionToNextWord());
    }
}
