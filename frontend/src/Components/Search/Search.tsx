import React, { ChangeEvent, JSX, SyntheticEvent } from "react";

interface Props {
  keyword: string;
  url: string;
  onSearchSubmit: (e: SyntheticEvent) => void;
  handleSearchChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({
  keyword,
  url,
  onSearchSubmit,
  handleSearchChange,
}: Props): JSX.Element => {
  return (
    <div>
      <form onSubmit={onSearchSubmit}>
        <div>
          <input
            className="search"
            id="keyword"
            name="keyword"
            value={keyword}
            onChange={handleSearchChange}
            required
          />
        </div>
        <div>
          <input
            id="url"
            name="url"
            value={url}
            onChange={handleSearchChange}
            required
          />
        </div>
        <button type="submit">Search</button>
      </form>
    </div>
  );
};

export default Search;
