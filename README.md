# CDN Video Transcoder & Uploader Tool

A tool for **transcoding** and **uploading** videos to a CDN network for **HLS video streaming**.
  - **Input**: video file (AVI, MKV, MP4, WMV) @ 1080p (or higher) resolution
  - **Output**: video file converted to streamable MP4 video at several bitrates: 
    - MP4 @ `1080p` (~ 1100 kbps bitrate)
    - MP4 @ `720p` (~ 650 kbps bitrate)
    - MP4 @ `480p` (~ 400 kbps bitrate)
    - MP4 @ `360p` (~ 250 kbps bitrate)
    - MP4 @ `240p` (~ 150 kbps bitrate)
  - **Upload**: the files are uploaded through to FTP to the target CDN network

![CDN-Video-Uploader-screenshot](https://user-images.githubusercontent.com/1689586/102526744-cfcc0280-40a4-11eb-8a0c-0d3777e1b5a4.png)

## Video Transcoding (Software, CPU-based, using libx264)

The tool uses internally [`ffmpeg`](https://ffmpeg.org) with the following default parameters for VoD streaming:
```
1080p (1000-1200kbps)
ffmpeg.exe  -i input.mp4  -c:v libx264 -s 1920x1080 -r 30 -g 60 -crf 25 -maxrate 1500k -bufsize 3000k  -c:a aac -b:a 192k  -y sample-1080p.mp4

720p (600-800 kbps)
ffmpeg.exe  -i input.mp4  -c:v libx264 -s 1280x720 -r 30 -g 60 -crf 24 -maxrate 1000k -bufsize 2000k  -c:a aac -b:a 128k  -y sample-720p.mp4

480p (350-450 kbps)
ffmpeg.exe  -i input.mp4  -c:v libx264 -s 854x480 -r 25 -g 50 -crf 23 -maxrate 600k -bufsize 1200k  -c:a aac -b:a 96k  -y sample-480p.mp4

360p (200-300 kbps)
ffmpeg.exe  -i input.mp4  -c:v libx264 -s 640x360 -r 24 -g 48 -crf 24 -maxrate 400k -bufsize 800k  -c:a aac -b:a 64k  -y sample-360p.mp4

240p (100-200 kbps)
ffmpeg.exe  -i input.mp4  -c:v libx264 -s 426x240 -r 15 -g 30 -crf 25 -maxrate 250k -bufsize 500k  -c:a aac -b:a 48k  -y sample-240p.mp4
```

Notes:
  - The above commands use CPU-based transcoding (using the `libx264` CPU encoder) --> it is slow
  - Frames per second (fps): 30 fps for hi-res streams; 15-25 fps for low-res streams
  - The audio is also resampled: 128-192 kbps for his-res streams; 48-96 kbps for low-res streams

Links:
 - https://slhck.info/video/2017/03/01/rate-control.html
 - https://developers.google.com/media/vp9/settings/vod

## Hardware Accelerated Video Transcoding (NVidia NVENC)

These are the `ffmpeg` settings to achieve similar results (for less encoding time), using the **NVENC hardware accelerated video encoding** (NVidia GPU):

```
1080p (1000-1200kbps)
ffmpeg.exe  -c:v h264_cuvid -resize 1920x1080 -i input.mp4  -c:v h264_nvenc -r 30 -g 60 -rc vbr -cq 34  -c:a aac -b:a 192k  -y sample-1080p.mp4

720p (600-800 kbps)
ffmpeg.exe  -c:v h264_cuvid -resize 1280x720 -i input.mp4  -c:v h264_nvenc -r 30 -g 60 -rc vbr -multipass fullres -cq 34  -c:a aac -b:a 128k  -y sample-720p.mp4

480p (350-450 kbps)
ffmpeg.exe  -c:v h264_cuvid -resize 854x480 -i input.mp4  -c:v h264_nvenc -r 25 -g 50 -rc vbr -multipass fullres -cq 32  -c:a aac -b:a 96k  -y sample-480p.mp4

360p (200-300 kbps)
ffmpeg.exe  -c:v h264_cuvid -resize 854x480 -i input.mp4  -c:v h264_nvenc -r 24 -g 48 -rc vbr -multipass fullres -cq 37   -c:a aac -b:a 64k  -y sample-360p.mp4

240p (100-200 kbps)
ffmpeg.exe  -c:v h264_cuvid -resize 426x240 -i input.mp4  -c:v h264_nvenc -r 15 -g 30 -rc vbr -multipass fullres -cq 32  -c:a aac -b:a 48k  -y sample-240p.mp4
```

Notes:
  - Multipass for 1080p is intentionally swiched off, because it slows down the transcoding speed by 45%, with almost no visible improvement
  - These commands are designed to run in Windows machine, with NVidia graphics card, which supports video encode / decode
  - Require the latest NVidia drivers
  - Require the latest `ffmpeg` for Windows (from Nov 2020 or later)
  - Choose the encoder / decoder GPU by: `-gpu 0` / `-gpu 1` / `-gpu 2` (if you have multiple GPU)
  
Tested with `ffmpeg version 2020-11-29-git-f194cedfe6-full_build-www.gyan.dev`:
 - https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-2020-11-29-git-f194cedfe6-full_build.7z

Links:
  - https://developer.nvidia.com/blog/nvidia-ffmpeg-transcoding-guide/
  - https://docs.nvidia.com/video-technologies/video-codec-sdk/ffmpeg-with-nvidia-gpu/
  - https://gist.github.com/nakov/63375816c9d3201c499b15b110ca6136

### Video Cards for Hardware Transcoding
This list describes the **performance of NVidea video cards for video encoding** (NVENC / NVDEC):
 - https://www.elpamsoft.com/?p=Plex-Hardware-Transcoding
 
### The Max NVENC Sessions Limit
NVidia drivers apply an internal software-based **limitation on the maximum number of NVENC video encoding sessions** (how many files can be encoded in simultaneously with `ffmpeg`).

To remove the NVENC sessions restriction, you can use the **NVENC patch** tool for the NVidia video drivers (on your own risk): https://github.com/keylase/nvidia-patch/tree/master/win.

## Hardware Accelerated Video Transcoding for Intel Quick Sync (QVC) GPU

If you have **Intel video card (GPU)**, which is usually built in most Intel processors, you can use it for hardware-accelerated video transcoding (with Intel Quick Sync). Example of using Intel GPU transcoder, with variable bitrate, limited by quality (recommended):
```
ffmpeg.exe  -c:v h264_qsv -i input.mp4   -c:v h264_qsv -s 426x240 -r 24 -global_quality 28 -look_ahead 1   -c:a aac -b:a 48k  -y output-240p.mp4
```

CPU-based decoder + Intel GPU-based encoder:
```
ffmpeg.exe  -i input.mp4   -c:v h264_qsv -s 426x240 -r 24 -global_quality 28 -look_ahead 1   -c:a aac -b:a 48k  -y output-240p.mp4
```

Intel GPU encoder + decoder, limited by bitrate:
```
ffmpeg.exe -c:v h264_qsv -i input.mp4  -c:v h264_qsv -s 426x240 -r 24 -g 48 -b:v 200k -maxrate 250k -bufsize 500k  -c:a aac -b:a 48k  -y output-240p.mp4
```

## Combining Multiple GPU + CPU for faster Transcoding

This example demonstrates how to **combine 2 NVidia GPUs + 1 Intel GPU + 1 Intel CPU**, which are available on a single machine with Intel CPU + built-in Intel GPU + 2 additional NVidia video cards. These are the transcoding seettings for the CDN Video Uploader for 1080p, 720p, 480p and 240p:
```
1080p | ffmpeg.exe  -c:v h264_cuvid -gpu 0 -resize 1920x1080 -i {input} -c:v h264_nvenc -gpu 0 -r 30 -g 60 -rc vbr -cq 34  -c:a aac -b:a 192k  -y {output}
720p | ffmpeg.exe  -c:v h264_cuvid -gpu 1 -resize 1280x720 -i {input}  -c:v h264_nvenc -gpu 1 -r 30 -g 60 -rc vbr -multipass fullres -cq 34  -c:a aac -b:a 128k  -y {output}
480p | ffmpeg.exe  -c:v h264_cuvid -gpu 0 -resize 854x480 -i {input}  -c:v h264_nvenc -gpu 0 -r 25 -g 50 -rc vbr -multipass fullres -cq 32  -c:a aac -b:a 96k  -y {output}
240p | ffmpeg.exe  -i {input}   -c:v h264_qsv -s 426x240 -r 15 -global_quality 28 -look_ahead 1   -c:a aac -b:a 48k   -y {output}
```

## HLS Stream on UCDN

The tool generates **HLS adaptable bitrate stream**, using the standard API from UCDN.
The generated URL looks like this:
```
https://11461-1.b.cdn12.com/hls/sample-,240,360,720,1080,p.mp4/urlset/master.m3u8
```

## Requirements
  - Windows OS with .NET Framework
  - `ffmpeg`, locally installed and configured in the system PATH
  - NVidia graphics card + latest drivers (if you use hardware encoding)
 
## Technology Stack
  - C#, Windows Forms, .NET Framework, Visual Studio

## Architecture Overview

Behind the Windows Forms based UI the project uses a queue of **jobs**, which hold a sequence of **actions**.
  - Both **jobs** and **actions** are designed to run **asynchronously** and implement a single interface `ExecutableAction`, which defines basic **operations** (like **start**, **update state** and **stop**), some **events** (state changed, error occured) and **execution state** (not started, running, completed suuccessfully, failed, canceled).
  - **Jobs** hold a sequence of actions (like "transcode to 720p", "FTP upload transcoded file" and others).
    - Jobs wait in the **"active jobs" queue**, then execute and when they finish (succeed, fail or cancel), they are moved to another **queue "completed jobs"**.
  - **Actions** hold a single task to be executed, such as "transcode an input file to certain profile (e.g. 720p)" or "upload video file to FTP".
    - Actions supported: `TranscodeAction` and `UploadAction`

The **jobs scheduler** runs asynchronously and activates **once per second** to do the following:
  - **Update the state of each job**. This causes the jobs to internally update the states of their actions.
  - When an action is completed successfully, start the **next action** in the job.
  - When all actions in a job are completed suuccessfully (or certain action is failed or is canceled), move the job to the "completed jobs" queue.

