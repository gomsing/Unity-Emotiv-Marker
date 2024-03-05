# Unity-Emotiv-Marker
Unity script for sending marker stream to Emotiv


## 1. Install LSL package (https://github.com/labstreaminglayer/LSL4Unity)

    Open the Package Manager Window, click on the `+` dropdown, and [choose `Add package from git URL...`](https://docs.unity3d.com/Manual/upm-ui-giturl.html). Enter the followingURL:   
        `https://github.com/labstreaminglayer/LSL4Unity.git`

## 2. In instances where marker is needed, use this function.

```
// assign markerNum (e.g. 200 for trial onset)
markerNum = 300;
this.GetComponent<MarkerSender>().SendMarker(markerNum, epochNow);
```
