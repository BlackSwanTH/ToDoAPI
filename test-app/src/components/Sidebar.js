import React from "react";
import { slide as Menu } from "react-burger-menu";
import "../index.css";
function Sidebar() {
  return (
    <Menu pageWrapId={"page-wrap"}>
      <div className="sidebar">
        <ul
          style={{
            listStyleType: "none",
            width: "100%",
            marginLeft: "0",
            paddingLeft: "0",
            marginTop: "0",
          }}
        >
          <li>
            <a
              id="main"
              style={{ color: "rgb(184, 183, 173)", textDecoration: "none" }}
              href="/main"
            >
              Main
            </a>
          </li>
          <li>
            <a
              id="main"
              style={{ color: "rgb(184, 183, 173)", textDecoration: "none" }}
              href="/credit"
            >
              Credit
            </a>
          </li>
          <li>
            <a
              id="main"
              style={{ color: "rgb(184, 183, 173)", textDecoration: "none" }}
              href="/SignOut"
            >
              Sign Out
            </a>
          </li>
        </ul>
        <br />
      </div>
    </Menu>
  );
}

export default Sidebar;
