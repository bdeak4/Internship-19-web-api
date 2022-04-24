import React from "react";

import styles from "./list.module.scss";

const List = ({ columns, rows, error }) => {
  if (error) {
    return <span className="error">{error}</span>;
  }

  return (
    <div>
      {!!rows.length && (
        <div className={styles.columns}>
          {columns.map((column, index) => (
            <div key={index}>{column}</div>
          ))}
        </div>
      )}
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
        {!rows.length && <div className={styles.empty}>Ad list empty :/</div>}
      </div>
    </div>
  );
};

export default List;
