using UnityEngine;

public class HorizontalBullet : MonoBehaviour
{
    [SerializeField] float dmg = 1;

    private bool isActivated = false;

    public enum obstacleType
    {
        neutral,
        scissor,
        trombone
    }

    [SerializeField] obstacleType type;

    void Update()
    {
        switch (type)
        {
            case obstacleType.trombone:
                if (isActivated) 
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.025f, transform.position.z);
                }
                break;   
            default:
                break;
        }
    }

    public void IsActivated()
    {
        switch(type)
        {
            case obstacleType.scissor:
                transform.position = new Vector3(transform.position.x, transform.position.y + 2,  transform.position.z);
                break;
            case obstacleType.trombone:
                isActivated = true;
                break;
            default:
                break;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.swooshSFX);
            collision.transform.parent.transform.parent.GetComponent<LifeController>().SpeedChange(dmg);
        }
    }
}
