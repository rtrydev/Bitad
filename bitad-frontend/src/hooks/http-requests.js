import api from "../api/api";
import { useEffect, useState } from "react";

/**
 * @param shortUrl
 * @param toggle
 */
export const useGetRequest = (shortUrl, toggle = false) => {
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
  }, [shortUrl, toggle]);
  return { response, isLoading };
};
