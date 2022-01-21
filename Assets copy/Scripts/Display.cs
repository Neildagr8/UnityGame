using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    public Word[] words_;

    public float delay = 6;

    public static List<Word> DispUnanswered;
    public static List<string> CrispUnanswered = new List<string>();
    private float timeBetweenWords = 4f;
    public static List<string> aok;

    [SerializeField]
    private Text Panel1;
    [SerializeField]
    private Text Panel2;
    [SerializeField]
    private Text Panel3;
    [SerializeField]
    private Text Panel4;
    [SerializeField]
    private Text Panel5;
    [SerializeField]
    private Text Panel6;
    [SerializeField]
    private Text Panel7;
    [SerializeField]
    private Text Panel8;
    [SerializeField]
    private Text Panel9;
    [SerializeField]
    private Text Panel10;

    private void Start()
    {
        DispUnanswered = words_.ToList<Word>();
        DispUnanswered = DispUnanswered.OrderBy(x => Random.value).ToList();
        DispUnanswered = DispUnanswered.GetRange(0, 10);
        Word oneq = DispUnanswered[0];
        Word twoq = DispUnanswered[1];
        Word threeq = DispUnanswered[2];
        Word fourq = DispUnanswered[3];
        Word fiveq = DispUnanswered[4];
        Word sixq = DispUnanswered[5];
        Word sevenq = DispUnanswered[6];
        Word eightq = DispUnanswered[7];
        Word nineq = DispUnanswered[8];
        Word tenq = DispUnanswered[9];
        Panel1.text = oneq.word;
        Panel2.text = twoq.word;
        Panel3.text = threeq.word;
        Panel4.text = fourq.word;
        Panel5.text = fiveq.word;
        Panel6.text = sixq.word;
        Panel7.text = sevenq.word;
        Panel8.text = eightq.word;
        Panel9.text = nineq.word;
        Panel10.text = tenq.word;
        CrispUnanswered.Clear();
        foreach (Word item in DispUnanswered) 
        {
            CrispUnanswered.Add(item.word);

        }


        StartCoroutine(LoadLevelAfterDelay(delay));

    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("main");
    }
}



