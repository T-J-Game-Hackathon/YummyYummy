using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed = 150f;

    [SerializeField]
    public float turnSpeed = 10f;

    [SerializeField]
    public Crop holdingCrop;

    [SerializeField]
    public float jumpForce = 6.5f;

    private Animator animator;
    private Rigidbody rb;
    private bool canJump = true;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        holdingCrop = Crop.Potato;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            holdingCrop = Crop.Potato;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            holdingCrop = Crop.Spinach;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            holdingCrop = Crop.Tomato;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    public void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        if (x == 0 && z == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = Vector3.zero;

            animator.SetBool(PlayerAnimState.isRun.ToString(), false);
        }
        else
        {
            rb.AddForce(x * speed, 0, z * speed);

            float degree = 90 - (Mathf.Atan2(z, x) * 180 / Mathf.PI);
            Quaternion dest_quat = Quaternion.Euler(0, degree, 0);
            Quaternion curr_quat = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(curr_quat, dest_quat, turnSpeed);

            animator.SetBool(PlayerAnimState.isRun.ToString(), true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.CompareTag("Crop"))
        {
            var arableLand = obj.GetComponent<ArableLand>();
            if (arableLand.isHarvestable)
            {
                arableLand.Harvest();
                animator.SetBool(PlayerAnimState.isHarvestAndPlant.ToString(), true);
            }
            else if (!arableLand.hasPlanted)
            {
                arableLand.Plant(holdingCrop);
                animator.SetBool(PlayerAnimState.isHarvestAndPlant.ToString(), true);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Crop"))
        {
            animator.SetBool(PlayerAnimState.isHarvestAndPlant.ToString(), false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 地面と接触したら、ジャンプできるようにする
            canJump = true;
        }
    }
}
