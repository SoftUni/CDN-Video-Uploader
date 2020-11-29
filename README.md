# CDN Video Uploader

A tool for **transcoding** and **uploading** videos to a CDN network for **HLS video streaming**.
  - **Input**: video file (AVI, MKV, MP4, WMV) @ 1080p (or higher) resolution
  - **Output**: video file converted to streamable MP4 video at several bitrates: 
    - MP4 @ `1080p` (~ 1100 mbps bitrate)
    - MP4 @ `720p` (~ 650 mbps bitrate)
    - MP4 @ `480p` (~ 400 kbps bitrate)
    - MP4 @ `360p` (~ 250 kbps bitrate)
    - MP4 @ `240p` (~ 150 kbps bitrate)
  - **Upload**: the files are uploaded through to FTP to the target CDN network

![CDN-Video-Uploader-screenshot](https://user-images.githubusercontent.com/1689586/99668721-c5ebbb00-2a76-11eb-8cd9-dfbfbd7ef9c4.png)

## Video Transcoding 

The tool uses internally [`ffmpeg`](https://ffmpeg.org) with the following default parameters:
```
1080p (1000-1200kbps)
ffmpeg.exe -i input.mkv  -c:v libx264 -s 1920x1080 -r 30 -x264opts keyint=60:no-scenecut -crf 25 -maxrate 1500k -bufsize 3000k  -c:a aac -b:a 192k  -y sample-1080p.mp4

720p (600-800 kbps)
ffmpeg.exe -i input.mkv  -c:v libx264 -s 1280x720 -r 30 -x264opts keyint=60:no-scenecut -crf 24 -maxrate 1000k -bufsize 2000k  -c:a aac -b:a 128k  -y sample-720p.mp4

480p (350-450 kbps)
ffmpeg.exe -i input.mkv  -c:v libx264 -s 854x480 -r 25 -x264opts keyint=50:no-scenecut -crf 23 -maxrate 600k -bufsize 1200k  -c:a aac -b:a 96k  -y sample-480p.mp4

360p (200-300 kbps)
ffmpeg.exe -i input.mkv  -c:v libx264 -s 640x360 -r 24 -x264opts keyint=48:no-scenecut -crf 24 -maxrate 400k -bufsize 800k  -c:a aac -b:a 64k  -y sample-360p.mp4

240p (100-200 kbps)
ffmpeg.exe -i input.mkv  -c:v libx264 -s 426x240 -r 24 -x264opts keyint=48:no-scenecut -crf 25 -maxrate 250k -bufsize 500k  -c:a aac -b:a 48k  -y sample-240p.mp4
```

## Hardware Accelerated Video Transcoding (NVidia)

These are the `ffmpeg` settings for similar results, using the hardware acccelerated video encoding:

```
1080p (1000-1200kbps)
ffmpeg.exe -i input.mp4  -c:v h264_nvenc -s 1920x1080 -r 30 -force_key_frames expr:gte(t,n_forced*2) -rc vbr -cq 36  -c:a aac -b:a 192k  -y sample-1080p.mp4

720p (600-800 kbps)
ffmpeg.exe -i input.mp4  -c:v h264_nvenc -s 1280x720 -r 30 -force_key_frames expr:gte(t,n_forced*2) -rc vbr -cq 35  -c:a aac -b:a 128k  -y sample-720p.mp4

480p (350-450 kbps)
ffmpeg.exe -i input.mp4  -c:v h264_nvenc -s 854x480 -r 25 -force_key_frames expr:gte(t,n_forced*2) -rc vbr -cq 33  -c:a aac -b:a 96k  -y sample-480p.mp4

360p (200-300 kbps)
ffmpeg.exe -i input.mp4  -c:v h264_nvenc -s 640x360 -r 24 -force_key_frames expr:gte(t,n_forced*2) -rc vbr_hq -cq 33   -c:a aac -b:a 64k  -y sample-360p.mp4

240p (100-200 kbps)
ffmpeg.exe -i input.mp4  -c:v h264_nvenc -s 426x240 -r 24 -force_key_frames expr:gte(t,n_forced*2) -rc vbr_hq -cq 35  -c:a aac -b:a 48k  -y sample-240p.mp4
```



The tool generates **HLS adaptable bitrate stream**, using the standard API from UCDN.
The generated URL looks like this:
```
https://11461-1.b.cdn12.com/hls/sample-,240,360,720,1080,p.mp4/urlset/master.m3u8
```

## Requirements
  - Windows OS with .NET Framework
  - `ffmpeg`, locally installed and configured in the system PATH
 
## Technology Stack
  - C#, Windows Forms, .NET Framework, Visual Studio

## Architecture Overview

Behind the Windows Forms based UI the project uses a queue of **jobs**, which hold a sequence of **actions**.
  - Both **jobs** and **actions** are designed to run **asynchronously** and implement a single interface `ExecutableAction`, which defines basic **operations** (like **start**, **update state** and **stop**), some **events** (state changed, error occured) and **execution state** (not started, running, completed suuccessfully, failed, canceled).
  - **Jobs** hold a sequence of actions (like "transcode to 720p", "FTP upload transcoded file" and others).
    - Jobs wait in the **"active jobs" queue**, then execute and when they finish (succeed, fail or cancel), they are moved to another **queue "completed jobs"**.
  - **Actions** hold a single task to be executed, such as "transcode an input file to certain profile (e.g. 720p)" or "upload video file to FTP".
    - Actions supported: `TranscodeAction` and `UploadActiion`

The **jobs scheduler** runs asynchronously and activates **once per second** to do the following:
  - **Update the state of each job**. This causes the jobs to internally update the states of their actions.
  - When an action is completed successfully, start the **next action** in the job.
  - When all actions in a job are completed suuccessfully (or certain action is failed or is canceled), move the job to the "completed jobs" queue.

