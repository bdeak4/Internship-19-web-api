import React from "react";
import { useParams } from "react-router-dom";

import styles from "./ad.module.scss";

const Ad = () => {
  const { id } = useParams();
  return <div>view ad {id}</div>;
};

export default Ad;
