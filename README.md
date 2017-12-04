# twitterStreamFaceDetection
In this project, I have used Tweetinvi, SignalR, Microsoft.ProjectOxford.Face and hangfire packages to achieve the goal of the assignment.


By receiving a keyword from the user a background task(Hangfire) will use the Tweetinvi to listen to the stream of the twitter and tweets will be stored in the database. In parallel, another task will try to detect the faces in the images of the stored tweets, with Microsoft face detection API(Microsoft.ProjectOxford.Face). The detected faces will be sent to the UI using Microsoft SsignalR.



Also, an Ajax request will be executed from the UI every 10 seconds to show the average of tweets, male faces, and female faces.



Because of the request limitations of this service only 10 images will be sent to be detected each minute. So the average number of genders in the picture will not change fast enough.



One of the goals of the assignment was to let the user change the keyword on the fly. Although I have worked on this as well and handled it from different layers, still I was not able to remove the background tasks of Hangfire package, for the previous keyword. So changing the keyword will cause the application to run in an unstable state.
