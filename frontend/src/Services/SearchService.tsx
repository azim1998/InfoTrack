import axios from "axios";
import { SearchResults } from "../Models/SearchResults";

const apiUrl = "http://localhost:5180/api/Search";

export const getSearchResults = async (
  keyword: string,
  targetUrl: string
): Promise<SearchResults> => {
  const response = await axios.post<SearchResults>(apiUrl, {
    keyword: keyword, 
    targetUrl: targetUrl
  });
  return response.data;
};