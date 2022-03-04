using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockerController : MonoBehaviour
{
    public GameObject Mismatch;
    public GameObject Bellissimo;
    public GameObject Constellation;
    public GameObject Disaster;
    public GameObject Theia;
    public GameObject Astrofacts;
    public GameObject Meditation;
    public GameObject Rhythm;
    public GameObject Feline;
    public GameObject Cannon;


    // Start is called before the first frame update
    void Start()
    {
        Cannon.GetComponent<Button>().interactable = (PlayerPrefs.GetInt("cannon") == 1);
        Rhythm.GetComponent<Button>().interactable = PlayerPrefs.GetInt("rhythm") == 1;
        Disaster.GetComponent<Button>().interactable = PlayerPrefs.GetInt("disaster") == 1;
        Mismatch.GetComponent<Button>().interactable = PlayerPrefs.GetInt("mismatched") == 1;
        Bellissimo.GetComponent<Button>().interactable = PlayerPrefs.GetInt("bellissimo") == 1;
        Theia.GetComponent<Button>().interactable = PlayerPrefs.GetInt("theia") == 1;
        Feline.GetComponent<Button>().interactable = PlayerPrefs.GetInt("feline") == 1;
        Meditation.GetComponent<Button>().interactable = PlayerPrefs.GetInt("meditation") == 1;
        Constellation.GetComponent<Button>().interactable = PlayerPrefs.GetInt("constellation") == 1;
        Astrofacts.GetComponent<Button>().interactable = PlayerPrefs.GetInt("astrofacts") == 1;

        /*     Mismatch.SetActive(PlayerPrefs.GetInt("mismatched") == 1);
             Feline.SetActive(PlayerPrefs.GetInt("feline") == 1);
             Bellissimo.SetActive(PlayerPrefs.GetInt("bellissimo") == 1);
             Theia.SetActive(PlayerPrefs.GetInt("theia") == 1);
             Disaster.SetActive(PlayerPrefs.GetInt("disaster") == 1);
             Constellation.SetActive(PlayerPrefs.GetInt("constellation") == 1);
             Astrofacts.SetActive(PlayerPrefs.GetInt("astrofacts") == 1);
             Rhythm.SetActive(PlayerPrefs.GetInt("rhythm") == 1);
             Meditation.SetActive(PlayerPrefs.GetInt("meditation") == 1);
             Cannon.SetActive(PlayerPrefs.GetInt("cannon") == 1);
     */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
