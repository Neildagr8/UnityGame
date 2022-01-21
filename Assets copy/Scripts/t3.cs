using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class t3 : MonoBehaviour
{
    int one;
    int two;
    int three;
    int four;
    int five;
    int six;
    int seven;
    int eight;
    int nine;
    int ten;
    int eleven;
    int twelve;
    int minute_reg;
    float z;
    float z_hr;
    bool one_hr = false;
    bool two_hr = false;
    bool three_hr = false;
    bool four_hr = false;
    bool five_hr = false;
    bool six_hr = false;
    bool seven_hr = false;
    bool eight_hr = false;
    bool nine_hr = false;
    bool ten_hr = false;
    bool eleven_hr = false;
    bool twelve_hr = false;

    bool one_min = false;
    bool two_min = false;
    bool three_min = false;
    bool four_min = false;
    bool five_min = false;
    bool six_min = false;
    bool seven_min = false;
    bool eight_min = false;
    bool nine_min = false;
    bool ten_min = false;
    bool eleven_min = false;
    bool twelve_min = false;
    bool correct_min = false;
    bool correct_hour = false;


    [SerializeField]
    public TMP_Dropdown input_1;
    public TMP_Dropdown input_2;
    public TMP_Dropdown input_3;
    public TMP_Dropdown input_4;
    public TMP_Dropdown input_5;
    public TMP_Dropdown input_6;
    public TMP_Dropdown input_7;
    public TMP_Dropdown input_8;
    public TMP_Dropdown input_9;
    public TMP_Dropdown input_10;
    public TMP_Dropdown input_11;
    public TMP_Dropdown input_12;
    public Text timern;
    public int hour_num;
    public int mint_num;


    public void Start()
    {
        hour_num = Random.Range(1, 13);
        mint_num = Random.Range(0, 60);
        string hour_num_str = hour_num.ToString();
        string mint_num_str = mint_num.ToString();
        if (hour_num < 10)
        {
            hour_num_str = ("0" + hour_num_str);
        }
        if (mint_num < 10)
        {
            mint_num_str = ("0" + mint_num_str);
        }

        timern.text = (hour_num_str + ":" + mint_num_str);

    }

    public void changename()
    {
        try {
            input_1 = GameObject.Find("1").GetComponent<TMP_Dropdown>();
            input_2 = GameObject.Find("2").GetComponent<TMP_Dropdown>();
            input_3 = GameObject.Find("3").GetComponent<TMP_Dropdown>();
            input_4 = GameObject.Find("4").GetComponent<TMP_Dropdown>();
            input_5 = GameObject.Find("5").GetComponent<TMP_Dropdown>();
            input_6 = GameObject.Find("6").GetComponent<TMP_Dropdown>();
            input_7 = GameObject.Find("7").GetComponent<TMP_Dropdown>();
            input_8 = GameObject.Find("8").GetComponent<TMP_Dropdown>();
            input_9 = GameObject.Find("9").GetComponent<TMP_Dropdown>();
            input_10 = GameObject.Find("10").GetComponent<TMP_Dropdown>();
            input_11 = GameObject.Find("11").GetComponent<TMP_Dropdown>();
            input_12 = GameObject.Find("12").GetComponent<TMP_Dropdown>();
            one = int.Parse(input_1.captionText.text);
            two = int.Parse(input_2.captionText.text);
            three = int.Parse(input_3.captionText.text);
            four = int.Parse(input_4.captionText.text);
            five = int.Parse(input_5.captionText.text);
            six = int.Parse(input_6.captionText.text);
            seven = int.Parse(input_7.captionText.text);
            eight = int.Parse(input_8.captionText.text);
            nine = int.Parse(input_9.captionText.text);
            ten = int.Parse(input_10.captionText.text);
            eleven = int.Parse(input_11.captionText.text);
            twelve = int.Parse(input_12.captionText.text);

            z = minute12.z_rotate;
            z_hr = hour.z_rotate_hr;
            string z_str = z.ToString();
            string z_hr_str = z_hr.ToString();

            if (z_hr < 25 && z_hr >= 355)
            {
                eleven_hr = true;
            }
            else if (z_hr >= 25 && z_hr < 55)
            {
                ten_hr = true;
            }
            else if (z_hr >= 55 && z_hr < 85)
            {
                nine_hr = true;
            }
            else if (z_hr >= 85 && z_hr < 115)
            {
                eight_hr = true;
            }
            else if (z_hr >= 115 && z_hr < 145)
            {
                seven_hr = true;
            }
            else if (z_hr >= 145 && z_hr < 175)
            {
                six_hr = true;
            }
            else if (z_hr >= 175 && z_hr < 205)
            {
                five_hr = true;
            }
            else if (z_hr >= 205 && z_hr < 235)
            {
                four_hr = true;
            }
            else if (z_hr >= 235 && z_hr < 265)
            {
                three_hr = true;
            }
            else if (z_hr >= 265 && z_hr < 295)
            {
                two_hr = true;
            }
            else if (z_hr >= 295 && z_hr < 325)
            {
                one_hr = true;
            }
            else if (z_hr >= 325 && z_hr < 355)
            {
                twelve_hr = true;
            }


            if (z < 25 && z >= 355)
            {
                twelve_min = true;
            }
            else if (z >= 25 && z < 55)
            {
                eleven_min = true;
            }
            else if (z >= 55 && z < 85)
            {
                ten_min = true;
            }
            else if (z >= 85 && z < 115)
            {
                nine_min = true;
            }
            else if (z >= 115 && z < 145)
            {
                eight_min = true;
            }
            else if (z >= 145 && z < 175)
            {
                seven_min = true;
            }
            else if (z >= 175 && z < 205)
            {
                six_min = true;
            }
            else if (z >= 205 && z < 235)
            {
                five_min = true;
            }
            else if (z >= 235 && z < 265)
            {
                four_min = true;
            }
            else if (z >= 265 && z < 295)
            {
                three_min = true;
            }
            else if (z >= 295 && z < 325)
            {
                two_min = true;
            }
            else if (z >= 325 && z < 355)
            {
                one_min = true;
            }

            switch (hour_num)
            {
                case 1:
                    if (one_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 2:
                    if (two_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 3:
                    if (three_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 4:
                    if (four_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 5:
                    if (five_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 6:
                    if (six_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 7:
                    if (seven_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 8:
                    if (eight_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 9:
                    if (nine_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 10:
                    if (ten_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 11:
                    if (eleven_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
                case 12:
                    if (twelve_hr == true)
                    {
                        correct_hour = true;
                    }
                    break;
            }



            if (mint_num <= 5)
            {
                minute_reg = 1;
            }
            else if (mint_num <= 10)
            {
                minute_reg = 2;
            }
            else if (mint_num <= 15)
            {
                minute_reg = 3;
            }
            else if (mint_num <= 20)
            {
                minute_reg = 4;
            }
            else if (mint_num <= 25)
            {
                minute_reg = 5;
            }
            else if (mint_num <= 30)
            {
                minute_reg = 6;
            }
            else if (mint_num <= 35)
            {
                minute_reg = 7;
            }
            else if (mint_num <= 40)
            {
                minute_reg = 8;
            }
            else if (mint_num <= 45)
            {
                minute_reg = 9;
            }
            else if (mint_num <= 50)
            {
                minute_reg = 10;

            }
            else if (mint_num <= 55)
            {
                minute_reg = 11;
            }
            else if (mint_num <= 60)
            {
                minute_reg = 12;
            }

            switch (minute_reg)
            {
                case 1:
                    if (one_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 2:
                    if (two_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 3:
                    if (three_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 4:
                    if (four_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 5:
                    if (five_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 6:
                    if (six_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 7:
                    if (seven_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 8:
                    if (eight_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 9:
                    if (nine_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 10:
                    if (ten_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 11:
                    if (eleven_min == true)
                    {
                        correct_min = true;
                    }
                    break;
                case 12:
                    if (twelve_min == true)
                    {
                        correct_min = true;
                    }
                    break;
            }
            if (correct_hour == true && correct_min == true)
            {
                if (one == 1 && two == 2 && three == 3 && four == 4 && five == 5 && six == 6 && seven == 7 && eight == 8 && nine == 9 && ten == 10 && eleven == 11 && twelve == 12)
                {
                    //     PlayerPrefs.SetInt("cscore", 2);
                    SceneManager.LoadScene("Starter 2");
                }
                else
                {
                    //    PlayerPrefs.SetInt("cscore", 1);
                    SceneManager.LoadScene("Starter 2");
                }

            }
            else
            {
                if (one == 1 && two == 2 && three == 3 && four == 4 && five == 5 && six == 6 && seven == 7 && eight == 8 && nine == 9 && ten == 10 && eleven == 11 && twelve == 12)
                {
                    //     PlayerPrefs.SetInt("cscore", 1);
                    SceneManager.LoadScene("Starter 2");
                }
                else
                {
                    //     PlayerPrefs.SetInt("cscore", 0);
                    SceneManager.LoadScene("Starter 2");
                }



            }
        }
        catch (System.FormatException)
        {
            PlayerPrefs.SetInt("cscore", 1);
            SceneManager.LoadScene("Starter 2");
        }

}
}