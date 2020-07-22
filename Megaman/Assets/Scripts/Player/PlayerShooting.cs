using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
	public Slider pwslider;
	public Image PWicon;
	public Image PWFlash;
	public float flashSpeed = 1f;
	public Color PWFlashColor = new Color(1f, 0f, 0f, 0.1f);
	public Color PWiconColor = new Color(1f, 0f, 0f, 0.1f);
	public AudioClip powerUpClip;

	AudioSource playerAudio;
	private float initialTimeBetweenBullets;
	private float PWtimeBetweenBullets;
	private Color InitialPWiconColor = new Color(1f, 0f, 0f, 0.1f);
	private float pw = 0f;
	float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
	Animator animator;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
	private Camera cam;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.15f);
	private SkinnedMeshRenderer headUpgrade;
	private SkinnedMeshRenderer armorUpgrade;
	private SkinnedMeshRenderer rarmUpgrade;
	private SkinnedMeshRenderer larmUpgrade;
	private SkinnedMeshRenderer legUpgrade;
	private SkinnedMeshRenderer head;
	private SkinnedMeshRenderer armor;
	private SkinnedMeshRenderer rarm;
	private SkinnedMeshRenderer larm;
	private SkinnedMeshRenderer leg;
	private bool isPW;

    void Awake ()
    {
		playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent <AudioSource> ();
		InitialPWiconColor = PWicon.color;
		shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
		cam = GameObject.FindWithTag("Cam").GetComponent<Camera>();
		animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
		pwslider.value = pw;
		headUpgrade = GameObject.FindGameObjectWithTag("HeadUpgrade").GetComponent<SkinnedMeshRenderer>();
		armorUpgrade = GameObject.FindGameObjectWithTag("ArmorUpgrade").GetComponent<SkinnedMeshRenderer>();
		rarmUpgrade = GameObject.FindGameObjectWithTag("RarmUpgrade").GetComponent<SkinnedMeshRenderer>();
		larmUpgrade = GameObject.FindGameObjectWithTag("LarmUpgrade").GetComponent<SkinnedMeshRenderer>();
		legUpgrade = GameObject.FindGameObjectWithTag("legUpgrade").GetComponent<SkinnedMeshRenderer>();
		head = GameObject.FindGameObjectWithTag("Head").GetComponent<SkinnedMeshRenderer>();
		armor = GameObject.FindGameObjectWithTag("Armor").GetComponent<SkinnedMeshRenderer>();
		rarm = GameObject.FindGameObjectWithTag("Rarm").GetComponent<SkinnedMeshRenderer>();
		larm = GameObject.FindGameObjectWithTag("Larm").GetComponent<SkinnedMeshRenderer>();
		leg = GameObject.FindGameObjectWithTag("leg").GetComponent<SkinnedMeshRenderer>();
		isPW = false;
		initialTimeBetweenBullets = timeBetweenBullets;
		PWtimeBetweenBullets = timeBetweenBullets / 2;
    }


    void Update ()
    {
        timer += Time.deltaTime;
		pwslider.value = pw;
		PWFlash.color = Color.Lerp (PWFlash.color, Color.clear, flashSpeed * Time.deltaTime);
		if(pwslider.value >= pwslider.maxValue)
		{
			PWicon.color = PWiconColor;
		}
		else
		{
			PWicon.color = InitialPWiconColor;
		}
		if(pwslider.value == pwslider.minValue && isPW == true)
		{
			headUpgrade.enabled = false;
			rarmUpgrade.enabled = false;
			larmUpgrade.enabled = false;
			armorUpgrade.enabled = false;
			legUpgrade.enabled = false;
			head.enabled = true;
			rarm.enabled = true;
			larm.enabled = true;
			armor.enabled = true;
			leg.enabled = true;
			isPW = false;
			timeBetweenBullets = initialTimeBetweenBullets;
			PWFlash.color = PWFlashColor;
		}
		if(Input.GetButtonDown("PowerUp") && pwslider.value >= pwslider.maxValue)
		{
			headUpgrade.enabled = true;
			rarmUpgrade.enabled = true;
			larmUpgrade.enabled = true;
			armorUpgrade.enabled = true;
			legUpgrade.enabled = true;
			head.enabled = false;
			rarm.enabled = false;
			larm.enabled = false;
			armor.enabled = false;
			leg.enabled = false;
			isPW = true;
			timeBetweenBullets = PWtimeBetweenBullets;
			PWFlash.color = PWFlashColor;
			playerAudio.clip = powerUpClip;
			playerAudio.Play ();
		}
		if(isPW == true)
		{
			pw -= 0.05f;
		}
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
			animator.SetBool("isFiring",true);
			timer = 0f;
			StartCoroutine (PlayerShoot());
        }
		else
		{
			animator.SetBool("isFiring",false);
		}

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

	private IEnumerator PlayerShoot()
	{
		yield return shotDuration;



		gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

		gunLine.enabled = true;
		gunAudio.Play();

		gunLine.SetPosition (0, transform.position);

		Vector3 rayOrigin = cam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

		shootRay.origin = rayOrigin;
		shootRay.direction = cam.transform.forward;

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
				if(enemyHealth.currentHealth != 0f && isPW == false && pw <= pwslider.maxValue)
				{
					pw += 1f;
				}
			}
			gunLine.SetPosition (1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}

}
