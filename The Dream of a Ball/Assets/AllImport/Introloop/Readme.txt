*** Introloop v2.0 ***
/* 
/// Copyright (c) 2015 Sirawat Pitaksarit, Exceed7 Experiments LP 
/// http://www.exceed7.com/introloop
*/

=== What did it install ===
Assets/Introloop
Assets/Resources/Introloop

=== How to use Introloop ===
With internet connection you shoud visit : http://www.exceed7.com/introloop

Without internet connection, here are brief instructions!

1. Right click your AudioClip asset you want to play Introloop style, select Introloop > Create IntroloopAudio
2. Set appropriate boundaries. When playhead reaches Looping Boundary, it will return to Intro Boundary.
3. Uncheck "Preload Audio Data" on your original AudioClip recommended.
4. Create something like "public IntroloopAudio myIntroloopAudio;" in your script.
5. Drag your newly created IntroloopAudio asset file to the inspector slot.
6. In the script call IntroloopPlayer.Instance.Play(myIntroloopAudio) to play. There are Stop, Pause and Resume also.
7. (Extra) Setup mixer routing and other settings in a "template prefab" file located in Assets/Resources/Introloop/

Questions/Problems/Suggestions : 5argon@exceed7.com

== Release Note ==

(14/04/2017) Version 2.0 - New functions includes :

Pitch - You can now specify pitch in an IntroloopAudio asset file. If you would like to use multiple pitches of the same audio, you can just copy the asset file and have different pitches. It can reference to the same actual audio file. Works fine with pause, resume, automatic memory management.

Preload - A feature where critical precision of starting an Introloop Audio is needed. Load the audio by calling IntroloopAudio.Instance.Preload(yourIntroloopAudio) beforehand to pre-consume memory, and then call Play as usual afterwards.

Ogg Streaming as Introloop on iOS/Android - In Unity 5.5.2 they added support for choosing "Streaming" with OGG on iOS/Android. I am happy to inform that this option works with Introloop. Everthing will be the same except it will not cost you as much memory of an entire audio on Play as before in an exchange for some CPU workload.

(15/12/2015) Version 1.0 - The first version