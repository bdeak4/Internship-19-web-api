import React from "react";

import styles from "./list.module.scss";

const List = ({ columns, rows, error }) => {
  if (error) {
    return <span className="error">{error}</span>;
  }

  return (
    <div>
      <div className={styles.columns}>
        {columns.map((column, index) => (
          <div key={index}>{column}</div>
        ))}
      </div>
      <div>
        {rows.map((elements, index) => (
          <div key={index} className={styles.row}>
            {elements.map((element, elementIndex) => (
              <div key={elementIndex} className={styles.column}>
                {element}
              </div>
            ))}
          </div>
        ))}
        {!rows.length && <span>Ad list empty :/</span>}
      </div>
    </div>
  );
};

export default List;
