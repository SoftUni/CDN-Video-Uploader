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
ffmpeg.exe -i input.mkv -c copy sample-1080p.mp4
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
