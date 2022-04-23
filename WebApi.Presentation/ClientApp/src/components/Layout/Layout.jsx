import React, { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { UserContext } from "src/providers/UserProvider";
import Navigation from "../Navigation";

import styles from "./layout.module.scss";

const Layout = ({ isPrivateRoute }) => {
  const {
    state: { token },
  } = useContext(UserContext);

  if (!token && isPrivateRoute) {
    return <Navigate to="/" />;
  }

  return (
    <div className={styles.layout}>
      <Navigation isPrivateRoute={isPrivateRoute} />
      <Outlet />
    </div>
  );
};

export default Layout;
