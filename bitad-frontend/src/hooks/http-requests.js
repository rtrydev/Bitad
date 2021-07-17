import api from "../api/api";
import { useEffect, useState } from "react";

/**
 * @param {string}
 */
export const useGetRequest = (shortUrl) => {
  const [response, setResponse] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    setIsLoading(true);
    api
      .get(shortUrl)
      .then((res) => {
        if (!Array.isArray(res.data)) return;
        setResponse(res.data);
        setIsLoading(false);
      })
      .catch((err) => {
        console.log(err);
      });
  }, [shortUrl]);
  return { response, isLoading };
};
