using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;

    private Vector3 offset;

    public void Start()
    {
        offset = GetComponent<Transform>().position - target.transform.position;
    }

    public void Update()
    {
        GetComponent<Transform>().position = target.transform.position + offset;
    }
}
