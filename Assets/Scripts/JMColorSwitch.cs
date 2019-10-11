using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JMColorSwitch : MonoBehaviour
{

    public RectTransform handleRectTransform;
    public GameObject button;
    private Image image;
    private Image bgImage;
    bool isOn; //true : on;
               //스위치 On/off 동작 
    public float times=1f;

    public Renderer Renderer;

    int i = -13; 

    private void Start()
    {
        isOn = false;
        gameObject.AddComponent<Image>();

        handleRectTransform.anchoredPosition = new Vector2(-13, 0);
        
        bgImage = GetComponent<Image>();
        image = button.GetComponent<Image>();
    }

    public void SetSwitchOn()
    {
        //TODO : 스위치를 끄거나 켜는 작업을 구현
       

        isOn = true;
        StartCoroutine(btmove());


        Debug.Log("on");
        image.color = Color.green;
        bgImage.color = Color.red;

    } 

    IEnumerator btmove()
    {
        if (isOn == false)
        {
            if (i >= -13)
            {
                handleRectTransform.anchoredPosition = new Vector2(i, 0);
                i--;
            }
            else
            {
                StopAllCoroutines();
            }

            yield return new WaitForSeconds(0.1f/times);
           
        }
        else if (isOn == true)
        {
            if (i <= 13)
            {
                handleRectTransform.anchoredPosition = new Vector2(i, 0);
                i++;
            }
            else
            {
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(0.1f / times);


        }

        StartCoroutine(btmove());
    }



    public void SetSwitchOff()
    {
        isOn = false;

        StartCoroutine(btmove()); 
        Debug.Log("off");
        image.color = Color.cyan;
        bgImage.color = Color.yellow;

    }

    public void OnClickSwitch()
    {         
        if(isOn== false)
        {
            SetSwitchOn();
        }
        else
        {
            SetSwitchOff();
        }
         
    }


}
