import React, { useContext } from "react";
import { UserContext } from "src/providers/UserProvider";

import Action from "../Action";

import styles from "./navigation.module.scss";

const Navigation = ({ isPrivateRoute }) => {
  const {
    state: { email },
    logOut,
  } = useContext(UserContext);

  return (
    <ul className={styles.navigation}>
      <li>
        <Action renderAs="Link" props={{ to: "/ads" }}>
          Ads
        </Action>
      </li>
      <li>
        <Action renderAs="Link" props={{ to: "/categories" }}>
          Categories
        </Action>
      </li>
      {isPrivateRoute ? (
        <>
          <li className={styles.end}>{email}</li>
          <li>
            <Action props={{ onClick: logOut }}>Log out</Action>
          </li>
        </>
      ) : (
        <>
          <li className={styles.end}>
            <Action renderAs="Link" props={{ to: "/" }}>
              Login
            </Action>
          </li>
          <li>
            <Action renderAs="Link" props={{ to: "/register" }}>
              Register
            </Action>
          </li>
        </>
      )}
    </ul>
  );
};

export default Navigation;
