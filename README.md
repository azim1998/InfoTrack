# InfoTrack SEO Checker

A lightweight web application that checks where a given URL appears in Google's top 100 search results for a specified keyword. Built using **React** (TypeScript) for the frontend and **ASP.NET Core** for the backend.

# Backend Setup

1. Navigate to the backend folder:

   ```bash
   cd backend
   ```

2. Restore and build the project:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Run the API:

   ```bash
   dotnet run
   ```
---

# Frontend Setup

1. Navigate to the frontend folder:

   ```bash
   cd frontend
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Start the React development server:

   ```bash
   npm start
   ```

   The app will be available at [http://localhost:3000].

---

# Usage

1. Enter a **keyword** (e.g., `land registry searches`) and your **URL** (e.g., `www.infotrack.co.uk`).
2. Submit the form to see in which positions (if any) your URL appears in Google's top 100 results.

---

# Notes

- Due to scraping limitations from Google, I was unable to retrieve the html response from the search page without being redirected to a bot page. I chose to spend my time focusing on the structure of the code and frontend instead of investigating the issues due to the time constraints.
