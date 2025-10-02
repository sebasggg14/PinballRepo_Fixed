using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    private string levelToLoad;

    [SerializeField]
    CountdownScript countdown;

    public void FadeToLevel (string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnTransitionComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void TriggerCountdown()
    {
        countdown.StartCountdown();
    }
}
