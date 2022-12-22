using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private float height;

    [SerializeField]
    public float speed;

    [SerializeField]
    public GameObject TargetObject;

    void Start()
    {
        Transform Camera = this.transform;

        Vector3 pos = Camera.position;
        pos.x = TargetObject.transform.position.x;
        pos.y = TargetObject.transform.position.y + height;
        pos.z = TargetObject.transform.position.z - radius;

        transform.position = pos;
    }

    void Update()
    {
        transform.RotateAround(TargetObject.transform.position, new Vector3(0, 1, 0), speed);
    }
}
