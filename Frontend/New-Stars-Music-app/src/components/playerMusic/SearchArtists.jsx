import React, { useState } from "react";
import NoArtistsMessage from "./NoArtistsMessage";
import { useTheme } from "../../services/contexts/ThemeProvider";
import toast from "react-hot-toast";
import { findArtistsByName } from "../../api/discogs-api";
import { Button, Typography } from "@material-tailwind/react";
import { useNavigate, Link } from "react-router-dom";

const SearchArtists = ({ isHomePage = false }) => {
  const [artistName, setArtistName] = useState("");
  const [artists, setArtists] = useState([]);
  const { theme } = useTheme();
  const navigate = useNavigate();

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
        theme ? "flex flex-col" : " bg-gray-200 text-black flex flex-col"
      }
    >
      <div className="flex justify-center flex-grow">
        <div className="flex pt-2 flex-col items-center search-container">
          <div>
            <Typography variant="h3" className="mb-2 font-light text-center">
              Find your favorite artists and explore their products!
            </Typography>
          </div>
          <form
            className="flex flex-col justify-center items-center gap-4"
            onSubmit={handleSearch}
          >
            <div>
              <input
                placeholder="Search..."
                className={
                  theme
                    ? "bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
                    : "bg-gray-50 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
                }
                type="text"
                value={artistName}
                onChange={(e) => setArtistName(e.target.value)}
              />
            </div>

            <div>
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
            </div>
          </form>
        </div>
      </div>
      <div>
        {artists?.length > 0 ? (
          <div className="flex flex-col mt-4 w-full px-3 gap-4">
            {artists.map((artist) => (
              <div className="card w-full text-center" key={artist.id}>
                <div
                  className="group relative block bg-black
                        h-64 md:h-72 lg:h-80 xl:h-96 
                        w-full overflow-hidden rounded-lg"
                >
                  <img
                    alt={artist.title}
                    src={
                      !artist.cover_image.includes("spacer.gif")
                        ? artist.cover_image
                        : "unknown-artist.png"
                    }
                    className="h-full w-full object-cover opacity-75 transition-opacity group-hover:opacity-50"
                  />

                  <div className="absolute inset-0 p-4 sm:p-6 lg:p-8 z-10">
                    <p className="text-xl inline-block px-3 py-1 font-bold bg-black bg-opacity-60 rounded-md text-orange-700">
                      {artist.title}
                    </p>

                    <div className="absolute bottom-4 left-1/2 transform -translate-x-1/2">
                      <div className="translate-y-8 transform opacity-0 transition-all group-hover:translate-y-0 group-hover:opacity-100">
                        <p className="text-sm text-white mb-2">
                          Explore {artist.title}'s products 👇
                        </p>

                        <Link
                          to="/store"
                          state={{ artistName: artist.title }}
                          onClick={() => navigate("/store")}
                          className=" text-zinc-700 hover:text-zinc-200 backdrop-blur-lg bg-gradient-to-tr from-transparent bg-secondary to-transparent rounded-md py-2 px-2 shadow hover:bg-third duration-700"
                        >
                          Explore Products
                        </Link>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        ) : artists === null ? (
          <div className="flex flex-col items-center mt-6">
            <Typography className="text-lg text-red-600">
              Discogs server is down. Please try again later!
            </Typography>
            <Button
              onClick={() => navigate("/store")}
              className="mt-4"
              color={theme ? "blue" : "black"}
            >
              Manual Search
            </Button>
          </div>
        ) : (
          <NoArtistsMessage theme={theme} />
        )}
      </div>
    </div>
  );
};

export default SearchArtists;
