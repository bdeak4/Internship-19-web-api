import React, { useContext } from "react";
import { Route, Routes as RoutesDom, Outlet } from "react-router-dom";
import Layout from "./components/Layout";

import Ads from "./pages/Ads";
import Ad from "./pages/Ads/Ad";
import AddAd from "./pages/Ads/AddAd";
import EditAd from "./pages/Ads/EditAd";
import Login from "./pages/Login";
import Register from "./pages/Register";
import NotFound from "./pages/NotFound";

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
      <Route path="/add" element={<AddAd />} />
    </>
  );

  const privateRoutes = (
    <>
      <Route path="/" element={<Ads />} />
      <Route path="/ads/:id/edit" element={<EditAd />} />
    </>
  );

  return (
    <RoutesDom>
      <Route path="/" element={<Main />}>
        <Route path="/" element={<Layout isPrivateRoute={isLoggedIn} />}>
          <Route path="/ads" element={<Ads />} />
          <Route path="/ads/:id" element={<Ad />} />
          <Route path="/ads/add" element={<AddAd />} />

          {isLoggedIn ? privateRoutes : publicRoutes}

          <Route path="*" element={<NotFound />} />
        </Route>
      </Route>
    </RoutesDom>
  );
};

export default Routes;
