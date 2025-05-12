import React, { ChangeEvent, FormEvent, useState } from "react";
import Search from "../../Components/Search/Search";
import { SearchResults } from "../../Models/SearchResults";
import { getSearchResults } from "../../Services/SearchService";
import './HomePage.css'; // Import the CSS file

interface SearchInputs {
  keyword: string;
  url: string;
}

const HomePage: React.FC = () => {
  const [searchInputs, setSearchInputs] = useState<SearchInputs>({
    keyword: "",
    url: "",
  });
  const [searchResults, setSearchResults] = useState<SearchResults | undefined>();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setSearchInputs((prevInput) => ({
      ...prevInput,
      [name]: value,
    }));
  };

  const onSearchSubmit = async (e: FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const result = await getSearchResults(searchInputs.keyword, searchInputs.url);
      setSearchResults(result);
      if (!result?.positions.length) {
        setError("No results found.");
      }
    } catch (err) {
      setError("Something went wrong. Please try again later.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="homepage-container">
      <header className="header">
        <h1>InfoTrack SEO Checker</h1>
        <p>Check your website ranking on Google for specific keywords.</p>
      </header>

      <div className="search-container">
        <Search
          keyword={searchInputs.keyword}
          url={searchInputs.url}
          onSearchSubmit={onSearchSubmit}
          handleSearchChange={handleSearchChange}
        />
      </div>

      {loading && <div className="loading">Loading...</div>}

      <div className="results-container">
        {error && <div className="error">{error}</div>}

        {searchResults && searchResults.positions && searchResults.positions.length > 0 ? (
          <div>
            <h2>Positions:</h2>
            <ul>
              {searchResults?.positions.map((position, index) => (
                <li key={index}>
                  <span>Position:</span> {position}
                </li>
              ))}
            </ul>
          </div>
        ) : (
          <p>No results to display</p>
        )}
      </div>
    </div>
  );
};

export default HomePage;