# CDN Video Uploader

A tool for **transcoding** and **uploading** videos to a CDN network for **HLS video streaming**.
  - **Input**: video file (AVI, MKV, MP4, WMV) @ 1080p resolution
  - **Output**: video file converted to streamable MP4 video at several bitrates: 
    - MP4 @ `1080p` (~ 5 mbps bitrate, original)
    - MP4 @ `720p` (~ 2 mbps bitrate)
    - MP4 @ `480p` (~ 1 mbps bitrate)
    - MP4 @ `240p` (~ 0.5 mbps bitrate)
  - **Upload**: the files are uploaded through to FTP to the target CDN network

The tool uses internally [`ffmpeg`](https://ffmpeg.org):
```
ffmpeg.exe -i input.mkv -vcodec libx264 -crf 27 -preset veryfast -c:a copy -s 1920x1080 sample-1080p.mp4
ffmpeg.exe -i input.mkv -vcodec libx264 -crf 27 -preset veryfast -c:a copy -s 1280x720 sample-720p.mp4
ffmpeg.exe -i input.mkv -vcodec libx264 -crf 27 -preset veryfast -c:a copy -s 854x480 sample-480p.mp4
ffmpeg.exe -i input.mkv -vcodec libx264 -crf 27 -preset veryfast -c:a copy -s 426x240 sample-240p.mp4
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

