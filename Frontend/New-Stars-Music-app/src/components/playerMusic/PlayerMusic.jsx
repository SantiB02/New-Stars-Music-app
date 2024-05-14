import React, { useState } from "react";
import NavBar from "../NavBar";
import Footer from "../Footer";
import MessagePlayer from "./MessagePlayer";

const PlayerMusic = () => {
  const [song, setSong] = useState("");
  const [tracks, setTracks] = useState([]);

  const handleSearch = (e) => {
    e.preventDefault();
    if (song.trim() === "") {
      alert("ingresa algo porfavor");
      return;
    }
    console.log(song);
    setSong("");
    getSong(song);
  };
  const options = {
    method: "GET",
    headers: {
      "X-RapidAPI-Key": "f01df68517mshdbe3f29cad6aa80p12a68bjsnc9f078de4e26",
      "X-RapidAPI-Host": "spotify23.p.rapidapi.com",
    },
  };
  async function getSong(song) {
    try {
      const url = `https://spotify23.p.rapidapi.com/search/?q=${song}&type=multi&offset=0&limit=12&numberOfTopResults=5`;
      const data = await fetch(url, options);
      const response = await data.json();
      setTracks(response.tracks.items);
      console.log(response.tracks.items);
    } catch (error) {
      console.log(`ups..error: ${error}`);
    }
  }

  return (
    <div className="flex flex-col min-h-screen">
      <NavBar />
      <div className="flex justify-center flex-grow">
        <div className="search-container">
          <div>
          <h1 className="uppercase text-center ">Start exploring now!
          <br/>Dive into the music right away!</h1>
          </div>
          <form onSubmit={handleSearch}>
            <input
              placeholder="Search..."
              className="bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
              type="text"
              value={song}
              onChange={(e) => setSong(e.target.value)}
            />
            <button
              type="submit"
              className="bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
            >
              Search
            </button>
          </form>
        </div>
      </div>
      <div>
        {tracks.length > 0 ? (
          <div className="flex flex-wrap mt-4 ">
            {tracks.map((song, index) => (
              <div
                className="card w-full md:w-1/2 lg:w-1/3 p-4 text-center"
                key={index}
              >
                <a href="#" className="group relative block bg-black">
                  <img
                    alt=""
                    src={song.data.albumOfTrack.coverArt.sources[0].url}
                    className="absolute inset-0 h-full w-full object-cover opacity-75 transition-opacity group-hover:opacity-50"
                  />
                  <div className="relative p-4 sm:p-6 lg:p-8">
                    <p className="text-sm font-medium uppercase tracking-widest text-fourth">
                      {" "}
                      {song.data.artists.items[0].profile.name}{" "}
                    </p>
                    <p className="text-xl font-bold text-white sm:text-2xl">
                      {" "}
                      {song.data.name}{" "}
                    </p>
                    <div className="mt-32 sm:mt-48 lg:mt-64">
                      <div className="translate-y-8 transform opacity-0 transition-all group-hover:translate-y-0 group-hover:opacity-100">
                        <p className="text-sm text-white">
                          {" "}
                          do you want to hear it? click here 👇{" "}
                        </p>
                        <a href={song.data.uri}>
                          <button className="text-zinc-700 hover:text-zinc-200 backdrop-blur-lg bg-gradient-to-tr from-transparent bg-secondary to-transparent rounded-md py-2 px-6 shadow hover:bg-third duration-700">
                            Play Music
                          </button>
                        </a>
                      </div>
                    </div>
                  </div>
                </a>
              </div>
            ))}
          </div>
        ) : (
          <MessagePlayer />
        )}
      </div>
      <Footer />
    </div>
  );
};

export default PlayerMusic;
