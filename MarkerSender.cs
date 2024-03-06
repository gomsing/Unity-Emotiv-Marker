using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class MarkerSender : MonoBehaviour
{
    private static string currentScene;
    private LSL.StreamInfo markerStreamInfo;
    private LSL.StreamOutlet markerOutlet;

    public int lslChannelCount = 3;

    private const LSL.channel_format_t lslChannelFormat = LSL.channel_format_t.cf_double64;

    private double[] sample;

    public double epochNow; 
    

    void Start()
    {


        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        
        Data_txt();

        // Create a marker stream info
        markerStreamInfo = new LSL.StreamInfo("ExpMarkerStream", "Markers", lslChannelCount, 0, 
                                                lslChannelFormat, "UnityLSL001");

        LSL.XMLElement chns = markerStreamInfo.desc().append_child("channels");
            string[] channels = {"MarkerTime", "MarkerValue", "CurrentTime"};
            foreach(string chanName in channels) {
                chns.append_child("channel").append_child_value("label", chanName).append_child_value("type", "Marker");
            }
        
        // Create a marker stream outlet
        markerOutlet = new LSL.StreamOutlet(markerStreamInfo);
        Debug.Log("Marker stream created.");
    }

    public void SendMarker(int markerNum, double epochNow)
    {
        sample = new double[lslChannelCount];

        if (markerOutlet != null)
        {
            // Send the marker using the outlet
            
            //epochNow = (double)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000;
            sample[0] = epochNow;
            sample[1] = markerNum;
            sample[2] = epochNow;
            markerOutlet.push_sample(sample);
            Debug.Log(string.Join(", ", sample));

            string value = 
                string.Join(", ", sample) +
                Environment.NewLine;

            File.AppendAllText(currentScene+ "_" + "marker.csv", value);

        }
        else
        {
            Debug.LogWarning("Marker outlet is not initialized.");
        }
    }

    void Data_txt()
    {
        string variable = 
        "MarkerTime" + "," +
        "MarkerValue" + "," +
        "CurrentTime" +  
        Environment.NewLine;

        File.AppendAllText(currentScene+ "_" + "marker.csv", variable);

    }
}

