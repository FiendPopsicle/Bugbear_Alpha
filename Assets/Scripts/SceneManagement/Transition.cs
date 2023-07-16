using Bugbear.Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public static Transition current;
    [SerializeField] private Image _curtain;
    public bool isDone = false;

    private void Awake()
    {
        current = this;
        _curtain = GetComponent<Image>();
    }

    #region LISTENERS
    private void OnEnable()
    {
        GlobalPointer._sceneManager.onRequestCurtain += ReceiveCurtain;
    }
    private void OnDisable()
    {
        GlobalPointer._sceneManager.onRequestCurtain -= ReceiveCurtain;
    }
    #endregion

    private void ReceiveCurtain(string fade)
    {
        StartCoroutine(Fade(fade));
    }

    private IEnumerator Fade(string request)
    {
        if (request == "fadeOut")
        {
            isDone = false;
            // Loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                _curtain.color = new Color(0, 0, 0, i);
                yield return null;
            }
            isDone = true;
        }

        // fade from transparent to opaque
        if (request == "fadeIn")
        {
            isDone = false;
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                _curtain.color = new Color(0, 0, 0, i);
                yield return null;
            }
            isDone = true;
        }
    }
}
