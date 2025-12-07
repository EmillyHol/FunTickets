import { Outlet, Link } from "react-router-dom";
import { useContext } from "react";
import { SearchContext } from "../SearchContext";

function Layout() {

    const { search, setSearch } = useContext(SearchContext);

  return (
    <div className="d-flex flex-column min-vh-100">

      
      <nav className="navbar navbar-dark bg-dark px-4 py-3">
        <div className="container-fluid d-flex justify-content-between align-items-center">

         
          <Link to="/" className="navbar-brand fs-4 fw-bold">
            Wonderlandx
          </Link>
        <form className="d-flex" role="search" onSubmit={(e) => e.preventDefault()}>
                <input
                type="text"
                value={search}
                onChange={(e) => setSearch(e.target.value)}
                placeholder="Search..."
                className="form-control"
                style={{
                    width: "180px",
                    borderRadius: "20px"
                }}
                />
            </form>
            </div>
        </nav>

     
      <main className="flex-fill">
        <Outlet />
      </main>

      
      <footer className="bg-dark text-light text-center py-3 mt-auto">
        © {new Date().getFullYear()} FunTickets — All rights reserved.
      </footer>

    </div>
  );
}

export default Layout;

