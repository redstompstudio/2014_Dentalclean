using UnityEngine;
using System.Collections;

public class TweenImageAlpha : UITweener 
{
	[Range(0f, 1f)] public float from = 1f;
	[Range(0f, 1f)] public float to = 1f;
	
	bool mCached = false;
	Material mMat;
	UnityEngine.UI.Image image;
	
	[System.Obsolete("Use 'value' instead")]
	public float alpha { get { return this.value; } set { this.value = value; } }
	
	void Cache ()
	{
		mCached = true;
		image = GetComponent<UnityEngine.UI.Image>();

		if(image != null)
		{
			mMat = image.material;
		}
	}
	
	/// <summary>
	/// Tween's current value.
	/// </summary>
	public float value
	{
		get
		{
			if (!mCached) 
				Cache();

			if(image != null)
				return image.color.a;

			return mMat != null ? mMat.color.a : 1f;
		}
		set
		{
			if (!mCached) 
				Cache();
		
			if(image != null)
			{
				Color c = image.color;
				c.a = value;
				image.color = c;
			}
			else if(mMat != null)
			{
				Color c = mMat.color;
				c.a = value;
				mMat.color = c;
			}
		}
	}
	
	/// <summary>
	/// Tween the value.
	/// </summary>
	
	protected override void OnUpdate (float factor, bool isFinished) 
	{ 
		value = Mathf.Lerp(from, to, factor); 
	}
	
	/// <summary>
	/// Start the tweening operation.
	/// </summary>
	
	static public TweenImageAlpha Begin (GameObject go, float duration, float alpha)
	{
		TweenImageAlpha comp = UITweener.Begin<TweenImageAlpha>(go, duration);
		comp.from = comp.value;
		comp.to = alpha;
		
		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	public override void SetStartToCurrentValue () { from = value; }
	public override void SetEndToCurrentValue () { to = value; }
}
