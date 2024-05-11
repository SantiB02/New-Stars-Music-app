import React, { useState } from "react";
import NavBar from "../NavBar";
import Footer from "../Footer";

const PlayerMusic = () => {
  const [song, setSong] = useState("");
  //const [tracks, setTracks] = useState([]);

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
      const url = `https://spotify23.p.rapidapi.com/search/?q=${song}&type=multi&offset=0&limit=10&numberOfTopResults=5`;
      const data = await fetch(url, options);
      const response = await data.json();
      console.log(response.tracks.items);
    } catch (error) {
      console.log(`ups..error: ${error}`);
    }
  }

  return (
    <div className="flex flex-col min-h-screen">
      <NavBar />
      <div className="flex-grow">
        <h1>Player Music new star music</h1>
        <form onSubmit={handleSearch}>
          <input
            placeholder="Search..."
            class="bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
            type="text"
            value={song}
            onChange={(e) => setSong(e.target.value)}
          />
          <button
            type="submit"
            class="bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
          >
            Search
          </button>
        </form>
      </div>
      <Footer />
    </div>
  );
};

export default PlayerMusic;
