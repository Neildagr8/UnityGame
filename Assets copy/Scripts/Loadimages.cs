using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadimages : MonoBehaviour
{
    public static List<int> intList = new List<int>();
    public Image randomImage1;
    public float delay = 10;
    public Image randomImage2;
    public Image randomImage3;
    public Image randomImage4;
    public Image randomImage5;
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
    // Start is called before the first frame update
    void Start()
    {
        images = new Sprite[20];
        List<int> possible = Enumerable.Range(0, 20).ToList();
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
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, possible.Count);
            intList.Add(possible[index]);
            possible.RemoveAt(index);
        }

        Debug.Log(intList);
        randomImage1.sprite = images[intList[0]];
        randomImage2.sprite = images[intList[1]];
        randomImage3.sprite = images[intList[2]];
        randomImage4.sprite = images[intList[3]];
        randomImage5.sprite = images[intList[4]];

        StartCoroutine(LoadLevelAfterDelay(delay));

    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("picmain");
    }


}
