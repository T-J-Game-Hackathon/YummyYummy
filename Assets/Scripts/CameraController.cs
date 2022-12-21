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
        pos.z = TargetObject.transform.position.z - radius;
        Vector3 rad = Camera.eulerAngles;
        rad.x = Mathf.Atan(height / radius);
        rad.y = 0f;
        rad.z = 0f;
        Camera.eulerAngles = rad;
    }

    void Update()
    {
        transform.RotateAround(TargetObject.transform.position, new Vector3(0, 1, 0), speed);
    }
}
