# Unity-Emotiv-Marker
Unity script for sending marker stream to Emotiv

1. Open Unity project (ver 2020~)
    1. project settings > XR plugin management 
        
        ![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/060e1acc-9ed7-4540-b6ac-15d2a33aa80d/9965e06e-1e1e-497a-9f46-0c4d970a069d/Untitled.png)
        
2. Install LSL package (https://github.com/labstreaminglayer/LSL4Unity)

Open the Package Manager Window, click on the `+` dropdown, and [choose `Add package from git URL...`](https://docs.unity3d.com/Manual/upm-ui-giturl.html). Enter the followingURL:   
    `https://github.com/labstreaminglayer/LSL4Unity.git`

3. In instances where marker is needed, use this function.

'''
// assign markerNum (e.g. 200 for trial onset)
markerNum = 300;
this.GetComponent<MarkerSender>().SendMarker(markerNum, epochNow);
'''
