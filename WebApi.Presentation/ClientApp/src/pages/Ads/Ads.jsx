import React from "react";
import Action from "src/components/Action";
import AdList from "src/components/List/AdList";

import styles from "./ads.module.scss";

const Ads = () => {
  return (
    <div className={styles.wrapper}>
      <div className={styles.heading}>
        <h1>Ads</h1>
        <Action variant="fill" renderAs="Link" props={{ to: "/ads/add" }}>
          Add Ad
        </Action>
      </div>
      <AdList />
    </div>
  );
};

export default Ads;
