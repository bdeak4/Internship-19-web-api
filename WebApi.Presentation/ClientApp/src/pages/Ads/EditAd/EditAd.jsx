import React from "react";
import { useParams } from "react-router-dom";

import styles from "./edit-ad.module.scss";

const EditAd = () => {
  const { id } = useParams();
  return <div>edit add {id}</div>;
};

export default EditAd;
