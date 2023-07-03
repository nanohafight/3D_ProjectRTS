using UnityEngine;

[CreateAssetMenu(fileName = "MultiShot", menuName = "Skill/MultiShot")]
public class MultiShot : Skill
{
    [Space]
    [Header("Shoot Skill Setting")]
    public int arrows;
    public float speed;
    Vector3 direction;
    public GameObject arrowPrefabs;
    public override void Execute(Vector3 targetPos)
    {
        Debug.Log("TargetPos : " + targetPos);
        Vector3 shootPos = new Vector3(user.transform.position.x, 0.5f, user.transform.position.z);

        direction = new Vector3(targetPos.x - user.transform.position.x, 0f, targetPos.z - user.transform.position.z);
        Debug.Log("Direction : " + direction);
        
        //todo  SkillUser에서 공격모션 구현해서 사용해주세요
        for (int i = 0; i < arrows; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject arrow = Instantiate(arrowPrefabs, shootPos + user.transform.forward, Quaternion.LookRotation(direction));
                    arrow.GetComponent<ArcherArrow>().Init(speed); Destroy(arrow, range); break;
                case 1:
                    GameObject arrow1 = Instantiate(arrowPrefabs, shootPos + user.transform.forward, Quaternion.LookRotation(direction));
                    arrow1.GetComponent<ArcherArrow>().Init(speed); Destroy(arrow1, range); break;
                case 2:
                    GameObject arrow2 = Instantiate(arrowPrefabs, shootPos + user.transform.forward, Quaternion.LookRotation(direction));
                    arrow2.GetComponent<ArcherArrow>().Init(speed); Destroy(arrow2, range); break;
                default:
                    break;
            }
        }
    }
}