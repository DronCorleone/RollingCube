using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
public class PlatformCubeModel : MonoBehaviour
{
    private Animator _animator;


    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
        GetComponent<Animator>().SetTrigger("On");
    }
}