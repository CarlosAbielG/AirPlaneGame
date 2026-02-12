using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float time;
    public TextMeshProUGUI timerText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = Mathf.Floor(time).ToString();
    }
}
