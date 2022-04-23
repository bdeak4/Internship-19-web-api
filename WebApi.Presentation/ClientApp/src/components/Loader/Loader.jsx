import React, { useState, useEffect } from "react";

import styles from "./loader.module.scss";

const Loader = () => {
  const [dots, setDots] = useState("...");

  useEffect(() => {
    const intervalId = setInterval(() => {
      setDots((prev) => prev + ".");
    }, 50);

    return () => clearInterval(intervalId);
  }, []);

  return <div className={styles.loading}>Loading{dots}</div>;
};

export default Loader;
