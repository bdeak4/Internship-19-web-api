import React, { useContext } from "react";
import Action from "src/components/Action";
import AdList from "src/components/List/AdList";
import { UserContext } from "src/providers/UserProvider";

import styles from "./ads.module.scss";

const Ads = () => {
  const {
    state: { token },
  } = useContext(UserContext);

  return (
    <div className={styles.wrapper}>
      <div className={styles.heading}>
        <h1>Ads</h1>
        {token !== null && (
          <Action variant="fill" renderAs="Link" props={{ to: "/ads/add" }}>
            Add Ad
          </Action>
        )}
      </div>
      <AdList />
    </div>
  );
};

export default Ads;
