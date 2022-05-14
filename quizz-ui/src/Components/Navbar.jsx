import React from "react";

const Navbar = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-* p-4">
      <div className="container">
        <a href="#" className="navbar-brand">
          Codder Quiz
        </a>
        <button
          className="navbar-toggler"
          data-bs-toggle="collapse"
          data-bs-target="#navbarCollapser"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarCollapser">
          <ul className="navbar-nav">
            <li className="nav-item">
              <a href="#" className="nav-link">
                About
              </a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link">
                Suported languages
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
