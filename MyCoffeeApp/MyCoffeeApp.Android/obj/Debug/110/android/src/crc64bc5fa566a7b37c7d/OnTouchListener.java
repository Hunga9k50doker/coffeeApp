package crc64bc5fa566a7b37c7d;


public class OnTouchListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Com.Syncfusion.Rotator.OnTouchListener, Syncfusion.SfRotator.Android", OnTouchListener.class, __md_methods);
	}


	public OnTouchListener ()
	{
		super ();
		if (getClass () == OnTouchListener.class) {
			mono.android.TypeManager.Activate ("Com.Syncfusion.Rotator.OnTouchListener, Syncfusion.SfRotator.Android", "", this, new java.lang.Object[] {  });
		}
	}

	public OnTouchListener (android.content.Context p0, crc64bc5fa566a7b37c7d.SfRotator p1)
	{
		super ();
		if (getClass () == OnTouchListener.class) {
			mono.android.TypeManager.Activate ("Com.Syncfusion.Rotator.OnTouchListener, Syncfusion.SfRotator.Android", "Android.Content.Context, Mono.Android:Com.Syncfusion.Rotator.SfRotator, Syncfusion.SfRotator.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
