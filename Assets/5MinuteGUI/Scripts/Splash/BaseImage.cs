using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseImage : MonoBehaviour {
	public float playWaitTime = 1;
	public float hideWaitTime = 1;
	protected Image m_image;

	public AudioClip onPlayAC;
	public AudioClip onHideAC;

	public enum FadeType{
		SPLASH,
		FADE
	};
	public FadeType fadeType;

	public GameObject go;
	private Animator  m_animator;

	public bool playOnStart=true;
	
	public Color startColor = Color.black;
	public Color endColor = Color.clear;
	public float fadeTime = 1;
	
	public float fillStart = 0;
	public float fillEnd = 1f;
	
	private float m_fadeTime = 0; 
	public Image image;
	private bool m_on =false;


	public void Awake()
	{
		m_fadeTime = fadeTime;
		if(playOnStart && fadeType == FadeType.SPLASH)
		{
			fadePlay();
		}
		m_image = gameObject.GetComponent<Image>();
		if(go){
			m_animator = go.GetComponent<Animator>();
		}
	}
	public void Update()
	{
		if(fadeType==FadeType.FADE)
		{
			handleFadeUpdate();
		}
	}
	public void handleFadeUpdate()
	{
		if(image==null)
		{
			return;
		}
		
		if(m_on)
		{
			m_fadeTime += Time.deltaTime;
			float val = m_fadeTime / fadeTime;
			
			
			image.color = Color.Lerp(startColor,endColor,val);
			image.fillAmount = Mathf.Lerp(fillStart,fillEnd,val);
			
			if(val>=1)
			{
				
				m_on = false;
			}
		}
	}

	public void splashPlay()
	{
		if(m_image)
		{
			m_image.enabled=true;
		}
		if(m_animator)
		{
			m_animator.enabled=true;
			m_animator.SetBool("SlideOut",true);
		}
	}
	public void splashHide()
	{
		if(m_animator)
			m_animator.SetBool("SlideOut",false);
	}
	public void fadePlay()
	{
		m_on=true;
		m_fadeTime = 0;
		if(image)
			image.color = startColor;
	}
	public virtual float play()
	{
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().PlayOneShot(onPlayAC);
		}

		if(m_image)
		{
			m_image.enabled=true;
		}

		if(fadeType==FadeType.SPLASH)
		{
			splashPlay();
		}
		else{
			fadePlay();
		}
		return  playWaitTime;
	}
	
	public virtual float hide()
	{
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().PlayOneShot(onHideAC);
		}
		if(fadeType==FadeType.SPLASH)
		{
			splashHide();
		}
		return hideWaitTime;
	}


}
