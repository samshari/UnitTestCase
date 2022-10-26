import React from "react";
import { Link } from "react-router-dom";
import "../../styles/views/Navbar2.css";

const Navbar2 = () => {
  return (
    <div class="Navbar2">
      <div class="scroll2">
        <div class="Navbar_item">
          <Link to="/">
            <span> Engineering</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/HutPermitting">
            <span>Hut Permitting</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/Huts">
            <span>Huts</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/">
            <span> Engineering</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/HutPermitting">
            <span>Hut Permitting</span>
          </Link>
        </div>
        <div class="Navbar_item">
          <Link to="/Huts">
            <span>Huts</span>
          </Link>
        </div>
        <div class="Navbar_item">
          <Link to="/">
            <span> Engineering</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/HutPermitting">
            <span> Hut Permitting</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/Huts">
            <span>Huts</span>
          </Link>
        </div>

        <div class="Navbar_item">
          <Link to="/">
            <span> Engineering</span>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Navbar2;
