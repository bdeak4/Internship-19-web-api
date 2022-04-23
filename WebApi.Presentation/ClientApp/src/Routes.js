import React, { useContext } from "react";
import { Route, Routes as RoutesDom, Outlet } from "react-router-dom";
import Layout from "./components/Layout";

import Ads from "./pages/Ads";
import Ad from "./pages/Ads/Ad";
import AddAd from "./pages/Ads/AddAd";
import EditAd from "./pages/Ads/EditAd";
import Login from "./pages/Login";
import Register from "./pages/Register";

import { UserContext } from "./providers/UserProvider";

const Main = () => <Outlet />;

const Routes = () => {
  const {
    state: { token },
  } = useContext(UserContext);

  const isLoggedIn = token !== null;

  const publicRoutes = (
    <>
      <Route path="/" element={<Login />} />
      <Route path="/register" element={<Register />} />

      <Route path="/" element={<Layout />}>
        <Route path="/ads" element={<Ads />} />
        <Route path="/ads/:id" element={<Ad />} />
        <Route path="/add" element={<AddAd />} />
      </Route>
    </>
  );

  const privateRoutes = (
    <Route path="/" element={<Layout isPrivateRoute />}>
      <Route path="/" element={<Ads />} />
      <Route path="/ads" element={<Ads />} />
      <Route path="/ads/:id" element={<Ad />} />
      <Route path="/ads/add" element={<AddAd />} />
      <Route path="/ads/:id/edit" element={<EditAd />} />
    </Route>
  );

  return (
    <RoutesDom>
      <Route path="/" element={<Main />}>
        {isLoggedIn ? privateRoutes : publicRoutes}
      </Route>
    </RoutesDom>
  );
};

export default Routes;
