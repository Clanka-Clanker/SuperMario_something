using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{

    [SerializeField] private float projectileFireRate;

    private float timeSinceLastFire = 0;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (projectileFireRate <= 0)
            projectileFireRate = 2;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);

        float distance = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.Find("Turret").transform.position);

        if (curPlayingClips[0].clip.name.Contains("Idle"))
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate && distance <= 4.0f)
            {
                anim.SetTrigger("Fire   ");
                timeSinceLastFire = Time.time;
            }
        }

        if (GameObject.Find("Player").transform.position.x < GameObject.Find("Turret").transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
