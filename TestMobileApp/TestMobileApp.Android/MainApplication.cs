using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using System;

namespace TestMobileApp.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handler, JniHandleOwnership transer) : base(handler, transer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
        void IActivityLifecycleCallbacks.OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        void IActivityLifecycleCallbacks.OnActivityDestroyed(Activity activity)
        {
            throw new System.NotImplementedException();
        }

        void IActivityLifecycleCallbacks.OnActivityPaused(Activity activity)
        {
            throw new System.NotImplementedException();
        }

        void IActivityLifecycleCallbacks.OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        void IActivityLifecycleCallbacks.OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            throw new System.NotImplementedException();
        }

        void IActivityLifecycleCallbacks.OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        void IActivityLifecycleCallbacks.OnActivityStopped(Activity activity)
        {
            throw new System.NotImplementedException();
        }
    }
}