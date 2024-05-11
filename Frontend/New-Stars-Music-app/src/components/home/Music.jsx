import React, { useEffect, useState } from "react";
import Player from "@madzadev/audio-player";
import "@madzadev/audio-player/dist/index.css";

const tracks = [
  {
    url: "https://audioplayer.madza.dev/Madza-Chords_of_Life.mp3",
    title: "Madza - Chords of Life",
    tags: ["house"],
  },
  {
    url: "https://audioplayer.madza.dev/Madza-Late_Night_Drive.mp3",
    title: "Madza - Late Night Drive",
    tags: ["dnb"],
  },
  {
    url: "https://audioplayer.madza.dev/Madza-Persistence.mp3",
    title: "Madza - Persistence",
    tags: ["dubstep"],
  },
];
const colors = {
  tagsBackground: "#57534e",
  tagsText: "#ffffff",
  tagsBackgroundHoverActive: "#6e65f1",
  tagsTextHoverActive: "#ffffff",
  searchBackground: "#57534e",
  searchText: "#ffffff",
  searchPlaceHolder: "#575a77",
  playerBackground: "#57534e",
  titleColor: "#ffffff",
  timeColor: "#ffffff",
  progressSlider: "#ff8f0f",
  progressUsed: "#ffffff",
  progressLeft: "#151616",
  bufferLoaded: "#1f212b",
  volumeSlider: "#ff8f0f",
  volumeUsed: "#ffffff",
  volumeLeft: "#151616",
  playlistBackground: "#57534e",
  playlistText: "#737373",
  playlistBackgroundHoverActive: "#18191f",
  playlistTextHoverActive: "#ffffff",
};

const Music = () => {
  const [music, setMusic] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const url =
          "https://spotify23.p.rapidapi.com/recommendations/?limit=20&seed_tracks=0c6xIDDpzE81m2q797ordA&seed_artists=4NHQUGzhtTLFvgF5SZesLK&seed_genres=rock";
        const options = {
          method: "GET",
          headers: {
            "X-RapidAPI-Key":
              "f01df68517mshdbe3f29cad6aa80p12a68bjsnc9f078de4e26",
            "X-RapidAPI-Host": "spotify23.p.rapidapi.com",
          },
        };

        const response = await fetch(url, options);
        const result = await response.json();
        setMusic(result);
        console.log(music);
      } catch (error) {
        console.error(error);
      }
    };

    fetchData(); // Call the function here
  }, []);

  return (
    <div>
      <Player
        trackList={tracks}
        includeTags={false}
        includeSearch={false}
        showPlaylist={true}
        sortTracks={true}
        autoPlayNextTrack={true}
        customColorScheme={colors}
      />
    </div>
  );
};

export default Music;
