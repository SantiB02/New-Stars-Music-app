import React, { useState } from "react";
import NavBar from "../NavBar";
import Footer from "../Footer";
import MessagePlayer from "./MessagePlayer";
import { useTheme } from "../../services/contexts/ThemeProvider";
import toast from "react-hot-toast";
import { findArtistsByName } from "../../api/discogs-api";
import { Typography } from "@material-tailwind/react";

const PlayerMusic = () => {
  const [artistName, setArtistName] = useState("");
  const [artists, setArtists] = useState([]);
  const { theme } = useTheme();

  const handleSearch = async (e) => {
    e.preventDefault();
    if (artistName.trim() === "") {
      toast.error("Artist's name can't be empty!");
      return;
    }
    setArtistName("");
    const artists = await findArtistsByName(artistName);
    setArtists(artists);
  };

  return (
    <div
      className={
        theme
          ? "flex flex-col min-h-screen"
          : " bg-gray-200 text-black flex flex-col min-h-screen"
      }
    >
      <div className="flex justify-center flex-grow">
        <div className="flex pt-4 flex-col items-center search-container">
          <div>
            <Typography variant="h3" className="mb-2 font-light text-center">
              Find your favorite artists and explore their products!
            </Typography>
          </div>
          <form onSubmit={handleSearch}>
            <input
              placeholder="Search..."
              className={
                theme
                  ? "bg-[#292929] mr-4 border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
                  : "bg-gray-50 mr-4 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
              }
              type="text"
              value={artistName}
              onChange={(e) => setArtistName(e.target.value)}
            />
            <button
              type="submit"
              className={
                theme
                  ? "bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
                  : "bg-gray-50 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
              }
            >
              Search
            </button>
          </form>
        </div>
      </div>
      <div>
        {artists.length > 0 ? (
          <div className="flex flex-wrap mt-4  ">
            {artists.map((artist) => (
              <div
                className="card w-full md:w-1/2 lg:w-1/3 p-4 text-center"
                key={artist.id}
              >
                <div className="group relative block bg-black">
                  <img
                    alt=""
                    src={
                      !artist.cover_image.includes("spacer.gif")
                        ? artist.cover_image
                        : "unknown-artist.png"
                    }
                    className="absolute inset-0 h-full w-full object-cover opacity-75 transition-opacity group-hover:opacity-50"
                  />
                  <div className="relative p-4 sm:p-6 lg:p-8">
                    <p className="text-xl inline-block px-4 font-bold bg-black bg-opacity-60 rounded-md text-orange-700 sm:text-2xl">
                      {" "}
                      {artist.title}
                    </p>
                    <div className="mt-32 sm:mt-48 lg:mt-64">
                      <div className="translate-y-8 transform opacity-0 transition-all group-hover:translate-y-0 group-hover:opacity-100">
                        <p className="text-sm text-white mb-2">
                          {" "}
                          do you want to explore {artist.title}'s products?
                          click here 👇{" "}
                        </p>
                        <a href="blank">
                          <button className="text-zinc-700 hover:text-zinc-200 backdrop-blur-lg bg-gradient-to-tr from-transparent bg-secondary to-transparent rounded-md py-2 px-6 shadow hover:bg-third duration-700">
                            Explore Products
                          </button>
                        </a>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        ) : (
          <MessagePlayer theme={theme} />
        )}
      </div>
    </div>
  );
};

export default PlayerMusic;
