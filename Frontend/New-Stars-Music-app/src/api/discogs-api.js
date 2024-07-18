import axios from "axios";
import toast from "react-hot-toast";

const discogsApiUrl = "https://api.discogs.com";
const consumerKey = "CZbMdPnbDrFxxfPKkShV";
const consumerSecret = "SBTsfIBEqpuxysGhutQERXQQfFsQTAuO";

export const findArtistsByName = async (artist) => {
  const options = {
    method: "GET",
    url: `${discogsApiUrl}/database/search`,
    params: {
      q: artist,
      type: "artist",
      per_page: 6,
      key: consumerKey,
      secret: consumerSecret,
    },
  };

  try {
    const response = await axios.request(options);
    return response.data.results;
  } catch (error) {
    console.error("Error findind artists by name", error);
    toast.error("Error getting artists!");
  }
};
