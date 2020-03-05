using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WaitForSecond : MonoBehaviour
{
    [SerializeField] private UnityEvent OnComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wait(float seconds)
    {
        StartCoroutine(IeWaitForSecond(seconds));
    }

    private IEnumerator IeWaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }
}
