using System.Collections.Generic;
//using UnityEngine;

//public class minute : MonoBehaviour
//
//private void Update()
// {


//float AngleRad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
//float AngleDeg = (180 / Mathf.PI) * AngleRad;
// this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

// }
//

using UnityEngine;
using System.Collections;

public class minute12 : MonoBehaviour
{
    public static float z_rotate;
    float angle = 10;
    Vector3 axis = new Vector3(0, 0, 1);
    float anglePerUpdate = -0.5f;
    public Font myFont; //set it in the inspector
    float desiredWidthPixels = Screen.width * 0.2f;


    void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 40;
        myButtonStyle.font = myFont;
        myButtonStyle.normal.textColor = Color.red;
        myButtonStyle.hover.textColor = Color.red;


        //create another button below "Rotate Once".
        //this is a  RepeatButton that will continue to perform its action every update
        if (GUI.RepeatButton(new Rect(75, 50, desiredWidthPixels, 100), "Minute Hand", myButtonStyle))
        {
            //if button is pressed, perform the following
            //rotate the object at a specified speed, around the specified axis
            //take the existing rotation and add a little bit to it
            this.transform.rotation =
                this.transform.rotation * Quaternion.AngleAxis(anglePerUpdate, axis);
            z_rotate = gameObject.transform.rotation.eulerAngles.z;
        }
    }
}