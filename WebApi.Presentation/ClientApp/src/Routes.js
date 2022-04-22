import React, { useContext } from "react";
import { Route, Routes as RoutesDom, Outlet } from "react-router-dom";
import Layout from "./components/Layout";

import Login from "./pages/Login";
import Register from "./pages/Register";

import { UserContext } from "./providers/UserProvider";

const Main = () => <Outlet />;

const Routes = () => {
  const {
    state: { token },
  } = useContext(UserContext);

  const isLoggedIn = token !== null;

  const application = (
    <Route path="/" element={<Layout />}>
      {/* <Route path="/" element={<Ad />} />
      <Route path="/ads/:id" element={<EditAd />} />
      <Route path="/ads/add" element={<AddAd />} />
      <Route path="/ads" element={<Ad />} /> */}
    </Route>
  );

  return (
    <RoutesDom>
      <Route path="/" element={<Main />}>
        {isLoggedIn ? application : <Route path="/" element={<Login />} />}
        <Route path="/register" element={<Register />} />
      </Route>
    </RoutesDom>
  );
};

export default Routes;
