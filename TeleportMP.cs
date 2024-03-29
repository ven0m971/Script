using System.Collections;
using UnityEngine;

public class TeleportMP : MonoBehaviour
{
    FadeScript fadeScript;
    Animator animator;

    [SerializeField] GameObject Tp01;
    [SerializeField] GameObject Tp02;
    [SerializeField] GameObject Tp03;
    [SerializeField] GameObject FadePanel;



    Vector3 Tp01Location;
    Vector3 Tp02Location;
    Vector3 Tp03Location;

    // Start is called before the first frame update
    void Start()
    {
        Tp01Location = Tp01.transform.position;
        Tp02Location = Tp02.transform.position;
        Tp03Location = Tp03.transform.position;
       
    }

    // Update is called once per frame
    //A coroutine allows you to spread tasks across several frames
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(DelayTeleport(Tp01Location));

        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(DelayTeleport(Tp02Location));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(DelayTeleport(Tp03Location));
        }

    }
    void teleportPlayer(Vector3 TpLocation)
    {
        FadeOut();
        gameObject.transform.position = TpLocation;
    }
    //to delay something in code
    IEnumerator DelayTeleport(Vector3 TpLocation)
    {
        FadeIn();
        yield return new WaitForSeconds(2f);
        teleportPlayer(TpLocation);
        FadeOut();
        yield return new WaitForSeconds(1f);
    }
    public void FadeIn()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
      
    }
    public void FadeOut()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        
    }

}
