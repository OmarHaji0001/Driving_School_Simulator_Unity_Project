using System.Collections;
using TMPro;
using UnityEngine;
public class TriggerDetector2 : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject banket;
    private Collider banketCollider;

    private int wayes =0;
        //private static int printed =0;

    private void OnTriggerEnter(Collider other)
    {
            
        // Check if the entering collider is tagged as "Car"
        if (other.CompareTag("Car"))
        {
            if (other.CompareTag("Car")) // Make sure the entering object is tagged as "Car"
        {
            Vector3 entryDirection = other.transform.position - transform.position;
            float dotForward = Vector3.Dot(entryDirection.normalized, transform.forward);
            float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);

            if (Mathf.Abs(dotForward) > Mathf.Abs(dotRight))
            {
                // The car is entering from the front or back
                if (dotForward > 0)
                {
                    Debug.Log("The car entered from the front.");
                                        wayes =2;

                }
                else
                {
                    Debug.Log("The car entered from the back.");
                                        wayes =1;
                }
            }
            else
            {
                // The car is entering from the left or right
                if (dotRight > 0)
                {
                    Debug.Log("The car entered from the right.");
                    wayes =1;

                }
                else
                {
                    Debug.Log("The car entered from the left.");
                                                            wayes =2;

                }
            }
        }
    
            
              
              
              
              
               //linesparent.set1(1);
            // Get the position of the trigger collider
            Vector3 triggerPosition = transform.position;

            // Get the position of the entering car
            Vector3 carPosition = other.transform.position;

            // Compare the x-coordinate of the car's position with the x-coordinate of the trigger's position
            if (carPosition.x > triggerPosition.x)
            {
                //Debug.Log("Car entered from the left");
//wayes =2;
            }
            else
            {
               // Debug.Log("Car entered from the right");
//wayes = 1;
            }
        }
            
    }
 
    private void OnTriggerExit(Collider other)
    {
        // Check if the entering collider is tagged as "Car"
        if (other.CompareTag("Car")&&linesparent.glock()==0)
        {
             if (banket != null)
        {
            // Get the Collider component from Banket
            banketCollider = banket.GetComponent<Collider>();
        }
      //  Debug.Log(banketCollider.bounds.Contains(transform.position));

       // if(banketCollider.bounds.Contains(transform.position)==false||banket!=null)
        {
//Debug.Log(banketCollider.bounds.Contains(transform.position));

            // Get the position of the trigger collider
            Vector3 triggerPosition = transform.position;

            // Get the position of the entering car
            Vector3 carPosition = other.transform.position;

            // Compare the x-coordinate of the car's position with the x-coordinate of the trigger's position
           // Debug.Log(linesparent.get());
                       // Debug.Log(wayes);
                                     //   linesparent.set1(wayes);

                        //linesparent.get1();
//Debug.Log(linesparent.get()+"L");
             //   Debug.Log(wayes+"w");
               // if(wayes==2&&linesparent.get())

            if(linesparent.get()==0)
            {
                //Debug.Log(wayes);
            if (carPosition.x > triggerPosition.x&&wayes==1&&linesparent.get()==0)
            {
                //printed=1;
                                linesparent.set1(0);


                linesparent.set(2);
               warningPanel.SetActive(true);

                    // Optionally, set the text dynamically
                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        linesparent.slockk(1);
                        textComponent.text = "u crrosed a continuoes lineeeeeee";
                        strikes.incStrike();
                    }

                    // Hide the panel after a delay
                    StartCoroutine(HidePanelAfterDelay(5)); // Hide after 5 seconds
            }
            else if(wayes==2)
            {
                //printed=1;
                                linesparent.set(1);
               warningPanel.SetActive(true);

                    // Optionally, set the text dynamically
                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                          linesparent.slockk(1);
                        textComponent.text = "u crrosed a continuoes line2";
                        strikes.incStrike();
                    }

                    // Hide the panel after a delay
                    StartCoroutine(HidePanelAfterDelay(5)); // Hide after 5 seconds
            }
            
            }
            else if(!(wayes==1&&linesparent.get()==2 )){
                linesparent.set(0);
}

        }
        }
    }
    
     IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }
    
}


// using UnityEngine;
// using TMPro; // Add this to access TextMeshPro elements
// using System.Collections; // Required for coroutines

// public class StopSignDetection : MonoBehaviour
// {
//     private bool hasStopped = false;
//     public GameObject stopSignPanel;
//     private TextMeshProUGUI messageText;
//     private Vector3 correctDirection = Vector3.right; // Adjusted for horizontal detection
//     private bool flg = true;

//     private void Start()
//     {
//         if (stopSignPanel != null)
//         {
//             // Find the TextMeshProUGUI component in the Panel
//             messageText = stopSignPanel.GetComponentInChildren<TextMeshProUGUI>();
//             stopSignPanel.SetActive(false); // Ensure the panel is hidden at start
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Car") && other.attachedRigidbody.velocity.magnitude > 0 && flg)
//         {
//             Vector3 carDirection = other.transform.forward;
//             Vector3 toCar = other.transform.position - transform.position; // Vector from stop sign to car

//             // Using cross product to determine if the car is on the left side
//             Vector3 crossProduct = Vector3.Cross(correctDirection, toCar);

//             if (crossProduct.y < 0) // Assuming y is up; if the car is to the left, crossProduct.y will be negative
//             {
//                 // Car is entering from the left
//                 if (Mathf.Abs(other.transform.eulerAngles.y - 270) < 45) // Check car's rotation, allowing some tolerance
//                 {
//                     // Car's rotation is approximately 270 degrees, but it's entering from the left
//                     if (messageText != null)
//                     {
//                         messageText.text = "You're entering from the wrong side.";
//                         strikes.incStrike(); // Assuming you have a mechanism to count strikes
//                         stopSignPanel.SetActive(true);
//                         StartCoroutine(HidePanelAfterDelay(3.0f)); // Hide the panel after 3 seconds
//                     }
//                     flg = false;
//                 }
//             }
//             else
//             {
//                 // Car is not entering from the left, handle accordingly
//             }
//         }
//     }

//     private void OnTriggerStay(Collider other)
//     {
//         if (other.CompareTag("Car") && other.attachedRigidbody.velocity.magnitude <= 0.5f && flg) // Adjust threshold as needed
//         {
//             hasStopped = true;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (flg)
//         {
//             if (other.CompareTag("Car") && !hasStopped && flg)
//             {
//                 if (messageText != null)
//                 {
//                     messageText.text = "You didn't stop at the stop sign!";
//                     strikes.incStrike();
//                     stopSignPanel.SetActive(true);
//                     StartCoroutine(HidePanelAfterDelay(3.0f)); // Delay for 3 seconds
//                 }
//             }
//             hasStopped = false;
//         }
//         flg = true;
//     }

//     IEnumerator HidePanelAfterDelay(float delay)
//     {
//         yield return new WaitForSeconds(delay); // Wait for the specified delay
//         stopSignPanel.SetActive(false); // Hide the panel
//     }
//     private void flagMe(Collider other)
//     {
//         if (other.CompareTag("Car")) // Make sure the entering object is tagged as "Car"
//         {
//             Vector3 entryDirection = other.transform.position - transform.position;
//             float dotForward = Vector3.Dot(entryDirection.normalized, transform.forward);
//             float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);

//             if (Mathf.Abs(dotForward) > Mathf.Abs(dotRight))
//             {
//                 // The car is entering from the front or back
//                 if (dotForward > 0)
//                 {
//                     Debug.Log("The car entered from the front.");
//                 }
//                 else
//                 {
//                     Debug.Log("The car entered from the back.");
//                 }
//             }
//             else
//             {
//                 // The car is entering from the left or right
//                 if (dotRight > 0)
//                 {
//                     Debug.Log("The car entered from the right.");
//                 }
//                 else
//                 {
//                     Debug.Log("The car entered from the left.");
//                 }
//             }
//         }
//     }
// }