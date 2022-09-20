using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private Difficulty diff;

    [SerializeField]
    private Pool pool;

    [SerializeField]
    private Transform respawn;

    private GameObject mousetrap;
    private GameObject insect;

    private float requiredBetween;
    private float lastPosDown, lastPosUp;
    private float betweenDown, betweenUp;


    private int xPos;
    private float yPos;
    float speedZ;

    private float offset;


    private enum Lane
    {
        left = -10,
        center = 0,
        right = 10
    }
    private void Start()
    {
        betweenDown = diff.RequiredBetween;
    }
    private void LateUpdate()
    {

        requiredBetween = diff.RequiredBetween;
        speedZ = diff.SpeedZ;
        CreateDown();

        if (speedZ > 150f)
        {
            CreateUp();
        }
    }

    private void CreateDown()
    {
        if (betweenDown >= requiredBetween)
        {
            xPos = SelectLane();
            yPos = 2.5f;

            Vector3 respawnPos = new Vector3(xPos, yPos, respawn.position.z);


            mousetrap = pool.GetPooledObject("trap");
            mousetrap.transform.position = respawnPos;
            mousetrap.SetActive(true);

            lastPosDown = mousetrap.transform.position.z;
            betweenDown = respawn.position.z - lastPosDown;

        }

        else
        {
            lastPosDown = mousetrap.transform.position.z;
            betweenDown = respawn.position.z - lastPosDown;
        }

    }

    private void CreateUp()
    {

        if ((betweenUp >= requiredBetween) && (Random.Range(0, 50) == 0))
        {
            offset = Random.Range(0f, requiredBetween);
            xPos = SelectLane();
            yPos = 35f;
            Vector3 respawnPos = new Vector3(xPos, yPos, respawn.position.z + offset);

            insect = pool.GetPooledObject("insect");
            insect.transform.position = respawnPos;
            insect.SetActive(true);

            lastPosUp = insect.transform.position.z;
            betweenUp = respawn.position.z - lastPosUp;
        }
        else
        {
            if (insect != null) lastPosUp = insect.transform.position.z;
            betweenUp = respawn.position.z - lastPosUp;
        }

    }

    private int SelectLane()
    {
        var value = Random.Range(0, 3);
        if (value == 0) return -10;
        else if (value == 1) return 0;
        else return 10;
    }
}
