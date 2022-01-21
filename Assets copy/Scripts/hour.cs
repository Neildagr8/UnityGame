using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hour : MonoBehaviour
{
    public static float z_rotate_hr;
    float angle = -1f;
    Vector3 axis = new Vector3(0, 0, 1);
    float anglePerUpdate = -0.5f;
    public Font myFont; //set it in the inspector
    float desiredWidthPixels = Screen.width * 0.2f;



    void OnGUI()
    {

        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 40;
        myButtonStyle.normal.textColor = Color.blue;
        myButtonStyle.hover.textColor = Color.blue;
        myButtonStyle.font = myFont;
        Color activeButtonColor = new Color(0.3f, 0.3f, 0.3f, 1.0f);
        //create another button below "Rotate Once".
        //this is a  RepeatButton that will continue to perform its action every update
        if (GUI.RepeatButton(new Rect(75, 200, desiredWidthPixels, 100), "Hour Hand", myButtonStyle))
        {
            //if button is pressed, perform the following
            //rotate the object at a specified speed, around the specified axis
            //take the existing rotation and add a little bit to it
            this.transform.rotation =
            this.transform.rotation * Quaternion.AngleAxis(anglePerUpdate, axis);
            z_rotate_hr = gameObject.transform.rotation.eulerAngles.z;
        }
    }
}
