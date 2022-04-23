import Action from "src/components/Action";

import styles from "./not-found.module.scss";

const NotFound = () => {
  return (
    <div>
      <h1 className={styles.title}>404</h1>
      <div className={styles.homeLink}>
        <Action renderAs="Link" props={{ to: "/ads" }}>
          &larr; Ads
        </Action>
      </div>
    </div>
  );
};

export default NotFound;
