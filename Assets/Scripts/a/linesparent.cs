
using UnityEngine;
using TMPro; 
using System.Collections; 

public class linesparent : MonoBehaviour
{
    public GameObject warningPanel;

    private static int locked = 0;
    private static int t = 0;
    private static int t2 = 0;
    private static int f = 0;
    bool f22 = false;
    int n = 0;
    int j = 0;


    private static int cross = 0;
    private static int cross2 = 0;

    private int doesitback = 0;
    private void Start() { }
    void FixedUpdate()
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        GameObject car = GameObject.FindWithTag("Car");
        Collider[] carColliders = car.GetComponents<Collider>();
        int g = 0;

        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.gameObject == gameObject) continue;

            Collider[] childColliders = childTransform.GetComponents<Collider>();

            foreach (Collider carCollider in carColliders)
            {
                foreach (Collider childCollider in childColliders)
                {
                    if (childCollider != null && carCollider != null)
                    {
                        if (childCollider.bounds.Intersects(carCollider.bounds))
                        {
                            g++;
                            
                            break; 
                        }
                    }
                }
            }
        }
        if (g == 2 && locked == 0 && f == 0)
        {
            locked = 1;
            warningPanel.SetActive(true);

            TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {

                textComponent.text = "u crrosed a continuoes linesss";
                strikes.incStrike();
            }

            StartCoroutine(HidePanelAfterDelay(5)); 
            doesitback = 0;
        }

        if (g == 0)
            
            if (f == 0 && g == 2)
            {
                doesitback = 1;
            }
        if (f == 2 && g == 1 && doesitback == 1)
        {
            doesitback = 2;
        }
        if (f == 1 && g == 1 && doesitback == 2)
        {
            doesitback = 3;
        }
        
        if (g == 0)
            doesitback = 1;
        if (f == 0 && g == 2)
        {
            n = 1;
        }
        if (f == 0 && g == 0 && n >= 1)
        {
            n = 2;
            if (j == 2)
                n = 0;
            if (f22)
            {
                j++;
                f22 = false;
            }


        }
        else
        {
            f22 = true;

        }

        if ((g == 1 && f == 2 && doesitback > 1) || (g == 2 && f == 2 && doesitback > 1) || doesitback == 3 || n > 0)
        {

            locked = 1;
            

        }
        else if (g == 1)
        {

            locked = 0;
            doesitback = 0;
            
            
        }
        f = g;
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }

    
    static public int glock() { return locked; }
    static public void slockk(int s)
    {
        locked = s;
    }

    static public int get() { return cross; }
    static public void set(int s)
    {
        cross = s;
    }
    static public int get1() { return cross2; }
    static public void set1(int s)
    {
        cross2 = s;
    }
    static public void gg(int wayes)
    {
        if (f != 0)
        {

            if (wayes == t)
            {
                t2 = 1;
            }
            if (t2 == 1)
                t = 0;

        }
    }


}