import axios from "axios";

const options = {
  method: "GET",
  url: "https://spotify23.p.rapidapi.com/search/",
  params: {
    type: "multi",
    offset: "0",
    limit: "10",
    numberOfTopResults: "5",
  },
  headers: {
    "x-rapidapi-key": "f01df68517mshdbe3f29cad6aa80p12a68bjsnc9f078de4e26",
    "x-rapidapi-host": "spotify23.p.rapidapi.com",
  },
};

try {
  const response = await axios.request(options);
  console.log(response.data);
} catch (error) {
  console.error(error);
}
